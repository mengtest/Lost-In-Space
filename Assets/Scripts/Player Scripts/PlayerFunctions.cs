using UnityEngine;
using System.Collections;

public class PlayerFunctions : MonoBehaviour {
	GameObject levelSettings;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find("Level Settings");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void DestroyPlayer () {
		levelSettings.SendMessage("GameOver", SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
