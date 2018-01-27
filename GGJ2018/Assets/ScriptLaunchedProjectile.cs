using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLaunchedProjectile : MonoBehaviour {
	// Use this for initialization
	private Rigidbody rb;
	public Vector3 dir;
	public int speed = 100;
	public bool deleteOnCollision = true;
	void Start () {
		transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		rb = gameObject.GetComponent<Rigidbody>();
		transform.localEulerAngles = dir;
		transform.Rotate(new Vector3(90, 0, 0));
		rb.AddRelativeForce(new Vector3(0, 0, 1) * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void  OnTriggerEnter (Collider collision) {
		if (deleteOnCollision && collision.tag == "FullFloor") {
			Destroy(gameObject);
		}
	}
}
