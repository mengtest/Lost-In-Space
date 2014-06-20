using UnityEngine;
using System.Collections;

public class ClusterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Applied to cluster prefab. Will destroy when it has zero children / zero stars. 
		if (gameObject.transform.childCount == 0)
		{
			Destroy(gameObject);
		}
	}
}
