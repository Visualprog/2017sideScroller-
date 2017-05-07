using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Throwable {

	public void OnCollisionEnter2D(Collision2D collision)
	{
		gameObject.SetActive (false);
		if (collision.gameObject.GetComponent<Players> () != null) {
			FindObjectOfType<GM>().PotionWasPickedUp();
		}
	}
}


