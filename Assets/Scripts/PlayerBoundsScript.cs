using UnityEngine;

using System.Collections;

public class PlayerBoundsScript : MonoBehaviour {
	public float bounds = 3.5f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x < bounds * -1f)
		{
			gameObject.transform.position = new Vector2(bounds * -1f, gameObject.transform.position.y);
		}
		if (gameObject.transform.position.x > bounds)
		{
			gameObject.transform.position = new Vector2(bounds, gameObject.transform.position.y);
		}

	}
}
