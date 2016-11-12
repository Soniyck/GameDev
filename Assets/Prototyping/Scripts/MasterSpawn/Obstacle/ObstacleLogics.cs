using UnityEngine;
using System.Collections;
using AppConfiguration;

public class ObstacleLogics : MonoBehaviour {
	//type 1 = basic obstacle
	public int Type;
	Master master = new Master();
	private float speed;

	void Start(){
		speed = Random.Range (0.5f, 1.5f);
	}

	public void ObstacleMovement()
	{
		


		this.transform.position = new Vector3(this.transform.position.x +  speed * master.difficulty / 10, this.transform.position.y, this.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		ObstacleMovement ();
	}
}
