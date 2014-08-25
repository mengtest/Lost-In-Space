using UnityEngine;
using System.Collections;

public class ActivePowerUps : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Used in the flicker scripts in a powerup's script. Will show or hide the icon on the screen. 
	void Activate() {
		spriteRenderer.enabled = true;
	}

	void Deactivate() {
		spriteRenderer.enabled = false;
	}
}
