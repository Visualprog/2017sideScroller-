﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var player = collision.gameObject.GetComponent<Players> ();
		if (player != null) {
			player.canFly = true;
		}
	}

	private void OnCollisionExitr2D(Collision2D collision) {
		
		var player = collision.gameObject.GetComponent<Players> ();
		if (player != null) {
			player.canFly = true;
		}
}
}