using UnityEngine;
using System.Collections;
//
public class MainMenuButtons : MonoBehaviour {
	public GameObject credits;
	public GameObject mainMenu;
	public GameObject options;
	GameObject soundManager;
	// Use this for initialization
	void Start () {
		soundManager = GameObject.Find ("SoundManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		if (gameObject.name == "PlayButton")
		{
			Application.LoadLevel("FloatingGame");
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "OptionsButton")
		{
			Debug.Log ("Open Options Screen");
			options.SetActive(true);
			mainMenu.SetActive(false);
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "CreditsButton")
		{
			Debug.Log("Open Credits Screen");
			credits.SetActive(true);
			mainMenu.SetActive(false);
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "MainMenuButton")
		{
			Debug.Log("Going Home");
			credits.SetActive(false);
			options.SetActive(false);
			mainMenu.SetActive(true);
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "MainMenuGame")
		{
			Debug.Log("Returing to Main Menu");
			Application.LoadLevel ("Main Menu");
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "ResumeGame")
		{
			GameObject levelSettings = GameObject.Find ("Level Settings");
			levelSettings.SendMessage("ResumeGame");
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "PlayAgain")
		{
			GameObject levelSettings = GameObject.Find ("Level Settings");
			levelSettings.SendMessage("NewGame");
			soundManager.SendMessage("PlaySound", "Menu");
		}

	}
}
