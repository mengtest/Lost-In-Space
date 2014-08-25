using UnityEngine;
using System.Collections;

public class AccelerometerScript : MonoBehaviour {
	GameObject levelSettings;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find ("Level Settings");
	}
	
	// Update is called once per frame
	void Update () {
		if (levelSettings.GetComponent<LevelSettings>().paused == false)
		{
			//Handles any accelerometer movement from the device. 
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + 
			                                            Input.acceleration.x, 
			                                            gameObject.transform.position.y);
		}
	}
}
