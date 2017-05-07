using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

	protected new Rigidbody2D rigidbody2D;
	protected new Collider2D collider2D;

	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D> ();
		collider2D = GetComponent<Collider2D> ();
	} 

	
	public virtual void Attack()
	{
		
	}
	public virtual void GetPickedUp(Players player)
	{
		player.currentweapon = this;
		transform.parent = player.transform; 
	
		transform.localPosition = new Vector3 (0.5f, 0.5f);
		transform.localScale = new Vector3 (.5f, .5f);

		rigidbody2D.velocity = new Vector2 ();
		rigidbody2D.isKinematic = true;
		collider2D.enabled = false;
	}
}

