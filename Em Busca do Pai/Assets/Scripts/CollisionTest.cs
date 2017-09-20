using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("TESTE TRIGGER");
	
	}
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("TESTE COLLISION");


	}
}
