using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {


	public float damage = 1f;
	public float speed = 200f;


	// Update is called once per frame
	void Update () {
		transform.Translate (-1 * (Vector2.down * speed * Time.deltaTime)); 
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("TESTE Trigger");
		var target = other.gameObject.GetComponent<Target> ();
		if (target != null) {
			target.TakeDamage (damage);

			DestroyObject (this.gameObject);
		

		}

		if (other.gameObject.CompareTag("BorderUp"))
			DestroyObject (this.gameObject);

	}
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("TESTE Coll");
		var target = other.gameObject.GetComponent<Target> ();
		if (target != null) {
			target.TakeDamage (damage);

			DestroyObject (this.gameObject);

		}
		if (other.gameObject.CompareTag("BorderUp"))
			DestroyObject (this.gameObject);

	}

}
