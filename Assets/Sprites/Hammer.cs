using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Throwable {
		public float radius = 11;

		void OnCollisionEnter2D(Collision2D coll)
		{

			var player = coll.gameObject.GetComponent<Players> ();

			if (player  != null ) 
			{
			gameObject.SetActive (false);
			FindObjectOfType<GM> ().SetLives (FindObjectOfType<GM> ().GetLives () + 1);
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

					e.gameObject.SetActive (false);
				}
			}
		}
	}





