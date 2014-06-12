using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
	GameObject levelSettings;
	GameObject soundManager;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find ("Level Settings");
		soundManager = GameObject.Find ("SoundManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		levelSettings.SendMessage("PauseGame");
		Debug.Log ("Game Paused");
		soundManager.SendMessage("PlaySound", "Menu");
	}

}
