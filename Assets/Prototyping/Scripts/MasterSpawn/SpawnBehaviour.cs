using UnityEngine;
using System.Collections;
using AppConfiguration;

public class SpawnBehaviour : MonoBehaviour {
	public Transform MinYObject;
	public Transform MaxYObject;

    Master master = new Master();
    float timePassed = HardConfiguration.SpawnInterval;
    float speed = 1f;
	public GameObject Pref;

    // Use this for initialization
    void Start () {
		HardConfiguration.MinY = MinYObject.position.y;
		HardConfiguration.MaxY = MaxYObject.position.y;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate ()
    {
        Spawn();
        
    }
	void FixedUpdate(){
		
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
			Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position.z);
        }
    }

    

}
