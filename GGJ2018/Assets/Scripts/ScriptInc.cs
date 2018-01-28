using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInc : MonoBehaviour {

	// Use this for initialization
	public int aggroAtHit = 50;
	public int resillience = 4;
	public Transform fromPlayer = null;

	public Transform impact;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnTriggerEnter (Collider collision) {
		if (collision.tag == "Player" && collision.gameObject.transform != fromPlayer) {
			collision.gameObject.GetComponent<ScriptAggro>().reduceAggro(aggroAtHit);
			var impactObj = Instantiate(impact, transform.localPosition, Quaternion.identity);
		}
		if (collision.tag == "Enemy") {
			Destroy(collision.gameObject);
			var impactObj = Instantiate(impact, transform.localPosition, Quaternion.identity);

			resillience--;
			if (resillience <= 0)
				Destroy(gameObject);
		}
	}
}
