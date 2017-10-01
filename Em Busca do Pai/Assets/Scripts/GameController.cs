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

	//public UIController ui = UIController.instance;
	public UIController ui;

	public enum GameState {
		Begining,
		Playing,
		GameOver,
		Ending
	}

	private GameState state;



	private bool changingScene = false;

	public static class SceneNames
	{
		public static string Stage1 = "Stage1";
		public static string GameOver = "GameOver";
		public static string GameWin = "GameWin";
	}

	public void SetGameState(GameState newState){
		state = newState;
		Reset ();
	}

	void Update(){
		if ((state == GameState.GameOver || state == GameState.Begining || state == GameState.Ending) && Input.GetButtonDown ("Fire1") && !changingScene)
			StartCoroutine (LoadScene (SceneNames.Stage1));


		if (Input.GetButtonDown("End"))
			Application.Quit();

		Debug.Log ("UPDATE GAMECONTROLLER");
		Debug.Log (ui.GetInstanceID());

	}

	public void LoadScene2(string name){
		StartCoroutine (LoadScene (name));
	}

	IEnumerator LoadScene(string name){
		changingScene = true;
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene (name);
		Reset ();
		state = GameState.Playing;
		changingScene = false;
	}

	/*
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
	}*/

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
		Debug.Log (score);
		Debug.Log (maxScore);
		if (score > maxScore)
			PlayerPrefs.SetInt("HighScore", score);

		SceneManager.LoadScene (SceneNames.GameOver);
		state = GameState.GameOver;
	}


	public void Reset(){
		ui = GameObject.FindWithTag ("UIController").GetComponent<UIController> ();
		ui.Reset ();

		lifes = 3;
		score = 0;
		maxScore = 0;
		maxScore = PlayerPrefs.GetInt("HighScore", 0);


		if ( maxScore <= 0 )
			PlayerPrefs.SetInt("HighScore", maxScore);

		Debug.Log (maxScore);
		ui.SetScore (score);
		ui.SetMaxScore (maxScore);
		ui.SetLifes (lifes);


	}

	public void EndGame(){
		Debug.Log (score);
		Debug.Log (maxScore);
		if (score > maxScore)
			PlayerPrefs.SetInt("HighScore", score);

		SceneManager.LoadScene (SceneNames.GameWin);
		state = GameState.Ending;
	}

	public void AddScore(int scoreToAdd){
		score += scoreToAdd;
		ui.SetScore (score);
	}

	
}
