using UnityEngine;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {
	public AudioClip menuBlip;
	public AudioClip explosion;
	public AudioClip powerupPickup;
	public AudioClip coinPickup;

	public AudioClip menuMusic;
	public AudioClip gameMusic;

	AudioSource soundManager;
	// Use this for initialization
	void Start () {
		soundManager = gameObject.GetComponent<AudioSource>();
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlaySound(string clipString) {
		if (clipString == "Menu")
		{
			soundManager.clip = menuBlip;
		}
		else if (clipString == "Powerup")
		{
			soundManager.clip = powerupPickup;
		}
		else if (clipString == "Coin")
		{
			soundManager.clip = coinPickup;
		}
		else if (clipString == "Explosion")
		{
			soundManager.clip = explosion;
		}
		soundManager.Play();
	}
}
