using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMove : MonoBehaviour {

	Hashtable ht = new Hashtable();

	public string PathName;
	public float PathTime =15f;
	public iTween.EaseType ease = iTween.EaseType.easeInOutSine;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	}

	public void MovePath(){
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath (PathName), "time", PathTime, "easetype", ease));
	}

	public void Stop(){
		iTween.Stop (gameObject);
	}

	public void Resume(){
		iTween.Resume (gameObject);
	}
}
