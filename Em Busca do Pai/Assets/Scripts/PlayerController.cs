using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float Speed = 5f;
	public GameObject Bullet;

	private Vector2 m_Movement;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		m_Movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

		m_Movement *= Speed * Time.deltaTime;

		rb.velocity = m_Movement;

		if (Input.GetKeyDown(KeyCode.Space))
			Shoot ();

	}

	void Shoot(){
		Instantiate (Bullet, transform.position, transform.rotation);
	}
}
