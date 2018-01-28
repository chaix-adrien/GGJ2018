using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptImpact : MonoBehaviour {

	public AnimationClip  animationC;
	public float fadeTime = 1f;
	private float startTime;
	private float alpha = 1f;
	// Use this for initialization
	void Start () {
		startTime =  Time.time;
		Invoke("destroyMe", animationC.length + fadeTime);
	}
	
	void destroyMe() {
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + animationC.length) {
			Color col = GetComponent<SpriteRenderer>().color;
			float elapsed = Time.time - (startTime + animationC.length);
			col.a = 1f - (elapsed / fadeTime);
			GetComponent<SpriteRenderer>().color = col;
		}
	}
}
