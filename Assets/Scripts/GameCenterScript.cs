﻿using UnityEngine;
using System.Collections;

public class GameCenterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!GameCenterManager.IsInited)
			GameCenterManager.init();

		//Registering Distance in One Run Achievements 
		GameCenterManager.registerAchievement("distance500"); //5 Points
		GameCenterManager.registerAchievement("distance1000"); //10 Points
		GameCenterManager.registerAchievement("distance2000"); //10 Points
		GameCenterManager.registerAchievement("distance5000"); //10 Points
		GameCenterManager.registerAchievement("distance7500"); //10 Points
		GameCenterManager.registerAchievement("distance9001"); //10 points 
		GameCenterManager.registerAchievement("distance10000"); //25 Points 

		//Registering Total Distance Achievements
		GameCenterManager.registerAchievement("totaldistance1000"); //5 Points
		GameCenterManager.registerAchievement("totaldistance5000"); //5 Points
		GameCenterManager.registerAchievement("totaldistance10000"); //5 Points
		GameCenterManager.registerAchievement("totaldistance50000"); //10 Points
		GameCenterManager.registerAchievement("totaldistance100000"); //10 Points
		GameCenterManager.registerAchievement("totaldistance500000"); //15 Points
		GameCenterManager.registerAchievement("totaldistance1000000"); //20 Points

		//Registering Rounds Complete Achievements
		GameCenterManager.registerAchievement("rounds1"); //1 Points
		GameCenterManager.registerAchievement("rounds10"); //4 Points
		GameCenterManager.registerAchievement("rounds25"); //10 Points
		GameCenterManager.registerAchievement("rounds50"); //10 Points 
		GameCenterManager.registerAchievement("rounds100"); //10 Points 
		GameCenterManager.registerAchievement("rounds250"); //25 Points 
		GameCenterManager.registerAchievement("rounds500"); //25 Points
		GameCenterManager.registerAchievement("rounds1000"); //100 Points

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UnlockAchievmenet() {

	}

	public void UpdateLeaderboard(string leaderboard, int score) {
	
		string furthestDistance = "distance.furthest";
		string totalDistance = "distance.total";
		string totalCoins = "coins.total";
		string bestScore = "score.best";
		string totalScore = "score.total";

		GameCenterManager.reportScore(score, leaderboard);

	}
}