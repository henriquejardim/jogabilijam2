using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {


	public float damage = 1f;
	public float speed = 200f;


	private Rigidbody2D rb;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}


	// Update is called once per frame
	void Update () {
		
	
	}
	void FixedUpdate() {

		rb.transform.Translate ((Vector2.up) * speed * Time.fixedDeltaTime);
	
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

	public void SetSpeed(float newSpeed){
		speed = newSpeed;
	}

}
