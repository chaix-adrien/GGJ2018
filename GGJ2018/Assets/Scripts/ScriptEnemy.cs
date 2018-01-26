using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed = 5.0f;
	public float turnSpeed = 1.0f;
	public string targetTag = "Player";
	private GameObject[] players;

	private Transform target = null;
	private Rigidbody rb = null;
	void Awake () {
		rb = GetComponent<Rigidbody>();
		players = GameObject.FindGameObjectsWithTag(targetTag);
		target = GetClosestPlayer(players).transform;
		}
	
	// Update is called once per frame
	void FixedUpdate () {
		target = GetClosestPlayer(players).transform;
		transform.right = target.position - transform.position;
		if (Vector3.Distance(transform.position, target.position) > Mathf.Epsilon) {
			rb.velocity = transform.right * moveSpeed;
		} else {
			rb.velocity = new Vector3(0,0,0);
		}
	}

	GameObject GetClosestPlayer(GameObject[] players) {
		GameObject closest = null;
		var closestDstSqr = Mathf.Infinity;
		var currPosition = transform.position;
		foreach (var player in players) {
			var dstToPlayer = player.transform.position - currPosition;
			if (dstToPlayer.sqrMagnitude < closestDstSqr) {
				closestDstSqr = dstToPlayer.sqrMagnitude;
				closest = player;
			}
		}
		return closest;
	}
}
