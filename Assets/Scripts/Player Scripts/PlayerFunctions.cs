using UnityEngine;
using System.Collections;

public class PlayerFunctions : MonoBehaviour {
	GameObject levelSettings;
	int distanceTraveled;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find("Level Settings");
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Player") != null)
		{
			distanceTraveled++;
			//Debug.Log ("Current Distance Traveled is: " + distanceTraveled);
		}
	}
	

	void DestroyPlayer () {
		PlayerPrefs.SetInt("RoundDistance", distanceTraveled);
		levelSettings.SendMessage("GameOver", SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
