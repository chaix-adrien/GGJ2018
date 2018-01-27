using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLaunchedProjectile : MonoBehaviour {
	// Use this for initialization
	private Rigidbody rb;
	public Vector3 dir;
	public int speed = 100;
	public bool deleteOnCollision = true;
	void Awake () {
		//transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		Debug.Log(transform.localScale);
		
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void launch() {
		transform.localEulerAngles = dir;
		transform.Rotate(new Vector3(90, 0, 0));
		rb.AddRelativeForce(new Vector3(0, 0, 1) * speed);
	}

	void  OnTriggerEnter (Collider collision) {
		Debug.Log("Colision");
		if (deleteOnCollision && collision.tag == "FullFloor") {
			Destroy(gameObject);
		}
	}

	
}
