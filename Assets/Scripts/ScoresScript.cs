using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresScript : MonoBehaviour {


	Text TextScores;
	public GameObject awesomeGO;
	private int scores;


	public int Scores
	{
		get
		{
			return this.scores;
		}
		set
		{
			this.scores = value;
			UpdateScores ();
		}
	}


	// Use this for initialization
	void Start () {

		TextScores = GetComponent<Text> ();

	}

	//Function to update the scores

	void UpdateScores()
	{
		
		string scoreStr = string.Format ("{0:000000}", scores);
		TextScores.text = scoreStr;


//		Why is this not working
		if (scores == 400 || scores == 500) {
			awesomeGO.SetActive (true);
		} else {
			awesomeGO.SetActive (false);
		}
	}

}
