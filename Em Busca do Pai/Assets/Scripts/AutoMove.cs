using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour {
	public float Speed = 5f;
	public float yPositionReset = -100f;
	public float NewYPosision = 100f;
	public bool ResetY = false;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.down * Speed * Time.deltaTime);

		if (transform.position.y <= yPositionReset && ResetY)
			transform.position = new Vector2(transform.position.x, NewYPosision);

	}
}
