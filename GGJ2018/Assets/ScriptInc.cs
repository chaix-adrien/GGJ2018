using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInc : MonoBehaviour {

	// Use this for initialization
	private Rigidbody rb;
	public Vector3 dir;
	public int speed = 100;
	void Start () {
		transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		rb = gameObject.GetComponent<Rigidbody>();
		transform.localEulerAngles = dir;
		transform.Rotate(new Vector3(0, -90, -90));
		rb.AddRelativeForce(new Vector3(0, 0, 1) * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnTriggerEnter (Collider collision) {
		if (collision.tag == "FullFloor") {
			Debug.Log("floor");
			Destroy(gameObject);
		}
	}
}
