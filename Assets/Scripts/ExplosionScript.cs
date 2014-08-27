using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public GameObject explosionEffect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void TriggerExplosion() {
		Instantiate(explosionEffect, new Vector3(gameObject.transform.position.x, 
		                                         gameObject.transform.position.y), 
		            								new Quaternion(0f,0f,0f,0f));
	}
}
