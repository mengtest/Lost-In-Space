using UnityEngine;
using System.Collections;

public class OutlineCheckCollision : MonoBehaviour {
	GameObject levelSettings;
	public bool isColliding;
	public int id;
	// Use this for initialization
	void Start () {
		isColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col) {

		if (col.gameObject.tag == "Crate")
		{
			isColliding = true;
		}
		else 
		{
			isColliding = false;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		isColliding = false;
	}


	void SetID(int i)
	{
		id = i;
	}
}
