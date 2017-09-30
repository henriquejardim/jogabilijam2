using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unspawn : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		 
		Destroy (other.gameObject, 1f);

	}
	void OnCollisionEnter2D(Collision2D other) {
		Destroy (other.gameObject, 1f);
	}
}