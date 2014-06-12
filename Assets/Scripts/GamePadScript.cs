using UnityEngine;
using System.Collections;

public class GamePadScript : MonoBehaviour {
	public float speedModifier = 1f; //Modifier for the speed. Multiplies, so anything less than 0 (ex: .5f) slows it down.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + Input.GetAxis ("Horizontal") * speedModifier, gameObject.transform.position.y);
			Debug.Log ("Going Left! + " + Input.GetAxis("Horizontal"));
		}
	}
}
