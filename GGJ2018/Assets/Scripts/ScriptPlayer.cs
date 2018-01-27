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
	public Transform blood;
	public Transform ball;
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
		MoveController();
	}

	void MoveController() {
		Vector2 move = GamePad.GetAxis(GamePad.Axis.LeftStick, gamepad);
        Vector3 movement = new Vector3 (move.x, move.y, 0.0f);
        rb.AddForce (movement * speed);
		transform.LookAt(sight, new Vector3(0, 0, -1));
	}

	void MoveKeyboard() {

		float w = 0;
		float h = 0;
		if (Input.GetKey("left"))
			w -= 1;
		if (Input.GetKey("right"))
			w += 1;
		if (Input.GetKey("up"))
			h += 1;
		if (Input.GetKey("down"))
			h -= 1;
		Vector3 movement = new Vector3 (w, h, 0.0f);
        rb.AddForce (movement * speed);
		transform.LookAt(sight, new Vector3(0, 0, -1));
	}

	void Fire(Transform projectile, bool Instanciate) {
		Transform createdProjectile = null;
		if (Instanciate) {
			createdProjectile = Instantiate(projectile, transform.position, transform.rotation);
		} else {
			createdProjectile = projectile;
		}
		var script = createdProjectile.GetComponent<ScriptLaunchedProjectile>();
		script.dir = transform.localEulerAngles;
		if (projectile == ball) {
			createdProjectile.GetComponent<ScriptBall>().launch();
		}
		script.launch();
		//Parametre Instanciate ou pas
		//
	}

	void Update() {
		
		if (GamePad.GetTrigger(GamePad.Trigger.RightTrigger, gamepad) == 1 && Time.time - lastShoot >= relaodSecond) {
			lastShoot = Time.time;
			Fire(inc, true);
		}
		if (GamePad.GetTrigger(GamePad.Trigger.LeftTrigger, gamepad) == 1 && Time.time - lastShoot >= relaodSecond) {
			lastShoot = Time.time;
			Fire(blood, true);
		}
		if (Input.GetKeyDown("a") == true && Time.time - lastShoot >= relaodSecond) {
			lastShoot = Time.time;
			Fire(ball, false);
		}
	}
}
