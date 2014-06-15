using UnityEngine;
using System.Collections;

public class ClusterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.childCount == 0)
		{
			Debug.Log("Destroyed Cluster");
			Destroy(gameObject);
		}
	}
}
