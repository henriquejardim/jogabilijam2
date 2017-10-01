using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRenderer
	: MonoBehaviour {

	public NumberRenderer maxScore;
	public NumberRenderer score;

	// Use this for initialization
	void Start () {
	}

	public void SetScore(int newScore){
		score.RenderNumber (newScore);
	}

	public void SetMaxScore(int newMaxScore){
		maxScore.RenderNumber (newMaxScore);
	}

}
