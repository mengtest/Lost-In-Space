using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "Main Menu")
		{
			Time.timeScale = 1f; //When you return to the main menu, reset the timeScale due to gameplay speeding up. 
		}
	}
}
