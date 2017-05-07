using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Weapon {
	
	public bool isActive = false;


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

		rigidbody2D.velocity = new Vector2 (15, 0);

		collider2D.enabled = true;
		rigidbody2D.isKinematic = false;
	}
}
