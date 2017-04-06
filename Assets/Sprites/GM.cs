using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	private int _Lives = 3;
	public int points;

	public Text livesValue;
	public Text pointsValue;

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
}


