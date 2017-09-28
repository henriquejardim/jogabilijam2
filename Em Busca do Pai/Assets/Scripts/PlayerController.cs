using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

	public float Speed = 5f;    
    public GameObject Bullet;
	public GameObject ShotPoint;
    
    private Vector2 m_Movement;
	private Rigidbody2D rb;

    private Animator anim;
    private Target target;
    private bool dead = false;

    private float lastShot = 0f;
	private float coolDownShot = 0.2f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        target = GetComponent<Target>();
        anim = GetComponent<Animator>();
        target.dead.AddListener(AfterDead);
    }

    public void AfterDead() {        
        dead = true;
    }

    // Update is called once per frame
    void Update () {

        if (dead) {
            rb.velocity *= 0;
            anim.SetTrigger("GameOver");
            return;
        }

        m_Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                
		m_Movement *= Speed * Time.deltaTime;

		rb.velocity = m_Movement;        

        if (Input.GetMouseButton(0) && lastShot <= Time.time)
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
