﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	private int _Lives = 3;
	private int _Points;
	private int _Potions;

	public Text livesValue;
	public Text pointsValue;
	public Text potionsText;

	public GameObject DoGameOverSign;

	public void SetLives (int newValue){
		_Lives = newValue;
		Debug.Log ("Lives now equals:" + _Lives);
		livesValue.text = _Lives.ToString ();

		if (_Lives == 0) {
			DoGameOver ();
		}
	}
		
	public void DoGameOver()
	{
		DoGameOverSign.SetActive (true);
	}

	public int GetLives (){
		
		return _Lives;
	}

	public void SetPoints(int newValue)
	{
		_Points = newValue;
		pointsValue.text = _Points.ToString ();
	}

	public void PotionWasPickedUp()
	{
		_Potions = _Potions + 1;
		potionsText.text = _Potions.ToString();

	}

	public int GetPoints(){
		return _Points;
	}


}



