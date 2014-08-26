using UnityEngine;
using System.Collections;

public class ObjectSpawnScript : MonoBehaviour {
	public GameObject[] objects;
	public float spawnTimer; //Mostly unused now. Could strip from code eventually. TODO: Refactor it. 
	public float spawnTimerSwingAmount; //This is the amount that the timer will swing by. + and -
	float spawnTimerSwing; //This is the finalized swing timer that changes each time Spawn() or SpawnStars() in Called. 
	public float spawnHeight = 7f; //The height at which objects spawn. 7f is about the right amount off screen for spawning things. 
	float timer;
	public bool optionalStarSpawning; //For laziness, will allow the spanwer to switch between a spawnign stars script and spawning objects
	public int objSpawned;
	GameObject spawnedObject;
	bool playerShields;
	//public float optionalStarRange; 
	// Use this for initialization
	void Start () {
		timer = 0f;
		objSpawned = 0;
	} 
	
	// Update is called once per frame
	void Update () {
		//Checking for player, and then pulling the ShieldEnabled Bool from it's script for future use. 
		if (GameObject.Find("Player") != null)
			playerShields = GameObject.Find("Player").GetComponentInChildren<ShieldScript>().shieldEnabled;

		//Always seed Random based on seconds, hours, etc for a random experience. 
		Random.seed = System.DateTime.Now.Second + System.DateTime.Now.Hour + System.DateTime.Now.Month + System.DateTime.Now.Minute + System.DateTime.Now.Millisecond;

		timer = timer + Time.deltaTime;
		if (timer >= spawnTimerSwing)
		{	
			//Spawner will determine if it's supposed to be spawning a star. It will also switch up the swing for the spawn timer
			//each time it is called, that way it it be semi-random on when objects will spawn. 
			if (optionalStarSpawning == false) {
				Spawn ();
				spawnTimerSwing = Random.Range(spawnTimer - spawnTimerSwingAmount, spawnTimer + spawnTimerSwingAmount);
			}
			else if (optionalStarSpawning == true) {
				SpawnStars();
				spawnTimerSwing = Random.Range(spawnTimer - spawnTimerSwingAmount, spawnTimer + spawnTimerSwingAmount);
			}

			timer = 0;
		}

	}

	void Spawn() {
		//Debug.Log (spawnTimerSwing);
		int objectNumber = Random.Range (0, objects.Length);
		if (objects[objectNumber].name == "Star")
		{
			if (playerShields == true)
			{
				//Set a brand new seed for this frame
				Random.seed = System.DateTime.Now.Second + System.DateTime.Now.Hour + System.DateTime.Now.Month + System.DateTime.Now.Minute + System.DateTime.Now.Millisecond * 2;
				
				//Spawn a new object that isn't element 0 in the array (the shield)
				objectNumber = Random.Range(1,objects.Length);
				
				//Debug.Log ("Swapped out shield")
			}
			if (objSpawned < 12)
			{
				/*
				 * Check if a star has been spawned in the previous XX spawns
				 * Spawns without shield variable needed.
				 * Each spawn without a shield = +1
				 * if spawns without shield < 16
				 * spawn shield and reset to zero
				 */

				//Set a brand new seed for this frame
				Random.seed = System.DateTime.Now.Second + System.DateTime.Now.Hour + System.DateTime.Now.Month + System.DateTime.Now.Minute + System.DateTime.Now.Millisecond * 2;

				//Spawn a new object that isn't element 0 in the array (the shield)
				objectNumber = Random.Range(1,objects.Length);

				//Debug.Log ("Swapped out shield"); 
			}
		}

		if (objects[objectNumber].name == "Star" && objSpawned > 12)
		{
			//Reset the objects spawned without a shield to zero.
			objSpawned = 0;

			//Debug.Log ("Shield Spawned // Reset Counter");
		}

		spawnedObject = (GameObject)Instantiate(objects[objectNumber], new Vector3(Random.Range(-2.5f,2.5f),spawnHeight), new Quaternion(0f,0f,0f,0f));
		objSpawned = objSpawned + 1;

	}

	void SpawnStars() { 

		// This is a different script because of laziness. 
		int objectNumber = Random.Range (0, objects.Length);
		GameObject spawnedObject = (GameObject)Instantiate(objects[objectNumber], new Vector3(Random.Range(gameObject.transform.position.x,gameObject.transform.position.x + 3f),spawnHeight), new Quaternion(0f,0f,0f,0f));


	}
}
