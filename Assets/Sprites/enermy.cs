using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermy : MonoBehaviour 
{
	public int healthlife;

	public void death()
	{
		healthlife = healthlife - 1;

		if (healthlife == 0) {
			gameObject.SetActive (true);
		}
	}
			
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (!enabled) {
			return;
		}
	
		var player = coll.gameObject.GetComponent<Players> ();
		if (player != null) {
			player.GetOut ();
		}
	}
}

