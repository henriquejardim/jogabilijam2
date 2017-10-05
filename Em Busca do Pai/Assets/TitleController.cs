using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {


	public AudioSource audioSource;
	public Animator animator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1"))
			StartGame ();
			
	}

	void StartGame(){
		audioSource.Play ();
		animator.Play ("TitleFlick");
		StartCoroutine (ChangeScreen ());
	}


	IEnumerator ChangeScreen(){
		yield return new WaitWhile (() => audioSource.isPlaying);
		SceneManager.LoadScene ("Begin");
	}
}
