using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Color newColor;
	public GameObject shotPoint;
	public GameObject Bullet;
	public float CoolDownFire;
	public bool PathEnabled;

	private Color m_DefaultColor;
	private SpriteRenderer sr;
	private Target target;
	private AutoMove autoMove;

	private bool onPath = false;

	private bool dead = false;


	private GameObject player;
	private bool playerFound;

	private float lastShot = 0f;

	// Use this for initialization
	void Start () {
		autoMove = GetComponent<AutoMove> ();
		sr = GetComponent<SpriteRenderer> ();
		target = GetComponent<Target> ();
		m_DefaultColor = sr.color;

		target.dead.AddListener (AfterDead);


	}

	// Update is called once per frame
	void Update () {
		if (dead)
			transform.Translate (((transform.position.x > 0) ? Vector2.right : Vector2.left) * 2 * Time.deltaTime);

		if (playerFound && !dead) {

			Vector3 lTargetDir = player.transform.position - shotPoint.transform.position;
			lTargetDir.Normalize ();
			float rot_z = Mathf.Atan2(lTargetDir.y, lTargetDir.x) * Mathf.Rad2Deg;
			 
			shotPoint.transform.rotation =  Quaternion.Euler(0f, 0f, rot_z - 90);

			if (lastShot <= Time.time) {
				lastShot = Time.time + CoolDownFire;
				Instantiate (Bullet, shotPoint.transform.position, shotPoint.transform.rotation);

			}
				
		}
	}

	public void AfterDead(){
		sr.color = newColor;
		dead = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.CompareTag ("PathTrigger")) {
			
			FindPlayer ();

			var pathComponent = GetComponent<TweenMove> ();
			if (pathComponent != null && !onPath && PathEnabled) {
				onPath = true;
				autoMove.enabled = false;
				pathComponent.enabled = true;
				pathComponent.MovePath ();
			}
		}
	}


	void FindPlayer(){
		player = GameObject.FindWithTag ("Player");
		playerFound = player != null;
	}


}
