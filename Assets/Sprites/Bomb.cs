using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) 
	{

		var player = coll.gameObject.GetComponent<Players> ();
		gameObject.SetActive (false);
		if (player != null) {
			var enermies = FindObjectsOfType<enermy> ();
			foreach (var e in enermies) {
				if (Vector3.Distance (this.transform.position, e.transform.position) < 10) {
					e.gameObject.SetActive (false);
				}
			}
		}
	}
}
