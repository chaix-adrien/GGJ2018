using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ScriptPlayer : MonoBehaviour {
    private Rigidbody rb;
	public int speed = 10;
	public int drag = 7;
	public Transform sight;
	public Transform inc;
	public float relaodSecond = 1.0f;
	private float lastShoot = 0.0f;
	public GamePad.Index gamepad;
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
		Vector2 move = GamePad.GetAxis(GamePad.Axis.LeftStick, gamepad);
        Vector3 movement = new Vector3 (move.x, move.y, 0.0f);
        rb.AddForce (movement * speed);
		transform.LookAt(sight, new Vector3(0, 0, -1));
	}

	void Fire() {
		var createdInc = Instantiate(inc, transform.position, transform.rotation);
		
		createdInc.GetComponent<ScriptInc>().dir = transform.localEulerAngles;
	}

	void Update() {
		
		if (GamePad.GetTrigger(GamePad.Trigger.RightTrigger, gamepad) == 1 && Time.time - lastShoot >= relaodSecond) {
			lastShoot = Time.time;
			Fire();
		}
	}
}
