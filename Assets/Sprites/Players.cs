﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {
	public int health = 100;
	public float speed = 5;
	public float jumpspeed = 5;
	public float deadZone = -3;

	new Rigidbody2D rigidbody; 
	GM _GM; 

	// Use this for initialization
	void Start () {
		
		rigidbody = GetComponent<Rigidbody2D> ();
		_GM = FindObjectOfType<GM> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//apply movement 

		float x = Input.GetAxisRaw ("Horizontal");
		//rigidbody.velocity = new Vector2 (x * speed, 0);
		Vector2 v = rigidbody.velocity;
		v.x = x * speed; 

		if (Input.GetButtonDown ("Jump")) {
			v.y = jumpspeed;
		}

		rigidbody.velocity = v; 

		//float for out 

		if (transform.position.y < deadZone) 
		{
			Debug.Log("You're Out");
			
		}


	}
	public void GetOut(){
		_GM.SetLives (_GM.lives - 1); 
	}
}