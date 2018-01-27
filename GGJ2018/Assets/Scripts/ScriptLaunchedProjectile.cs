using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLaunchedProjectile : MonoBehaviour {
	// Use this for initialization
	private Rigidbody rb;
	public Vector3 direction;
	public Vector3 rotation;
	public int speed = 100;
	public bool deleteOnCollision = true;
	void Awake () {
		//transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);		
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void launch() {
		transform.localEulerAngles = rotation;
		transform.Rotate(new Vector3(90, 0, 0));
		rb.AddForce(direction * speed);
	}

	void  OnTriggerEnter (Collider collision) {
		Debug.Log("Colision");
		if (deleteOnCollision && collision.tag == "FullFloor") {
			Destroy(gameObject);
		}
	}

	
}
