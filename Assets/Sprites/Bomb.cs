using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon
{
	public int radius = 8;
	public bool isActive = false;


	void Update()
	{
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		var player = coll.gameObject.GetComponent<Players> ();

		if (player == null && !isActive) {
			
			Explode ();
		}
	}

	public override void GetPickedUp(Players player)
	{

		if (isActive) 
		{
			return;
		}
		isActive = true;
		base.GetPickedUp (player);
	}

	public override void Attack()
	{
		transform.parent = null;

		rigidBody2D.velocity = new Vector2 (5, 0);

		collider2D.enabled = true;
		rigidBody2D.isKinematic = false;
	}

	public void Explode()
	{
		var enermies = FindObjectsOfType<enermy> ();
		gameObject.SetActive (false);

		foreach (var e in enermies)
		{
			if (Vector3.Distance (this.transform.position, e.transform.position) < radius)
			{

				e.gameObject.SetActive (false);
			}
		}
	}
}
