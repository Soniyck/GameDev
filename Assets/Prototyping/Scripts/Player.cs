using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Transform MinYObject,
	MaxYObject;

	private float MinY,
	MaxY;

	private bool ShouldGoDown = false;

	public float FlyingSpeed = 3f;
	public float ActualSpeed = 0f;

	public Transform BloodyVignetteBottom,
	BloodyVignetteTop;


	void Start(){
		MinY = MinYObject.transform.position.y;
		MaxY = MaxYObject.transform.position.y;

		BloodyVignetteBottom.GetComponent<Image> ().CrossFadeAlpha (0f, 1f, false);
		BloodyVignetteTop.GetComponent<Image> ().CrossFadeAlpha (0f, 1f, false);

	}

	void Update(){
		PlayerMovementLogics ();

		VisualiseBarrier ();
	}

	void FixedUpdate(){
		UponDeath ();
	}


	//vars used by this function

	public float MovementOffsetTime = 1.5f;
	private bool DuringOffset = false;

	private void Offset(){
		if (DuringOffset == true) {
			
			SlowDown = true;

			if (ActualSpeed*1f<0.1f) {
				
				ActualSpeed = 0f;
				SlowDown = false;
				DuringOffset = false;
			}
		}
	}

	private void PlayerMovementLogics (){
		//raise

		//lower
		if (Input.GetButtonDown ("Jump")) {
			DuringOffset = true;
			ShouldGoDown = true;
		}

		if (Input.GetButtonUp ("Jump")) {
			DuringOffset = true;
			ShouldGoDown = false;
		}


		//assign vectors values
		if (DuringOffset == false) {
			if (ShouldGoDown) {
				dir = -1;
			} else {
				dir = +1;
			}
		}
		ApplyMovement ();
		Offset ();
	}

	private bool SlowDown;
	private float dir;
	public void ApplyMovement(){
		ActualSpeed = ActualSpeed * 1f;

		if (ActualSpeed < FlyingSpeed&&SlowDown == false) {
			ActualSpeed += 0.5f * Time.deltaTime;
		}

		if (SlowDown && ActualSpeed > 0f) {
			ActualSpeed -= FlyingSpeed/MovementOffsetTime * Time.deltaTime;
		}
		transform.Translate(Vector3.up * Time.deltaTime * ActualSpeed * dir, Space.World);
	}

	private bool BarrierReached(){
		if (this.transform.position.y < MinY || this.transform.position.y > MaxY) {
			return true;
		}
			return false;
	}

	private void VisualiseBarrier(){
		//top
		if (this.transform.position.y < MinY - MinY / 2f) {
			BloodyVignetteBottom.GetComponent<Image> ().CrossFadeAlpha (1f, 1f, false);
		} else {
			BloodyVignetteBottom.GetComponent<Image> ().CrossFadeAlpha (0f, 1f, false);
		}
		//bottom
		if (this.transform.position.y > MaxY - MaxY / 2f) {
			BloodyVignetteTop.GetComponent<Image> ().CrossFadeAlpha (1f, 1f, false);
		} else {
			BloodyVignetteTop.GetComponent<Image> ().CrossFadeAlpha (0f, 1f, false);
		}
	}


	private bool DeathIsForced;
	//this is for barriers
	private void UponDeath(){
		if (BarrierReached () || DeathIsForced) {
			if (this.transform.position.y < MinY && DeathIsForced == false) {
				this.transform.GetComponent<Rigidbody> ().velocity = new Vector3 (10f, 10f, 0f);
			}
			if (this.transform.position.y > MaxY && DeathIsForced == false) {
				this.transform.GetComponent<Rigidbody> ().velocity = new Vector3 (10f, -10f, 0f);
			}


			if (DeathIsForced) {
				this.transform.GetComponent<Rigidbody> ().velocity = new Vector3 (10f, -10f, 0f);
			}

			this.transform.GetComponent<Rigidbody> ().AddTorque (transform.up * 5f,ForceMode.VelocityChange);
			this.transform.GetComponent<Rigidbody> ().AddTorque (transform.right * 5f,ForceMode.VelocityChange);

			BloodyVignetteTop.GetComponent<Image> ().CrossFadeAlpha (0f, 1f, false);
			BloodyVignetteBottom.GetComponent<Image> ().CrossFadeAlpha (0f, 1f, false);

			this.transform.GetComponent<Player> ().enabled = false;

			Debug.Log ("I should be dead");
		}
	}

	//this is for obstacles, other cases
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Obstacle"){
			
			if(col.gameObject.GetComponent<ObstacleLogics>().Type == 1){
				Debug.Log ("Fuckoff");
				DeathIsForced = true;
			}
		}
	}
}