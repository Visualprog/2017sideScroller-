using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour 
{
	public int radius = 8;
	public bool isActive = false;
	private new Rigidbody2D rigidBody;
	private new Collider2D collider;

	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();
	} 

	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Explode();
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{

		var player = coll.gameObject.GetComponent<Players> ();

		if (player != null && !isActive) 
		{
			
			GetPickedUp (player);
		}
		if (isActive && player == null)
		{
			
		}
	}

	public void Throw()
	{
		
	}

	public void GetPickedUp(Players player)
	{
		isActive = true;
		collider.enabled = false;
		rigidBody.isKinematic = true;
		rigidBody.velocity = new Vector3 ();

		transform.parent = player.transform;

		transform.localScale = new Vector3 (0.04f, 0.04f);
		transform.localPosition = new Vector3 (0.2f, 0.2f);

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
