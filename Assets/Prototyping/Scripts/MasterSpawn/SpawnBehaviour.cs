using UnityEngine;
using System.Collections;
using AppConfiguration;

public class SpawnBehaviour : MonoBehaviour {

    Master master = new Master();
    float timePassed = HardConfiguration.SpawnInterval;
    float speed = 1f;
	public GameObject Pref;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {	
	}

    void LateUpdate ()
    {
        Spawn();
    }


    public void Spawn()
    {
        timePassed -= Time.deltaTime;
        
        if(timePassed <= 0f)
        {
            timePassed = Random.Range(.5f, 2f);

            Instantiate(
                    Pref,
					new Vector3(
						this.transform.position.x,
						Random.Range(HardConfiguration.MinY, HardConfiguration.MaxY),
						GameObject.FindGameObjectWithTag("Player").transform.position.z),
                    Quaternion.identity
                );

        }
    }

    

}
