using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRenderer
	: MonoBehaviour {

	public NumberRenderer maxScore;
	public NumberRenderer score;

	// Use this for initialization
	void Start () {
		score.RenderNumber (0);
		maxScore.RenderNumber (0);
	}

	void SetScore(int newScore){
		score.RenderNumber (newScore);
	}

	void SetMaxScore(int newMaxScore){
		score.RenderNumber (newMaxScore);
	}

}
