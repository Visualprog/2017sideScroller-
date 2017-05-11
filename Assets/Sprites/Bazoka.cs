using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazoka : Weapon {

	public GameObject rocketprefab; 

	public override void Attack()
	{
		var rocket = Instantiate(rocketprefab);

		rocket.transform.position = this.transform.position;
		rocket.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0); 

		base.Attack();
	}
}
