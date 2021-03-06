﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Throwable
{
	public int radius = 5;

	void OnCollisionEnter2D(Collision2D coll)
	{

		var player = coll.gameObject.GetComponent<Players> ();

		if (player == null && isActive) {
			
			Explode ();
		}
	}
		

	public void Explode()
	{
		var enermies = FindObjectsOfType<enermy> ();
		gameObject.SetActive (false);

		foreach (var e in enermies)
		{
			if (Vector3.Distance (this.transform.position, e.transform.position) < radius)
			{

				e.death ();
			}
		}
	}
}
