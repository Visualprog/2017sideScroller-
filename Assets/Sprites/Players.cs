using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {
	public int health = 100;
	public float speed = 5;
	public float jumpspeed = 5;
	public float deadZone = -15;
	public bool  canFly = false;

	public Weapon currentweapon;

	new Rigidbody2D rigidbody; 
	GM _GM; 
	private Vector3 startingPosition; 
	 
	private Animator anim;
	public bool air; 
	private SpriteRenderer sr; 

	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
		rigidbody = GetComponent<Rigidbody2D> ();
		_GM = FindObjectOfType<GM> ();

		anim = GetComponent<Animator> ();
		air = true;
		sr = GetComponent<SpriteRenderer> ();
	}
	
	
	// Update is called once per frame
	void FixedUpdate () {
		//apply movement 

		float x = Input.GetAxisRaw ("Horizontal");
		//rigidbody.velocity = new Vector2 (x * speed, 0);
		Vector2 v = rigidbody.velocity;
		v.x = x * speed; 

		if (v.x != 0){
			anim.SetBool("Running", true);
		}
		else{
			anim.SetBool("Running", false);

	
		}

		if (v.x > 0) {
			sr.flipX = false;
		} else {
			if (v.x < 0)
				sr.flipX = true;
		}
		
		
		if (Input.GetButtonDown ("Jump") && (v.y == 0 || canFly)) {
			v.y = jumpspeed;
		}
			
		if (Input.GetButtonDown ("Fire1") && currentweapon == null)
			{
				currentweapon.Attack();
			}
			
		if (air) {
			anim.SetBool ("Air", true);
		} else {
			anim.SetBool ("Air", false);
		}

		rigidbody.velocity = v; 

		//float for out 

		if (transform.position.y < deadZone) 
		{
			Debug.Log ("Current Position" + transform.position.y + "is lower than " + deadZone);
			GetOut ();
			
		}


	}
	public void GetOut(){
		_GM.SetLives (_GM.GetLives() - 1); 
		transform.position = startingPosition; 
		Debug.Log("You're Out");
	}

	public void Powerup(){
		anim.SetTrigger ("powerup");
	}

		
	void OnCollisionEnter2D(Collision2D coll)
	{
		air = false;
		var weapon = coll.gameObject.GetComponent<Weapon> ();
		if (weapon != null) {
			weapon.GetPickedUp (this);
			currentweapon = weapon;
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		air = true;
	}

}
