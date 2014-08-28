using UnityEngine;
using System.Collections;

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
			GA.API.Design.NewEvent("Menu.Play");
			Application.LoadLevel("FloatingGame");
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "OptionsButton")
		{
			Debug.Log ("Open Options Screen");
			GA.API.Design.NewEvent("Menu.Options");
			options.SetActive(true);
			mainMenu.SetActive(false);
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "CreditsButton")
		{
			GA.API.Design.NewEvent("Menu.Credits");
			Debug.Log("Open Credits Screen");
			credits.SetActive(true);
			mainMenu.SetActive(false);
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "MainMenuButton")
		{
			GA.API.Design.NewEvent("Menu.Back");
			Debug.Log("Going Home");
			credits.SetActive(false);
			options.SetActive(false);
			mainMenu.SetActive(true);
			soundManager.SendMessage("PlaySound", "Menu");
		}
		if (gameObject.name == "MainMenuGame")
		{
			GA.API.Design.NewEvent("Game.Event.Menu");
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
		if (gameObject.name == "StatsButton")
		{
			GA.API.Design.NewEvent("Menu.Stats");
			Debug.Log ("Going to Stats from Main Menu");
			soundManager.SendMessage("PlaySound", "Menu");
			Application.LoadLevel("Stats");
		}
		if (gameObject.name == "MainMenuButtonStats")
		{
			GA.API.Design.NewEvent("Menu.Back");
			Debug.Log ("Returning to main menu from stats");
			soundManager.SendMessage("PlaySound", "Menu");
			Application.LoadLevel("Main Menu");
		}
		if (gameObject.name == "ResetGameButton")
		{
			GA.API.Design.NewEvent("Menu.Reset");
			PlayerPrefs.DeleteAll();
		}

	}
}
