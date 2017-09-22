using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMove : MonoBehaviour {

	Hashtable ht = new Hashtable();

	public string PathName;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	}

	public void MovePath(){
		var path = GetComponent<iTweenPath> ();
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (PathName), "time", 15f, "easetype", iTween.EaseType.easeInOutSine));
	}
}
