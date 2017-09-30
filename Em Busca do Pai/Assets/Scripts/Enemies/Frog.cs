using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

	void OnSceneGUI ()
	{				
		// Choose a Color
		Handles.color = Color.red;

		// replace "SpawnZone" with the class of your Script on a GameObject
		// your Class has to have a radius
		Handles.DrawWireDisc (transform.position, Vector3.forward, agressiveRadius);
	}

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log (other.tag);
		if (other.CompareTag ("PathTrigger")) {
			FindPlayer ();
		}
	}

	bool FindPlayer(){
		player = GameObject.FindWithTag ("Player");
		playerFound = player != null;

		return playerFound;
	}
		
	public void DestroyMe() { Debug.Log ("FROG BOOM"); Destroy(gameObject); }
		
}
