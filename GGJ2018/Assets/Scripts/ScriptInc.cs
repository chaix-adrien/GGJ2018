using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInc : MonoBehaviour {

	// Use this for initialization
	public int aggroAtHit = 50;
	public int resillience = 4;
	public Transform fromPlayer = null;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnTriggerEnter (Collider collision) {
		if (collision.tag == "Player") {
			collision.gameObject.GetComponent<ScriptAggro>().reduceAggro(aggroAtHit);
		}
		if (collision.tag == "Enemy") {
			Destroy(collision.gameObject);
			resillience--;
			if (resillience <= 0)
				Destroy(gameObject);
		}
	}
}
