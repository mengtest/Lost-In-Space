using UnityEngine;
using System.Collections;

public class AsteroidGravityScript : MonoBehaviour {
	bool done;
	public float verticalSpeed = -50f;
	float verticalSpeedSwing = 1f;
	// Use this for initialization
	void Start () {
		gameObject.rigidbody2D.AddForce(new Vector2(Random.Range (-10f,10f),
		                                            Random.Range(verticalSpeed - verticalSpeedSwing, 
		             								verticalSpeed + verticalSpeedSwing)));
	}
	
	// Update is called once per frame
	void Update () {

	}
}
