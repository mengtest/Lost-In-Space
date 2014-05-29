using UnityEngine;
using System.Collections;

public class PlayerLockYScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, -1.5f, 0f);
	}
}
