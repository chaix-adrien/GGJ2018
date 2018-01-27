using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlood : MonoBehaviour {
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
		if (collision.tag == "Player" && fromPlayer != collision.gameObject) {
			collision.gameObject.GetComponent<ScriptAggro>().addAggro(aggroAtHit);
		}
		if (collision.tag == "Enemy") {
			collision.gameObject.GetComponent<ScriptEnemy>().target = fromPlayer;
			resillience--;
			if (resillience <= 0)
				Destroy(gameObject);
		}
	}
}
