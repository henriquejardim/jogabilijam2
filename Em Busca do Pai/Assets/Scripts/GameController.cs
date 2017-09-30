using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public  class GameController : MonoBehaviour {

	public static GameController instance;

	public static int lifes = 3;

	public static int score = 0;
	public static int maxScore = 0;

	public UIController ui;


	public static class SceneNames
	{
		public static string Stage1 = "Stage1";
		public static string GameOver = "GameOver";

	}

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

	public void RemoveLife(){
		lifes -= 1;
		ui.SetLifes (lifes);

		if (lifes < 0)
			GameOver ();

	}

	public void GameOver(){
		if (score > maxScore)
			PlayerPrefs.SetInt("High Score", score);

		SceneManager.LoadScene (SceneNames.GameOver);
	}


	public void Reset(){
		lifes = 3;
		score = 0;
		maxScore = 0;
		maxScore = PlayerPrefs.GetInt("High Score");

		ui.SetScore (score);
		ui.SetMaxScore (score);
		ui.SetLifes (lifes);

	}

	public void AddScore(int scoreToAdd){
		score += scoreToAdd;
		ui.SetScore (score);
	}

	
}
