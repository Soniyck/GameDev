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

    void Update()
    {
        ObstacleMovement();
    }



    public void ObstacleMovement()
	{
		this.transform.position = new Vector3(this.transform.position.x + speed * HardConfiguration.StartDifficulty / 10,
                                              this.transform.position.y,
                                              this.transform.position.z);
	}


    // On player collision with obstacle
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            // There are several types of obstacles, every type acts differently on collision with player
            if (this.Type == 1)
            {
                Player.DeathIsForced = true;
            }
        }
    }


}
