using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuCoinScript : MonoBehaviour {
	GameObject levelSettings;
	Text text;
	int collectedCoins;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find ("Level Settings");
		text = gameObject.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		collectedCoins = PlayerPrefs.GetInt("CoinsCollected");
		text.text = collectedCoins.ToString();
	}
}
