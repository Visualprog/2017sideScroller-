﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
	public int value;
	void OnTriggerEnter2D(Collider2D coll) 
	{

		var player = coll.gameObject.GetComponent<Players> ();
		if (player != null) {
			gameObject.SetActive (false);
			FindObjectOfType<GM> ().SetPoints (FindObjectOfType<GM> ().GetPoints () + value);

		}
	}



}
