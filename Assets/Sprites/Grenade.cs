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
		var animator = e.GetComponent<Animator > ();

		e.enabled = false;
		if (animator != null) {
			animator.enabled = false;
		}

		for (int i = 0; i < 11; i++) {
			renderer.color = new Color (1, 1, 1, 1 - (i * .2f));
			yield return new WaitForSeconds(.5f);
			
		}
			
		yield return new WaitForSeconds(5);

		if (animator != null) {
			animator.enabled = true;
		}

		e.enabled = true;

		renderer.color = new Color(1,1,1, 1*0.2f);
	}
}
	





