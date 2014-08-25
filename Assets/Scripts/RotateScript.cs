using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	public float rotationSpeed = 10f;
	float direction;
	// Use this for initialization
	void Start () {
		//Determines the direction the player will spin for that round. 
		direction = Random.Range (-1, 1);
		if (direction == 0)
		{
			direction = 1;
		}
		gameObject.rigidbody2D.AddTorque(rotationSpeed * (float)direction);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.name == "Player")
		{
			if (direction == 1) {
				if (gameObject.rigidbody2D.angularVelocity <= 30)
				{
					gameObject.rigidbody2D.AddTorque((rotationSpeed / 3) * (float)direction);
				}
			}
			if (direction == -1) {
				if (gameObject.rigidbody2D.angularVelocity >= -30)
				{
					gameObject.rigidbody2D.AddTorque((rotationSpeed / 3) * (float)direction);
				}
			}
		}



	}
}
