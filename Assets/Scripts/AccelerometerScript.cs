using UnityEngine;
using System.Collections;

public class AccelerometerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3(gameObject.transform.position.x + Input.acceleration.x, gameObject.transform.position.y);
	}
}
