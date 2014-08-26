﻿using UnityEngine;
using System.Collections;

public class LevelSettings : MonoBehaviour {
	public bool gameOver = false;
	public int levelScore;
	int scoreMultiplier = 1;
	float scoreTimer = 500f;

	public float timeScaleLimit = 16f; //This is the default time scale limit as the game progresses. Anything less than 12 should do. 
	public float timeIncreaseInterval = 10f; 
	public float timeScaleIncreaseAmount = .125f; //How much to add every timeIncreaseInterval seconds. .125f is the default amount. 
	GameObject doubleScoreIndicator;
	public GameObject pauseMenu;
	public GameObject gameOverScreen;
	float newTimeScale;
	public bool paused; 
	float levelLoadTime;

	// Use this for initialization
	void Start () {
		doubleScoreIndicator = GameObject.Find ("Active2X");
		Time.timeScale = 1f;
		levelScore = 0;
		//Debug.Log ("Time Scale at Launch: " + Time.timeScale);
		newTimeScale = 1f;
		levelLoadTime = 0f;
	}

	void Awake () {
		Application.targetFrameRate = 30; //Set a target frame rate, although I have no idea if this does anything... 
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true) {
			int timer = 0;
			timer++;
			if (timer > 100)
			{
				//Ignore for now.... might come back to making it work this way. Oh well. 
				//Time.timeScale = 0f;
			}
		}
		if (scoreMultiplier > 1)
		{
			scoreTimer = scoreTimer - 1;
			doubleScoreIndicator.SendMessage("Activate");
			MultiplierFlicker();
		}
		if (scoreTimer <= 0)
		{
			scoreMultiplier = 1;
		}
		if (scoreMultiplier == 1)
		{
			doubleScoreIndicator.SendMessage("Deactivate");
		}
		levelLoadTime = levelLoadTime + .25f;


	}

	void FixedUpdate () {

		//Time.timeScale = 15f;
		//Debug.Log ("Time Scale: " + Time.timeScale);
		if (Time.timeScale < timeScaleLimit)
		{
			if (levelLoadTime % timeIncreaseInterval == 0)
			{
				if (paused == false)
				{
					if (gameOver == false)
					{
						Time.timeScale = Time.timeScale + timeScaleIncreaseAmount;
						newTimeScale = Time.timeScale;
					}
				}
			}
		}
		//Debug.Log ("TimeScale: " + Time.timeScale);
		//Debug.Log ("LoadTime: " + levelLoadTime);

	}

	public void GameOver()
	{
		gameOver = true;
		gameOverScreen.SetActive(true);
	}
	public void PauseGame()
	{
		paused = true;
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		//Debug.Log ("Time Scale at Pause: " + Time.timeScale);
	}
	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		paused = false;
		Time.timeScale = newTimeScale;
		//Debug.Log ("Time Scale: " + Time.timeScale);
		//Debug.Log ("New Time Scale: " + newTimeScale);

	}
	public void NewGame(){
		Application.LoadLevel("FloatingGame");
		gameOver = false;
		Time.timeScale = 1f;
	}

	public void DoubleScore()
	{
		scoreMultiplier = 2;
		scoreTimer = 500f;
	}

	void AddScore(int score)
	{
		levelScore = levelScore + score * scoreMultiplier;
		PlayerPrefs.SetInt("CurrentLevelScore", levelScore);
	}
	void AddCoins(int coins)
	{
		PlayerPrefs.SetInt("CoinsCollected", PlayerPrefs.GetInt("CoinsCollected") + (coins * scoreMultiplier));
	}

	void MultiplierFlicker()
	{
		//This entire script will flicker the double score power up icon at the bottom of the screen. 
		//Since score is handeled in this script file, the flicker script for it is here too.
		//Other power ups should be handeld in their respective script files. 
		if (scoreTimer <=100)
		{
			doubleScoreIndicator.SendMessage("Deactivate");
		}
		if (scoreTimer <=90)
		{
			doubleScoreIndicator.SendMessage("Activate");
		}
		if (scoreTimer <=80)
		{
			doubleScoreIndicator.SendMessage("Deactivate");
		}
		if (scoreTimer <=70)
		{
			doubleScoreIndicator.SendMessage("Activate");
		}
		if (scoreTimer <=60)
		{
			doubleScoreIndicator.SendMessage("Deactivate");
		}
		if (scoreTimer <=50)
		{
			doubleScoreIndicator.SendMessage("Activate");
		}
		if (scoreTimer <=40)
		{
			doubleScoreIndicator.SendMessage("Deactivate");
		}
		if (scoreTimer <=30)
		{
			doubleScoreIndicator.SendMessage("Activate");
		}
		if (scoreTimer <=20)
		{
			doubleScoreIndicator.SendMessage("Deactivate");
		}
		if (scoreTimer <=10)
		{
			doubleScoreIndicator.SendMessage("Activate");
		}
	}
}