using UnityEngine;
using System.Collections;

public class ScoreTextScript : MonoBehaviour {
	GUIText text;
	GameObject levelSettings;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<GUIText>();
		levelSettings = GameObject.FindGameObjectWithTag("LevelSettings");
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "SCORE: " + levelSettings.GetComponent<LevelSettings>().levelScore.ToString();
	}
}
