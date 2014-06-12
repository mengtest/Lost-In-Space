using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour {
	SpriteRenderer spriteRender;
	BoxCollider2D collider;
	//public Sprite crate, stone, ice;
	public PhysicsMaterial2D material;
	public float gravity = 1f, mass = 10f;
	public int score = 250;
	bool canScore = false;
	//GameObject boat;

	// Use this for initialization
	void Start () {

		spriteRender = GetComponent<SpriteRenderer>();
		//gameObject.AddComponent<BoxCollider2D>(); //Add a collider for proper scaling of collisions
		//collider = GetComponent<BoxCollider2D>();
		ChangePhysics(material);
		ChangeGravity(gravity);
		SetMass(mass);
		gameObject.tag = "Crate";


	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		if (col.gameObject.tag == "Death")
		{
			PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") - score);
			Destroy(gameObject);
		}
	}


	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Outline")
		{
			canScore = true;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		//gameObject.transform.parent = null;
	}

	void ChangeSprite(Sprite sprite)
	{
		spriteRender.sprite = sprite;
	}
	void ChangePhysics(PhysicsMaterial2D mat2D)
	{
		//collider.sharedMaterial = mat2D;
	}
	void ChangeGravity(float gravity)
	{
		rigidbody2D.gravityScale = gravity;
	}
	void SetMass(float modifier)
	{
		gameObject.rigidbody2D.mass = ((spriteRender.bounds.size.x * spriteRender.bounds.size.y) / modifier);
	//	Debug.Log(gameObject.rigidbody2D.mass);
	}
	void Score()
	{
		if (canScore)
		{
			Debug.Log (gameObject.name + "Scored");
			PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") + score);
			if (PlayerPrefs.GetInt("CurrentScore") > PlayerPrefs.GetInt("HighScore"))
			{
				PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("CurrentScore"));
			}
		}
	}
}