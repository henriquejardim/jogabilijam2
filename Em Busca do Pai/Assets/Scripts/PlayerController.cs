using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float Speed = 5f;
    private Color hurtColor = Color.red;
    public GameObject Bullet;
	public GameObject ShotPoint;
	public GameObject DeadParticles;

	public GameController controller;

    private Color m_DefaultColor;

    private Vector2 m_Movement;
	private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Animator anim;
    private Target target;

	private BoxCollider2D boxCollider;
	private AudioSource audioSource;


    private bool dead = false;
    private bool hurt = false;

    private float lastShot = 0f;
	private float coolDownShot = 0.2f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        target = GetComponent<Target>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
		boxCollider = GetComponent<BoxCollider2D> ();
		audioSource = GetComponent<AudioSource> ();
        m_DefaultColor = sr.color;

		controller = GameObject.FindObjectOfType<GameController> ();

        target.dead.AddListener(AfterDead);        
        target.hurt.AddListener(AfterHurt);
    }


    public void AfterHurt() {
        sr.color = hurtColor;
        hurt = true;
		target.invulnarable = hurt;
		anim.SetBool ("Hurt", hurt);
		controller.RemoveLife ();
		boxCollider.enabled = false;
		StartCoroutine("Hitstop");

        StartCoroutine(HurtWait());
    }

    private IEnumerator HurtWait() {
        yield return new WaitForSeconds(1f); //invul time
		anim.SetBool ("Hurt", false);
		if (!dead) {
			hurt = false;
			target.invulnarable = hurt;
			boxCollider.enabled = true;
		}

    }

	IEnumerator Hitstop(){
		Time.timeScale = 0f;
		float RealTimeOfTimestopStart = Time.realtimeSinceStartup;
		float lengthOfTimestop = 0.2f;
		while(Time.realtimeSinceStartup < RealTimeOfTimestopStart + lengthOfTimestop){
			yield return null;
		}
		Time.timeScale = 1f;
	}

    public void AfterDead() {    
		iTween.FadeTo (gameObject, 0f, 1f);
        dead = true;
		hurt = true;
		target.invulnarable = hurt;
		boxCollider.enabled = false;
		audioSource.PlayDelayed (0.3f);
		Invoke ("InvokeParticles", 0.3f);
    }
	void  InvokeParticles(){
		Instantiate (DeadParticles, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.parent);
	}

    // Update is called once per frame
    void Update () {

        if (!hurt && sr.color != m_DefaultColor)
            sr.color = m_DefaultColor;        

        if (dead) {
            rb.velocity *= 0;
            anim.SetTrigger("GameOver");
            return;
        }

        m_Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                
		m_Movement *= Speed * Time.deltaTime;

		rb.velocity = m_Movement;        

		if (Input.GetButton("Fire1") && lastShot <= Time.time)
			Shoot ();

		if (Input.GetMouseButtonDown (1))
			Melee ();		
	}

	void Shoot(){
		lastShot = Time.time + coolDownShot;
		Instantiate (Bullet, ShotPoint.transform.position, ShotPoint.transform.rotation);
	}

	void Melee(){		
		var anim = GetComponent<Animator> ();
		if (anim != null) anim.SetTrigger ("Attack");
	}
}
