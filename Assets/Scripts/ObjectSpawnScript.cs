using UnityEngine;
using System.Collections;

public class ObjectSpawnScript : MonoBehaviour {
	public GameObject[] objects;
	public float spawnTimer;
	public float spawnHeight = 7f;
	float timer;
	public bool optionalStarSpawning;
	//public float optionalStarRange;
	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		Random.seed = System.DateTime.Now.Second + System.DateTime.Now.Hour + System.DateTime.Now.Month + System.DateTime.Now.Minute + System.DateTime.Now.Millisecond;

		timer = timer + Time.deltaTime;

		if (timer >= spawnTimer)
		{	if (optionalStarSpawning == false) {
			Spawn ();
			}
			else if (optionalStarSpawning == true) {
				SpawnStars();
			}
			timer = 0;
		}

	}

	void Spawn() {
		int objectNumber = Random.Range (0, objects.Length);
		GameObject spawnedObject = (GameObject)Instantiate(objects[objectNumber], new Vector3(Random.Range(-2.5f,2.5f),spawnHeight), new Quaternion(0f,0f,0f,0f));
		

	}

	void SpawnStars() { // This is a different script because of laziness. 
		int objectNumber = Random.Range (0, objects.Length);
		GameObject spawnedObject = (GameObject)Instantiate(objects[objectNumber], new Vector3(Random.Range(gameObject.transform.position.x,gameObject.transform.position.x + 3f),spawnHeight), new Quaternion(0f,0f,0f,0f));


	}
}
