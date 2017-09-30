using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {


	public GameObject Vida1;
	public GameObject Vida2;
	public GameObject Vida3;

	public ScoreRenderer scoreRenderer;

	public static UIController instance;

	void Awake(){
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		Reset ();
	}


	public void Reset(){
		Vida1 = GameObject.FindGameObjectWithTag ("Vida1");
		Vida2 = GameObject.FindGameObjectWithTag ("Vida2");
		Vida3 = GameObject.FindGameObjectWithTag ("Vida3");
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
