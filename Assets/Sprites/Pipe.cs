using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pipe : MonoBehaviour {
	Players player;

	private Animator anim;
	public bool isGround = false;
	public GameObject Platform;
	public float moveSpeed;
	private Transform myTransform; 
	public Transform[] groundCheck; 
	public Transform headCheck; 

	void Start()
	{
		headCheck = transform.FindChild ("HeadCheck");
		if (groundCheck == null || groundCheck.Length < 2) 
		{
			groundCheck = new Transform[2];
			groundCheck [0] = transform.GetChild (0);
			groundCheck [1] = transform.GetChild (1);
		}
	}

	void Update()
	{

		player = FindObjectOfType<Players> ();

			if (player != null && Input.GetKeyDown("down"))
			{
				Debug.Log ("went down pipe");
				StartCoroutine(downpipe ());
			}
			isGround = Physics2D.Linecast (myTransform.position, groundCheck [0].position, 1 << LayerMask.NameToLayer ("Ground"))
			|| Physics2D.Linecast (myTransform.position, groundCheck [1].position, 1 << LayerMask.NameToLayer ("Ground"));
		}

		IEnumerator downpipe()
		{
			this.GetComponent<Collider2D> ().enabled = false;
			player.enabled = false;

			yield return new WaitForSeconds (.5f);

			player.transform.position = new Vector3 (2.61f, -1.88f);
			player.enabled = true;
		}

	}
	
