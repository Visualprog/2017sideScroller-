using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

	protected new Rigidbody2D rigidBody2D;
	protected new Collider2D collider2D;

	void Start()
	{
		rigidBody2D = GetComponent<Rigidbody2D> ();
		collider2D = GetComponent<Collider2D> ();
	} 

	
	public virtual void Attack()
	{
		
	}
	public virtual void GetPickedUp(Players player)
	{
		transform.parent = player.transform; 

		collider2D.enabled = false;
		rigidBody2D.isKinematic = true;
		rigidBody2D.velocity = new Vector3 ();
	}
}

