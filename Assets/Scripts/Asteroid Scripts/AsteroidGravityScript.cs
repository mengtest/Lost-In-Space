using UnityEngine;
using System.Collections;

public class AsteroidGravityScript : MonoBehaviour {
	bool done;
	public float verticalSpeed = -50f;
	// Use this for initialization
	void Start () {
		gameObject.rigidbody2D.AddForce(new Vector2(Random.Range (-10f,10f),verticalSpeed));
		done = false; 
	}
	
	// Update is called once per frame
	void Update () {
		//This is useless. 
		if (done == false)
		{
			done = true;
		}
	}
}
