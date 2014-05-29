using UnityEngine;
using System.Collections;

public class DeathBoxScript : MonoBehaviour {
	GameObject levelSettings;
	// Use this for initialization
	void Start () {
		levelSettings = GameObject.Find("Level Settings");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		Destroy(col.gameObject);

	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Asteroid");
		{
			if (levelSettings.GetComponent<LevelSettings>().gameOver == false)
			{
				levelSettings.SendMessage("AddScore", 25);
			}
		}

		Destroy(col.gameObject);
	}

	void OnTriggerExit2D(Collider2D col) {
		Destroy(col.gameObject);
		
	}
	
	void OnCollisionExit2D (Collision2D col) {
		Destroy(col.gameObject);
	}

	void OnTriggerStay2D(Collider2D col) {
		Destroy(col.gameObject);
		
	}
	
	void OnCollisionStay2D (Collision2D col) {
		Destroy(col.gameObject);
	}
}
