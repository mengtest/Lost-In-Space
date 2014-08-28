using UnityEngine;
using System.Collections;

public class SocialSharing : MonoBehaviour {
	IOSSocialManager socialManager;
	int roundScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		roundScore = PlayerPrefs.GetInt("RoundScore");
	}

	void OnMouseDown () {
		if (gameObject.name == "TwitterButton")
		{
			socialManager.ShareMedia("Test!");
		}
		if (gameObject.name == "FacebookButton")
		{
			socialManager.ShareMedia("Test!");
		}
	}
}
