using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {
	public GameObject[] crate;
	int crateID;
	//public GameObject preview;
	Vector3 objScale;
	float x, y;
	int i;
	//public Sprite crateSprite, stoneSprite, iceSprite;
	int score;
	float timer;
	public bool canShoot; 
	Sprite nextSprite;

	GameObject levelSettings;
	// Use this for initialization
	void Start () {
		//RandomXY();
		//objScale = new Vector3(x,y,0f);
		//SendPreview();

		/*if (PlayerPrefs.GetString("CurrentMaterial") == "Crate")
		{
			ChangeSprite(gameObject, crateSprite);
		}
		if (PlayerPrefs.GetString("CurrentMaterial") == "Ice")
		{
			ChangeSprite(gameObject, iceSprite);
		}
		if (PlayerPrefs.GetString("CurrentMaterial") == "Stone")
		{
			ChangeSprite(gameObject, stoneSprite);
		}*/
		i=0;
		//timer = 0;
		canShoot = true;
		crateID = 0;
		levelSettings = GameObject.FindGameObjectWithTag("LevelSettings");
	}
	
	// Update is called once per frame
	void Update () {
		//nextSprite = crate[crateID].gameObject.GetComponent<SpriteRenderer>();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonUp(2))
		{
			Shoot ();
		}
		if (canShoot == false && crateID < crate.Length)
		{
			//gameObject.SetActive(false);
			timer--;
			if (timer <= 0)
			{
				canShoot = true;
			}
		} 
		if (canShoot == true)
		{
			//gameObject.SetActive(true);
			timer = 60f * .55f;
			if (crateID < crate.Length)
			{
				ChangeSprite(gameObject, crate[crateID]);
			}
		}

		if (crateID > crate.Length)
		{
			//Derp Game Is Over
			//Set a quick timer for scoring a the level
			levelSettings.GetComponent<LevelSettings>().GameOver();

		}
	}
	void Shoot()
	{
		if (canShoot == true)
		{
			i++; //Incrimenting the name of the object.
			GameObject newCrate = (GameObject)Instantiate(crate[crateID], new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, 1f), Quaternion.identity);
			newCrate.name = ("Crate " + i);
//			GA.API.Design.NewEvent(PlayerPrefs.GetString("CurrentMaterial") + "Created");
			PlayerPrefs.SetInt("Total" + (PlayerPrefs.GetString ("CurrentMaterial")), PlayerPrefs.GetInt("Total" + (PlayerPrefs.GetString ("CurrentMaterial"))) + 1);
			canShoot = false;
				crateID += 1;
		} 
	}

	void ChangeSprite(GameObject go, GameObject nS)
	{
		SpriteRenderer spriteRender = go.GetComponent<SpriteRenderer>();
		SpriteRenderer newSprite = nS.GetComponent<SpriteRenderer>();
		spriteRender.sprite = newSprite.sprite;
	}
}
