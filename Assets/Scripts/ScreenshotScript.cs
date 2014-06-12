using UnityEngine;
using System.Collections;

public class ScreenshotScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.S))
		{
			Application.CaptureScreenshot("Screenshots/LostInSpace-"+ System.DateTime.Now.Month + System.DateTime.Now.Day + System.DateTime.Now.Year + "-" + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second + ".png");
		}
	}
}
