using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour {

	private TextMesh textMesh;
	private GameObject trail;
	bool canDrag = true;
//	public GameObject crate;



	// Subscribe to events
	void OnEnable(){
		EasyTouch.On_SwipeStart += On_SwipeStart;
		EasyTouch.On_Swipe += On_Swipe;
		EasyTouch.On_SwipeEnd += On_SwipeEnd;		
	}

	void OnDisable(){
		UnsubscribeEvent();
		
	}
	
	void OnDestroy(){
		UnsubscribeEvent();
	}
	
	void UnsubscribeEvent(){
		EasyTouch.On_SwipeStart -= On_SwipeStart;
		EasyTouch.On_Swipe -= On_Swipe;
		EasyTouch.On_SwipeEnd -= On_SwipeEnd;	
	}
	
	void Start(){
		//textMesh = GameObject.Find("LastSwipeText").transform.gameObject.GetComponent("TextMesh") as TextMesh;
	}

	void StopDrag()
	{
		canDrag = false;
	}
	void AllowDrag()
	{
		canDrag = true;
	}
	
	// At the swipe beginning 
	private void On_SwipeStart( Gesture gesture){
		
		// Only for the first finger
		if (gesture.fingerIndex==0 && trail==null){ 
			
			// the world coordinate from touch for z=5
			Vector3 position = gesture.GetTouchToWordlPoint(5);
			trail = Instantiate( Resources.Load("Trail"),position,Quaternion.identity) as GameObject;
			//Debug.Log (gesture.swipe.ToString());
		}
	}
	
	// During the swipe
	private void On_Swipe(Gesture gesture){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (trail!=null){
			
			// the world coordinate from touch for z=5
			Vector3 position = gesture.GetTouchToWordlPoint(5);
			trail.transform.position = position;
			if (gesture.swipe.ToString() == "Down" && canDrag)
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, -10f);
			}
			if (gesture.swipe.ToString() == "Up" && canDrag)
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, -10f);
			}
//			Debug.Log ("MID " + gesture.swipe.ToString());

		}
	}
	
	// At the swipe end 
	private void On_SwipeEnd(Gesture gesture){
		
		if (trail!=null){
			Destroy(trail);
			
			// Get the swipe angle
			float angles = gesture.GetSwipeOrDragAngle();
//			Debug.Log (" END + " + gesture.swipe.ToString());
//			textMesh.text = "Last swipe : " + gesture.swipe.ToString() + " /  vector : " + gesture.swipeVector.normalized + " / angle : " + angles.ToString("f2") + " / " + gesture.deltaPosition.x.ToString("f5");
		}
				
	}
}
