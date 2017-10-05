using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {


	public float damage = 1f;
	public float speed = 200f;
	public GameObject hitParticles;
	public AudioSource  ad ;

	public AudioClip hit;
	public AudioClip laser;


	private Rigidbody2D rb;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
		ad = gameObject.GetComponent<AudioSource> ();
		DestroyObject (gameObject, 5f);
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
			Debug.Log ("AUDIO1");
			ad.PlayOneShot (hit, 0.7f);

			var particle = Instantiate (hitParticles,  transform.position, transform.rotation, target.gameObject.transform);
			transform.position += Vector3.left * 1000f;
			Destroy (particle, 1f);
			DestroyObject (this.gameObject, 1f);	
		}

		if (other.gameObject.CompareTag("BorderUp"))
			DestroyObject (this.gameObject);

	}
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("TESTE Coll");

		var target = other.gameObject.GetComponent<Target> ();
		if (target != null) {
			target.TakeDamage (damage);
			Debug.Log ("AUDIO2");
			ad.PlayOneShot (hit, 0.7f);
			var particle = Instantiate (hitParticles, other.contacts[0].point, target.transform.rotation);
			Destroy (particle, 1f);
			DestroyObject (this.gameObject, 1f);	


		}
		if (other.gameObject.CompareTag("BorderUp"))
			DestroyObject (this.gameObject);

	}

	public void SetSpeed(float newSpeed){
		speed = newSpeed;
	}

}
