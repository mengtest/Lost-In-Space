using UnityEngine;
using System.Collections;

public class ScoreGameButton : MonoBehaviour {
	GameObject levelSettings;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.FindGameObjectWithTag("LevelSettings");
		Debug.Log ("Found " + levelSettings.name);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		Debug.Log ("Clicked");
		levelSettings.SendMessage("GameOver", SendMessageOptions.RequireReceiver);
	}
}
