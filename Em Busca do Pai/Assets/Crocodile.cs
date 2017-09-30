using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : MonoBehaviour {

	public float threatRadius = 10f;
	public float damage = 4f;
	public float idleDamage = 1f;

	private GameObject player;
	private Enemy enemy;
	private Animator animator;

	private enum CrocState {
		Idle,
		Agressive
	}


	private CrocState state;
	private bool playerFound;
	private bool attacking;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Enemy> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerFound) {
			var distance = Vector2.Distance (transform.position, player.transform.position);
			if (distance <= threatRadius)
				state = CrocState.Agressive;
		}

		switch (state)
		{
			case CrocState.Agressive:
				if (!attacking) {
					attacking = true;
					animator.SetTrigger ("Attack");
				}
				break;
		default:
			break;
		}
	}

	void OnEndAttack(){
		attacking = false;
		state = CrocState.Idle;
		damage = idleDamage;

	}

	void OnBeginAttack(){
		damage *= 4f;
	}

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log (other.tag);
		if (other.CompareTag ("PathTrigger")) {
			FindPlayer ();
		}

		if (other.gameObject.CompareTag("Player")){
			var target = other.gameObject.GetComponent<Target>();
			target.TakeDamage(state == CrocState.Idle ? idleDamage : damage);
		}
			
	}

	bool FindPlayer(){
		player = GameObject.FindWithTag ("Player");
		playerFound = player != null;

		return playerFound;
	}
		
}
