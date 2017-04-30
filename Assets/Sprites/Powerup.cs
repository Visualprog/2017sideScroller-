using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	
	private float timeStarted = 0;
	Players player;

	public float poweruptime = 3;


	void OnCollisionEnter2D(Collision2D coll)
	{
		player = coll.gameObject.GetComponent<Players> ();
		if (player != null) 
		{
			player.canFly = true;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;

			timeStarted = Time.time;

			player.Powerup ();
		}
	}

	void Update()
	{
		if (timeStarted != 0 && timeStarted + poweruptime < Time.time) 
		{
			timeStarted = 0;
			player.canFly = false;
		}
	}
}

