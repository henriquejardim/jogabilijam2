using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {


	public GameObject Vida1;
	public GameObject Vida2;
	public GameObject Vida3;

	public ScoreRenderer scoreRenderer;

	public UIController instance;
	public GameObject lifeLostParticles;

	void Awake(){
		
	}
	
	// Use this for initialization
	void Start () {
		Reset ();
	}


	public void Reset(){
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (gameObject.GetInstanceID());
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
			var v1 = Instantiate (lifeLostParticles, Vida1.transform.position, Vida1.transform.rotation);
			Destroy (v1, 1f);
			break;
		case 1: 
			Vida1.SetActive (true);
			Vida2.SetActive (false);
			Vida3.SetActive (false);
			var v2 = Instantiate (lifeLostParticles, Vida2.transform.position, Vida2.transform.rotation);
			Destroy (v2, 1f);
			break;
		case 2:
			Vida1.SetActive (true);
			Vida2.SetActive (true);
			Vida3.SetActive (false);
			var v3 = Instantiate (lifeLostParticles, Vida3.transform.position, Vida3.transform.rotation);
			Destroy (v3, 1f);
			break;
		case 3:
			Vida1.SetActive (true);
			Vida2.SetActive (true);
			Vida3.SetActive (true);
			break;
		}

	}
}
