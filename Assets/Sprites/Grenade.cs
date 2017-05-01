using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Throwable 
{
	public int radius = 8;

	void OnCollisionEnter2D(Collision2D coll)
	{

		var player = coll.gameObject.GetComponent<Players> ();

		if (player == null && isActive) 
		{

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
			StartCoroutine(stun (e));
			}
		}

 		collider2D.enabled = false; 
		GetComponent<SpriteRenderer> ();
	}

	IEnumerator stun(enermy e)
	{
		var renderer = e.GetComponent<SpriteRenderer> ();

		e.enabled = false;
		renderer.color = new Color(1,1,1, .4f);

		yield return new WaitForSeconds(5);

		e.enabled = true; 
		renderer.color = new Color(1,1,1,1);
	}
}
	





