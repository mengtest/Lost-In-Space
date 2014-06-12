using UnityEngine;
using System.Collections;

public class GamePadScript : MonoBehaviour {
	public float speedModifier = 1f; //Modifier for the speed. Multiplies, so anything less than 0 (ex: .5f) slows it down.
	GameObject levelSettings;
	bool pauseDown;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find ("Level Settings");
		pauseDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") != 0)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x + Input.GetAxis ("Horizontal") * speedModifier, gameObject.transform.position.y);
		}
		if (Input.GetAxis ("Pause") >= 1f)
		{
			//levelSettings.SendMessage("PauseGame");
			Debug.Log ("Pause Game");
			pauseDown = true;
		}
		if (Input.GetAxis ("Pause") <= .5f && pauseDown == true) 
		{
			levelSettings.SendMessage("PauseGame");
			pauseDown = false;
		}
		//Debug.Log ("Pause Axis: " + Input.GetAxis ("Pause"));
		Debug.Log (pauseDown);
	}
}
