using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Trap : MonoBehaviour {

	public Color newColor;


	private Color m_DefaultColor;
	private SpriteRenderer sr;
	private Target target;

	private bool dead = false;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		target = GetComponent<Target> ();
		m_DefaultColor = sr.color;

		target.dead.AddListener (AfterDead);
	}
	
	// Update is called once per frame
	void Update () {
		if (dead)
		transform.Translate (Vector2.left * 2 * Time.deltaTime);
	}

	public void AfterDead(){
		sr.color = newColor;
		dead = true;

	}

}
