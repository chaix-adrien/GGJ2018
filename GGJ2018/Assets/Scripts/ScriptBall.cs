using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBall : MonoBehaviour {
	public GameObject player = null;
	public float rotateSpeed = 1.0f;
	// Use this for initialization
	void Awake () {
		SetSpawnPos();	
	}
	
	void SetSpawnPos() {
		var emptys = GameObject.FindGameObjectsWithTag("EmptyFloor");
		Vector3 pos = emptys[Random.Range(0, emptys.Length)].transform.position;
		
		
	}

	void Update() {

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		if (player) {
			transform.RotateAround(player.transform.position, new Vector3(0, 0, -1), rotateSpeed * Time.deltaTime);
		}
	}

	void  OnCollisionEnter (Collision collision) {
		if (!player && collision.collider.tag == "Player") {
			attachToPlayer(collision.gameObject);
		}
	}

	//SI BALL DANS MUR

	void attachToPlayer(GameObject playerToSet) {
		
		player = playerToSet;
		transform.SetParent(player.transform);
		transform.localPosition = new Vector3(0, 0, 1.3f);
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<ScriptAggro>().increasing = true;
		GetComponent<ScriptAggro>().decreasing = false;		
	}

	public void launch() {
		GetComponent<Rigidbody>().isKinematic = false;
		transform.localPosition = new Vector3(0, 0, 1.3f);
		transform.parent = GameObject.FindGameObjectWithTag("Map").transform;
		player.GetComponent<ScriptAggro>().aggro = GetComponent<ScriptAggro>().aggro;
		GetComponent<ScriptAggro>().decreasing = true;
		GetComponent<ScriptAggro>().increasing = false;
		player = null;
	}

}