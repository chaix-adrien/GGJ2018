using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour {
    private Rigidbody rb;
	public int speed = 10;
	public int drag = 7;
	public Transform sight;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.drag = drag;
		SetSpawnPos();
	}
	
	void SetSpawnPos() {
		var emptys = GameObject.FindGameObjectsWithTag("EmptyFloor");
		Vector3 pos = emptys[Random.Range(0, emptys.Length)].transform.position;
		transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		transform.position = new Vector3(pos.x, pos.y, -1);
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

		
        Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		
        rb.AddForce (movement * speed);
		
		transform.LookAt(sight, new Vector3(0, 0, -1));
	}

	void Fire() {

	}

	void Update() {
		if (Input.GetAxis ("Fire1") != 0) {
			Fire();
		}
	}
}
