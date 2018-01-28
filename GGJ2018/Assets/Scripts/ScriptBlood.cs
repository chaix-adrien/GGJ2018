using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlood : MonoBehaviour {
	// Use this for initialization
	public int aggroAtHit = 50;
	public int resillience = 4;

	public Transform impact;

	public Transform fromPlayer = null;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void  OnTriggerEnter (Collider collision) {
		if (collision.tag == "Player" && fromPlayer != collision.gameObject.transform) {
			collision.gameObject.GetComponent<ScriptAggro>().addAggro(aggroAtHit);
			collision.gameObject.GetComponent<Animator>().SetTrigger("isSplashed");
			var impactObj = Instantiate(impact, transform.localPosition, Quaternion.identity);
		}
		if (collision.tag == "Enemy") {
			collision.gameObject.GetComponent<ScriptEnemy>().SetTarget(fromPlayer.transform);
			var impactObj = Instantiate(impact, transform.localPosition, Quaternion.identity);
			resillience--;
			if (resillience <= 0)
				Destroy(gameObject);
		}
	}
}
