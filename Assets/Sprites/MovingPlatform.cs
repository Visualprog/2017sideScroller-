using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	new Rigidbody2D rigidbody2D;
	float startingX;
	public float speed = 0.3f;
	public float distance = 3;

	// Use this for initialization
	void Start ()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		startingX = transform.position.x;

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (transform.position.x < startingX - distance) {
			speed = -speed;
		}
		if (transform.position.x > startingX) {
			speed = -speed;

		}

		var v = rigidbody2D.velocity;
		v.x = speed;
		rigidbody2D.velocity = v;
	}

}


	
