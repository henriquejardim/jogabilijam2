using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoBoss : MonoBehaviour {


	public GameObject[] shotPoints;
	public GameObject Bullet;


	public bool ShotEnabled = true;
	public float CoolDownFire;
	public bool PathEnabled;
	public float BulletSpeed = 20f;


	private Color m_DefaultColor;
	private SpriteRenderer sr;
	private Target target;
	private AutoMove autoMove;
	private TweenMove pathComponent;
	private Animator anim;


	private GameObject[] shotPointsLeft;
	private GameObject[] shotPointsRight;

	private bool onPath = false;
	private bool dead = false;

	private float lastShot = 0f;
	private float lastShotCannon = 5f;

	enum BossState {
		Inactive,
		Idle,
		Attack,
		Cannon
	}

	private BossState state = BossState.Inactive;
	private bool attacking = false;

	// Use this for initialization
	void Start () {
		shotPointsRight = new GameObject[] { shotPoints [0], shotPoints[2]};
		shotPointsLeft  = new GameObject[] { shotPoints [1], shotPoints[3]};
		anim = GetComponent<Animator> ();
		autoMove = GetComponent<AutoMove> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (state == BossState.Inactive)
			return;

		if (lastShotCannon <= Time.time && state == BossState.Idle) {
			lastShotCannon = Time.time + 25f;
			state = BossState.Cannon;
		}	

		if (lastShot <= Time.time && state == BossState.Idle) {
			lastShot = Time.time + CoolDownFire;
			state = BossState.Attack;
		}	

		switch (state) {
		case BossState.Attack:
			if (!attacking) {
				anim.SetTrigger ("Attack");
				attacking = true;
			}
			Debug.Log ("teste");
			break;
		case BossState.Cannon:
			if (!attacking) {
				anim.SetTrigger ("Cannon");
				attacking = true;
			}
			Debug.Log ("teste");
			break;
		default: break;
		}
		
	}

	void Shoot(){
		for (int i = 0; i < shotPoints.Length; i++) {
			ShotBullet(shotPoints[i]);
			ShotBullet(shotPoints[i],-150);
			ShotBullet(shotPoints[i],-170);
			ShotBullet(shotPoints[i],-190);
			ShotBullet(shotPoints[i],-210);
		}
	}

	void ShotBullet(GameObject point, float rotation = -180f){
		point.transform.rotation =  Quaternion.Euler(0f, 0f, rotation);
		var bullet =  Instantiate (Bullet, point.transform.position, point.transform.rotation);
		var projController = bullet.GetComponent<ProjectileController> ();
		if (BulletSpeed > 0f && projController != null)
			projController.SetSpeed (BulletSpeed);
	}

	void OnShootLeft ()
	{
		for (int i = 0; i < shotPointsLeft.Length; i++) {
			ShotBullet (shotPointsLeft [i]);
			ShotBullet (shotPointsLeft [i], -150);
			ShotBullet (shotPointsLeft [i], -210);
		}
	}


	void OnShootRight ()
	{
		for (int i = 0; i < shotPointsRight.Length; i++) {
			ShotBullet (shotPointsRight [i]);
			ShotBullet (shotPointsRight [i], -150);
			ShotBullet (shotPointsRight [i], -210);
		}
	}

	void OnEndAttack(){
		state = BossState.Idle;
		attacking = false;
	}

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log (other.tag);
		if (other.CompareTag ("PathTrigger")) {
			state = BossState.Idle;
			if (pathComponent != null && !onPath && PathEnabled) {
				onPath = true;
				autoMove.enabled = false;
				pathComponent.enabled = true;
				pathComponent.MovePath ();
			}
		}
	}
}

