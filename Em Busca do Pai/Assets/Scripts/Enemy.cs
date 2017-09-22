using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Color newColor;


	private Color m_DefaultColor;
	private SpriteRenderer sr;
	private Target target;
	private AutoMove autoMove;

	private bool onPath = false;

	private bool dead = false;

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
	}

	public void AfterDead(){
		sr.color = newColor;
		dead = true;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("PathTrigger")) {
			var pathComponent = GetComponent<TweenMove> ();
			if (pathComponent != null && !onPath) {
				onPath = true;
				autoMove.enabled = false;
				pathComponent.enabled = true;
				pathComponent.MovePath ();
			}
		}
	}
}
