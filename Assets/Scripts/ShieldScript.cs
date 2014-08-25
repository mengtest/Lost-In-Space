using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {
	public bool shieldEnabled;
	SpriteRenderer spriteRenderer;
	CircleCollider2D circle;
	public int shieldTimerMax;
	int shieldTimer;
	GameObject shieldIndicator;
	GameObject levelSettings;
	GameObject soundManager;
	// Use this for initialization
	void Start () {
		shieldEnabled = false;
		spriteRenderer = GetComponent<SpriteRenderer>();
		circle = GetComponent<CircleCollider2D>();
		shieldTimer = shieldTimerMax;
		shieldIndicator = GameObject.Find("ActiveShield");
		levelSettings = GameObject.Find("Level Settings");
		soundManager = GameObject.Find ("SoundManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (shieldTimer <= 0)
		{
			shieldEnabled = false;
			shieldTimer = shieldTimerMax;
		}

		if (shieldEnabled == true)
		{
			spriteRenderer.enabled = true;
			circle.enabled = true;
			shieldTimer = shieldTimer - 1;
			//Debug.Log (shieldTimer);
			shieldIndicator.SendMessage("Activate");
			ShieldFlicker();
		}

		if (shieldEnabled == false)
		{
			spriteRenderer.enabled = false;
			circle.enabled = false;
			shieldIndicator.SendMessage("Deactivate");
		}
	}

	void OnTriggerEnter2D (Collider2D col){

		if (shieldEnabled == true)
		{
			if (col.gameObject.tag == "Asteroid")
			{
				Destroy(col.gameObject);
				levelSettings.SendMessage("AddScore",50);
				soundManager.SendMessage("PlaySound", "Explosion");
			}
		}
	}

	void EnableShield()
	{
		shieldEnabled = true;
		shieldTimer = shieldTimerMax;
	}

	void ShieldFlicker()
	{
		//The flicker script for when the powerup is running out. 
		if (shieldTimer <=100)
		{
			shieldIndicator.SendMessage("Deactivate");
		}
		if (shieldTimer <=90)
		{
			shieldIndicator.SendMessage("Activate");
		}
		if (shieldTimer <=80)
		{
			shieldIndicator.SendMessage("Deactivate");
		}
		if (shieldTimer <=70)
		{
			shieldIndicator.SendMessage("Activate");
		}
		if (shieldTimer <=60)
		{
			shieldIndicator.SendMessage("Deactivate");
		}
		if (shieldTimer <=50)
		{
			shieldIndicator.SendMessage("Activate");
		}
		if (shieldTimer <=40)
		{
			shieldIndicator.SendMessage("Deactivate");
		}
		if (shieldTimer <=30)
		{
			shieldIndicator.SendMessage("Activate");
		}
		if (shieldTimer <=20)
		{
			shieldIndicator.SendMessage("Deactivate");
		}
		if (shieldTimer <=10)
		{
			shieldIndicator.SendMessage("Activate");
		}

	}
}
