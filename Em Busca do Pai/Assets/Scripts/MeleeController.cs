using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour {

	public float damage = 5f;


	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("TESTE Trigger");
		ApplyDamage (other.gameObject);


	}
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("TESTE Coll");
		ApplyDamage (other.gameObject);
	}

	void ApplyDamage(GameObject col){
		var target = col.gameObject.GetComponent<Target> ();
		if (target != null && target.CompareTag("Enemy")) {
			target.TakeDamage (damage);

		}
	}

}
