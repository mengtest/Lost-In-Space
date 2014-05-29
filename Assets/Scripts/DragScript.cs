using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {
	bool firstClick = false;
	int clickTimer = 0;
	public GameObject camera;
	SpriteRenderer sprite;
	GameObject mainCam;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		mainCam = GameObject.FindGameObjectWithTag("MainCamera");
		TimeClick();

	}

	void OnMouseDrag()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		gameObject.transform.position = new Vector2(ray.origin.x, gameObject.transform.position.y);
		//mainCam.SendMessage("StopDrag");
	}

	void OnMouseDown()
	{

		if (Input.GetMouseButtonDown(0) && firstClick == false)
		{
			firstClick = true;
			//Debug.Log ("FIRST CLICK");
			
		}
		else if (Input.GetMouseButtonDown(0) && firstClick == true)
		{
			//Debug.Log ("DOUBLE CLICKIN");
			gameObject.SendMessage("Shoot");
			firstClick = false;
		}
		//mainCam.SendMessage("StopDrag");
	}
	void OnMouseUp()
	{
		//mainCam.SendMessage("AllowDrag");
	}

	void TimeClick()
	{ 
		if (firstClick == true)
		{
			//Debug.Log ("TIMER STARTED");
			clickTimer++;
//			Debug.Log (clickTimer);
			if (clickTimer >= 20)
			{
				//Debug.Log ("FIRST CLICK EXPIRED");
				firstClick = false;
				clickTimer = 0;
			}
		}

	}
}
