using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBall : MonoBehaviour {
	public GameObject player = null;
	// Use this for initialization
	void Awake () {
		SetSpawnPos();	
	}
	
	void SetSpawnPos() {
		var emptys = GameObject.FindGameObjectsWithTag("EmptyFloor");
		Vector3 pos = emptys[Random.Range(0, emptys.Length)].transform.position;
		Debug.Log(emptys.Length);
		Debug.Log(pos);
		transform.position = new Vector3(pos.x, pos.y, -1);
		
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
		Debug.Log("Attach ball to ");
		Debug.Log(playerToSet);
		player = playerToSet;
		transform.SetParent(player.transform);
		transform.localPosition = new Vector3(0, 0, 2);
		GetComponent<Rigidbody>().isKinematic = true;

	}

	public void launch() {
		GetComponent<Rigidbody>().isKinematic = false;
		transform.parent = null;
		
		player = null;
	}

}
