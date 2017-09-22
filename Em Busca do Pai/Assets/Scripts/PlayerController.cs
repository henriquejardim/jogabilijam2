﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float Speed = 5f;
	public GameObject Bullet;



	private Vector2 m_Movement;
	private Rigidbody2D rb;

	private float lastShot = 0f;
	private float coolDownShot = 0.2f;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		m_Movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

		m_Movement *= Speed * Time.deltaTime;

		rb.velocity = m_Movement;

		if (Input.GetMouseButton(0) && lastShot <= Time.time)
			Shoot ();

		if (Input.GetMouseButtonDown (1)) {
			Melee ();
		}

	}

	void Shoot(){
		lastShot = Time.time + coolDownShot;
		Instantiate (Bullet, transform.position, transform.rotation);
	}

	void Melee(){
		
		var anim = GetComponent<Animator> ();
		anim.SetTrigger ("Attack");
	}
}
