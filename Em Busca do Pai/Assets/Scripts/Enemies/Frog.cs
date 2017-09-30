using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Frog : MonoBehaviour {

	public float agressiveRadius = 5f;

	private GameObject player;
	private Enemy enemy;
	private Animator animator;

	private enum FrogState {
		Idle,
		Agressive
	}


	private FrogState state;
	private bool playerFound;
	private bool exploding;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerFound) {
			var distance = Vector2.Distance (transform.position, player.transform.position);
			if (distance <= agressiveRadius)
				state = FrogState.Agressive;
		}

		switch (state)
		{
		case FrogState.Agressive:
			if (!exploding) {
				exploding = true;
				animator.SetTrigger ("Attack");
			}
			break;
		default:
			break;
		}
	}


	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log (other.tag);
		if (other.CompareTag ("PathTrigger")) {
			FindPlayer ();
		}

		if (other.gameObject.CompareTag("Player")){
			var target = other.gameObject.GetComponent<Target>();
			target.TakeDamage(1f);
		}
	}

	bool FindPlayer(){
		player = GameObject.FindWithTag ("Player");
		playerFound = player != null;

		return playerFound;
	}
		
	public void DestroyMe() { Debug.Log ("FROG BOOM"); Destroy(gameObject); }
		
}
