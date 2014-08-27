﻿using UnityEngine;
using System.Collections;

public class SocialSharing : MonoBehaviour {
	IOSSocialManager socialManager;
	int roundScore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		if (gameObject.name == "TwitterButton")
		{
			socialManager.TwitterPost("I just scored " + roundScore + " in Lost In Space on iOS! Check it out: http://bit.ly/LostInSpace #ios #mobilegames");
		}
		if (gameObject.name == "FacebookButton")
		{
			socialManager.FacebookPost("I just scored " + roundScore + " in Lost In Space on iOS! Check it out: http://bit.ly/LostInSpace #ios #mobilegames");
		}
	}
}
