using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {
	bool invisibilePowerup = false;
	GameObject levelSettings;
	GameObject soundManager;
	GameObject shield;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find("Level Settings");
		soundManager = GameObject.Find ("SoundManager");
		shield = GameObject.Find("Shield");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Asteroid")
		{

			if (shield.GetComponent<ShieldScript>().shieldEnabled == false)
			{
				gameObject.SendMessage("DestroyPlayer", SendMessageOptions.DontRequireReceiver);
			}
			else if (shield.GetComponent<ShieldScript>().shieldEnabled == true)
			{
				col.gameObject.SendMessage("DestroyAsteroid");
			}
			soundManager.SendMessage("PlaySound", "Explosion");
		}
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Coin")
		{
			Debug.Log("Score Coin");
			Destroy(col.gameObject);
			levelSettings.SendMessage("AddScore", 100);
			levelSettings.SendMessage("AddCoins", 1);
			soundManager.SendMessage("PlaySound", "Coin");
		}
		if (col.gameObject.tag == "Star")
		{
			Debug.Log("Shield Power Up Enabled");

			shield.SendMessage("EnableShield");
			Destroy(col.gameObject);
			soundManager.SendMessage("PlaySound", "Powerup");
		}
		if (col.gameObject.tag == "Double")
		{
			Debug.Log ("Score Doubled");
			levelSettings.SendMessage("DoubleScore");
			Destroy(col.gameObject);
			soundManager.SendMessage("PlaySound", "Powerup");
		}

	}
}
