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

	void Activate() {
		spriteRenderer.enabled = true;
	}

	void Deactivate() {
		spriteRenderer.enabled = false;
	}
}
