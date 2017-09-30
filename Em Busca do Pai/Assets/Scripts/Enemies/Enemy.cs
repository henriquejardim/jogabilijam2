using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Color newColor;
	public GameObject shotPoint;
	public GameObject Bullet;
	public GameObject DeadParticles;
	public bool ShotEnabled = true;
	public float CoolDownFire;
	public float BulletSpeed;
	public bool PathEnabled;
	public int Score = 100;

	private Color m_DefaultColor;
	private SpriteRenderer sr;
	private Target target;
	private AutoMove autoMove;
	private TweenMove pathComponent;

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
		pathComponent = GetComponent<TweenMove>();
		m_DefaultColor = sr.color;

		target.dead.AddListener (AfterDead);
	}

	// Update is called once per frame
	void Update () {
        if (dead) {
            transform.Translate(((transform.position.x > 0) ? Vector2.right : Vector2.left) * 2 * Time.deltaTime);
            return;
        }

		if (!playerFound)
            return;      

		if (!ShotEnabled)
			return;
		
		Vector3 lTargetDir = player.transform.position - shotPoint.transform.position;
		lTargetDir.Normalize ();
		float rot_z = Mathf.Atan2(lTargetDir.y, lTargetDir.x) * Mathf.Rad2Deg;
		shotPoint.transform.rotation =  Quaternion.Euler(0f, 0f, rot_z - 90);

		if (lastShot <= Time.time && player.transform.position.y <= transform.position.y) {
			lastShot = Time.time + CoolDownFire;
			var bullet =  Instantiate (Bullet, shotPoint.transform.position, shotPoint.transform.rotation);
			var projController = bullet.GetComponent<ProjectileController> ();
			if (BulletSpeed > 0f && projController != null)
				projController.SetSpeed (BulletSpeed);
		}						
	}

	public void AfterDead(){
		sr.color = newColor;
		dead = true;
		var particles = Instantiate (DeadParticles, transform.position, transform.rotation);
		sr.enabled = false;
		var getColliders = GetComponents<Collider2D> ();
		foreach (var item in getColliders) {
			item.enabled = false;	
		}
		pathComponent.Stop ();
		GameController.instance.AddScore (Score);
		Destroy (gameObject, 1f);
	}

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log (other.tag);
		if (other.CompareTag ("PathTrigger")) {
			
			FindPlayer ();

			if (pathComponent != null && !onPath && PathEnabled) {
				onPath = true;
				autoMove.enabled = false;
				pathComponent.enabled = true;
				pathComponent.MovePath ();
			}
		}
	}


	bool FindPlayer(){
		player = GameObject.FindWithTag ("Player");
		playerFound = player != null;

		return playerFound;
	}

}
