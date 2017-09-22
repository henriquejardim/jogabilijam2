using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour {

	public DashState dashState;
	public float dashTimer;
	public float maxDash = 20f;

	public Vector2 savedVelocity;

	private Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{
		switch (dashState) 
		{
		case DashState.Ready:
			var isDashKeyDown = Input.GetKeyDown (KeyCode.LeftShift);
			if(isDashKeyDown)
			{
				savedVelocity = rb.velocity;
				rb.velocity =  new Vector2(rb.velocity.x * 11000f, rb.velocity.y);
				dashState = DashState.Dashing;
			}
			break;
		case DashState.Dashing:
			dashTimer += Time.deltaTime * 3;
			if(dashTimer >= maxDash)
			{
				dashTimer = maxDash;
				rb.velocity = savedVelocity;
				dashState = DashState.Cooldown;
			}
			break;
		case DashState.Cooldown:
			dashTimer -= Time.deltaTime;
			if(dashTimer <= 0)
			{
				dashTimer = 0;
				dashState = DashState.Ready;
			}
			break;
		}
	}
}

public enum DashState 
{
	Ready,
	Dashing,
	Cooldown
}
