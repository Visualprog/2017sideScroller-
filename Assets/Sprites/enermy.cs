using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermy : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D coll) 
	{
	
		var player = coll.gameObject.GetComponent<Players> ();
		if (player != null) {
			player.GetOut ();
		}
	}
}

