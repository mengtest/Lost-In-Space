using UnityEngine;
using UnityEngine.Advertisements;
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
	int collectedCoins;

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
	}

	public void GameOver()
	{
		gameOver = true;
		GA.API.Design.NewEvent("Game.End");
		PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed") + 1);
		if (PlayerPrefs.GetInt("GamesPlayed") % 4 == 0)
		{
			if (Advertisement.isReady()){
				Advertisement.Show();
				GA.API.Design.NewEvent("Advertisement.Shown");
			}
		}
		if (PlayerPrefs.GetInt("GamesPlayed") % 9 == 0)
		{
			IOSRateUsPopUp rate = IOSRateUsPopUp.Create();
			GA.API.Design.NewEvent("RateBox.Shown");
		}
		gameOverScreen.SetActive(true);

		PlayerPrefs.SetInt("RoundScore", levelScore);
		PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore") + levelScore);
		PlayerPrefs.SetInt("TotalCoinsCollected", PlayerPrefs.GetInt("TotalCoinsCollected") + collectedCoins);
		PlayerPrefs.SetInt("TotalAsteroidsDestroyed", PlayerPrefs.GetInt("TotalAsteroidsDestroyed") + PlayerPrefs.GetInt("RoundAsteroidsDestroyed"));

		GA.API.Design.NewEvent("Game.Round.Score", levelScore);
		GA.API.Design.NewEvent("Game.Round.Coins", PlayerPrefs.GetInt("CoinsCollected"));
		GA.API.Design.NewEvent("Game.Round.Asteroids", PlayerPrefs.GetInt("RoundAsteroidsDestroyed"));
		GA.API.Design.NewEvent("Game.Round.Distance", PlayerPrefs.GetInt("RoundDistance"));

		Debug.Log ("New Round Score: " + levelScore);
		Debug.Log ("New Total Score: " + PlayerPrefs.GetInt("TotalScore"));
		Debug.Log ("New Total Coins: " + PlayerPrefs.GetInt("TotalCoinsCollected"));
		Debug.Log ("New Total Asteroids: " + PlayerPrefs.GetInt("TotalAsteroidsDestroyed"));
		Debug.Log ("New Round Distance: " + PlayerPrefs.GetInt("RoundDistance"));

		//TODO: More stat tracking!


		//Highscore Checking
		if (PlayerPrefs.GetInt("RoundScore") > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", levelScore);
			Debug.Log ("New High Score Set: " + levelScore);
			GA.API.Design.NewEvent("Game.High.Score", levelScore);
		}
		if (PlayerPrefs.GetInt("RoundDistance") > PlayerPrefs.GetInt("HighDistance"))
		{
			PlayerPrefs.SetInt("HighDistance", PlayerPrefs.GetInt("RoundDistance"));
			Debug.Log ("New High Distance Set: " + PlayerPrefs.GetInt("HighDistance"));
			GA.API.Design.NewEvent("Game.High.Distance", PlayerPrefs.GetInt("HighDistance"));
		}
	}
	public void PauseGame()
	{
		paused = true;
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GA.API.Design.NewEvent("Game.Event.Pause");
	}
	public void ResumeGame()
	{
		pauseMenu.SetActive(false);
		paused = false;
		Time.timeScale = newTimeScale;
		GA.API.Design.NewEvent("Game.Event.Resume");
	}
	public void NewGame(){
		Application.LoadLevel("FloatingGame");
		gameOver = false;
		Time.timeScale = 1f;
		GA.API.Design.NewEvent("Game.Event.New");
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
		collectedCoins = coins * scoreMultiplier;
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