using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour {

	// Use this for initialization
	public void OnCollisionEnter2D(Collision2D collision)
	{
		gameObject.SetActive (false);
		if (collision.gameObject.GetComponent<Players> () != null) {
			FindObjectOfType<GM>().PotionWasPickedUp();
		}
	}
}

