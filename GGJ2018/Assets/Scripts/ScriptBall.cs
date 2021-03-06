﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBall : MonoBehaviour {
	public GameObject player = null;
	public float rotateSpeed = 1.0f;
	private bool launched = true;
	// Use this for initialization
	void Awake () {
		SetSpawnPos();	
	}
	
	void SetSpawnPos() {
		transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		var emptys = GameObject.FindGameObjectsWithTag("EmptyFloor");
		Vector3 pos = emptys[Random.Range(0, emptys.Length)].transform.position;
		transform.position = new Vector3(pos.x, pos.y, -1);
		
	}

	void Update() {
		if (player) {
			player.GetComponent<ScriptAggro>().aggro = GetComponent<ScriptAggro>().aggro;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log(transform.localPosition.x);
		if (!launched) {
			transform.RotateAround(player.transform.position, new Vector3(0, 0, -1), rotateSpeed * Time.deltaTime);
			transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y, -2);
		}
	}

	void  OnCollisionEnter (Collision collision) {
		if (!player && collision.collider.tag == "Player") {
			Debug.Log("Attach");
			attachToPlayer(collision.gameObject);
		}
	}

	//SI BALL DANS MUR

	void attachToPlayer(GameObject playerToSet) {
		
		player = playerToSet;
		//transform.SetParent(player.transform);
		transform.localPosition = new Vector3(3, 0, -0.5f);
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<ScriptAggro>().increasing = true;
		GetComponent<ScriptAggro>().decreasing = false;
		player.GetComponent<ScriptPlayer>().setHoldingBall(true);
		launched = false;	
	}

	public void launch() {
		GetComponent<Rigidbody>().isKinematic = false;
		//transform.localPosition = new Vector3(0, 3, -0.5f);
		player.GetComponent<ScriptPlayer>().setHoldingBall(false);
		//transform.parent = GameObject.FindGameObjectWithTag("Map").transform;
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1f);
		GetComponent<ScriptAggro>().decreasing = true;
		GetComponent<ScriptAggro>().increasing = false;
		launched = true;
		Invoke("resetPlayer", 1);
	}

	void resetPlayer() {
		player = null;
	}

}