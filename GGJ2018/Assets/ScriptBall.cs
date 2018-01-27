﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBall : MonoBehaviour {
	private GameObject player = null;
	// Use this for initialization
	void Awake () {
		SetSpawnPos();	
	}
	
	void SetSpawnPos() {
		Debug.Log("Spawned");
		var emptys = GameObject.FindGameObjectsWithTag("EmptyFloor");
		Vector3 pos = emptys[Random.Range(0, emptys.Length)].transform.position;
		//transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		transform.position = new Vector3(pos.x, pos.y, -2);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void  OnCollisionEnter (Collision collision) {
		if (!player && collision.collider.tag == "Player") {
			Debug.Log("GetBall");			
			attachToPlayer(collision.gameObject);
		}
	}

	void attachToPlayer(GameObject playerToSet) {
		player = playerToSet;
		transform.SetParent(player.transform);
		transform.localPosition = new Vector3(0, 0, -1);
		GetComponent<Rigidbody>().isKinematic = true;

	}

	public void launch() {
		GetComponent<Rigidbody>().isKinematic = false;
		transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
	}

}
