using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsListScript : MonoBehaviour {
	Text text; 
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = ("Total Coins Collected:" + "\n" + PlayerPrefs.GetInt("TotalCoinsCollected")
		             + "\n \n" + "High Score:" + "\n" + PlayerPrefs.GetInt("HighScore")
		             + "\n \n" + "Furthest Traveled:" + "\n" + PlayerPrefs.GetInt("HighDistance")
		             + "\n \n" + "Asteroids Destroyed:" + "\n" + PlayerPrefs.GetInt("TotalAsteroidsDestroyed"));


	}
}
