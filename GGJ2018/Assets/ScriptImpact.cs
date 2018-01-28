using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptImpact : MonoBehaviour {

	public AnimationClip  animation;
	// Use this for initialization
	void Start () {
		Invoke("destroyMe", animation.length + 2);
	}
	
	void destroyMe() {
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
