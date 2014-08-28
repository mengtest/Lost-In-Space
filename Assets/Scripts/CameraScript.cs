using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject audioManager;

	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "MainMenu")
		{
			//PlayerPrefs.SetFloat("PreviousHeightRecord", 0f);
			PlayerPrefs.SetString("CurrentMaterial", "Crate");
			//GA.API.User.NewUser(GA_User.Gender.Unknown, 2013, 0);
		}
		if (PlayerPrefs.GetString("CurrentMaterial") == "" || PlayerPrefs.GetString("CurrentMaterial") == " ")
		{
			PlayerPrefs.SetString("CurrentMaterial", "Wood");
		}
		PlayerPrefs.Save();
		//if (Application.loadedLevelName == "GameScene2")
		//{
			PlayerPrefs.SetInt ("CurrentScore", 0);
		//}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Application.loadedLevelName != "MainMenu")
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				//	transform.Translate(0f,.5f, 0, Camera.main.transform);
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				//transform.Translate(0f,-.5f, 0, Camera.main.transform);
			}
			if (Input.GetKey(KeyCode.PageDown))
			{
				//camera.orthographicSize++;
			}
			if (Input.GetKey(KeyCode.PageUp))
			{
				//camera.orthographicSize--;
			}
			//If zooming was enabled, this would keep it's size so you couldn't infinitely zoom in or out. 
			if (camera.orthographicSize >= 19f)
			{
				camera.orthographicSize = 19f;
			}
			if (camera.orthographicSize <= 1f)
			{
				camera.orthographicSize = 1f;
			}
			/*if (camera.transform.position.y < 12.87f)
			{
				camera.transform.position = new Vector3(0f,12.87f,-10f);
			}*/
		}
		if (Application.loadedLevelName == "MainMenu")
		{
			if (Input.GetKeyDown (KeyCode.Escape))
			{
				PlayerPrefs.DeleteAll(); Debug.Log("Deleted All Player Prefs"); //Clear all player prefs.
			}
		}
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Application.CaptureScreenshot("TumblingTowers_" + System.DateTime.Now.TimeOfDay.TotalDays + System.DateTime.Now.TimeOfDay.Seconds + System.DateTime.Now.TimeOfDay.Milliseconds + ".png");
		}


	}

	void OnApplicationQuit()
	{
		//GA.API.Design.NewEvent("Height Record", PlayerPrefs.GetFloat("PreviousHeightRecord"));
		//GA_Queue.SubmitQueue();
		PlayerPrefs.Save();
	}
}
