using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {


	public GameObject Vida1;
	public GameObject Vida2;
	public GameObject Vida3;

	public ScoreRenderer scoreRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SetScore(int score){
		scoreRenderer.SetScore (score);
	}


	public void SetMaxScore(int maxScore){
		scoreRenderer.SetMaxScore (maxScore);
	}

	public void SetLifes(int lifes){
		switch (lifes){
		case 0: 
			Vida1.SetActive (false);
			Vida2.SetActive (false);
			Vida3.SetActive (false);
			break;
		case 1: 
			Vida1.SetActive (true);
			Vida2.SetActive (false);
			Vida3.SetActive (false);
			break;
		case 2:
			Vida1.SetActive (true);
			Vida2.SetActive (true);
			Vida3.SetActive (false);
			break;
		case 3:
			Vida1.SetActive (true);
			Vida2.SetActive (true);
			Vida3.SetActive (true);
			break;
		}

	}
}
