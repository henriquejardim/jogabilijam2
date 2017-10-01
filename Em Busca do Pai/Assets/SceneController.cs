using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {


	public GameController gameController;
	public GameController.GameState state;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController> ();
		gameController.SetGameState (state);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
