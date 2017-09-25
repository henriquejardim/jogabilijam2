﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMove : MonoBehaviour {

	Hashtable ht = new Hashtable();

	public string PathName;
	public float PathTime =15f;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	}

	public void MovePath(){
		var path = GetComponent<iTweenPath> ();
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (PathName), "time", PathTime, "easetype", iTween.EaseType.easeInOutSine));
	}
}