using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public Transform CamFinalPos;
	public Transform PlayerFinalPos;

	public Transform Cam;
	public Transform Player;


	private float FinalPosPlayerDistance;

	private Vector3 CamActualPos;
	private Vector3 PlayerActualPos;

	public float speed = 0.1f;
	public float turnSpeed = 5f;

	void Start(){
		//get actual positions of the objects
		CamActualPos = Cam.position;
		PlayerActualPos = Player.position;
	}

	public void GoToPos(){
		//get distances

		FinalPosPlayerDistance = Vector3.Distance (Player.position, PlayerFinalPos.position);


		//

		if(Player.rotation.y < 0f){
			
			Player.transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime, Space.World);
		}

		if (FinalPosPlayerDistance > 0.1f) {
			PlayerActualPos.y += speed * Time.deltaTime;
			CamActualPos.y += speed * Time.deltaTime;
		}

		Player.position = PlayerActualPos;
		Cam.position = CamActualPos;
		speed += 0.1f * Time.deltaTime;
		//when no longer needed, delete script
		if (FinalPosPlayerDistance < 0.1f) {
			Cam.GetComponent<PerspectiveSwitcher> ().PerspStarted = true;
			Player.GetComponent<Player> ().enabled = true;
			Destroy (this.gameObject);
		}
	}

	public void FixedUpdate(){
		GoToPos ();
	}
}
