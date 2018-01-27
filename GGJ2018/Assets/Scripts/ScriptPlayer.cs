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

	public Animator anim;

	public Color color;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.drag = drag;
		SetSpawnPos();
		GetComponent<SpriteRenderer>().color = color;
		anim=GetComponent<Animator>();
		sight = Instantiate(sight, new Vector3(0, 0, 0), Quaternion.identity);
		sight.GetComponent<MoveTarget>().player = transform;
	}
	
	void SetSpawnPos() {
		transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
		var emptys = GameObject.FindGameObjectsWithTag("EmptyFloor");
		Vector3 pos = emptys[Random.Range(0, emptys.Length)].transform.position;
		transform.position = new Vector3(pos.x, pos.y, -0.7f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		MoveController();
		
	}

	void MoveController() {
		Vector2 move = GamePad.GetAxis(GamePad.Axis.LeftStick, gamepad);
        Vector3 movement = new Vector3 (move.x, move.y, 0.0f);
        rb.AddForce(movement * speed);
		float angle = Vector3.SignedAngle(new Vector3(0, 1, 0), sight.transform.position - transform.position, new Vector3(0, 0, 1));
		transform.localEulerAngles = new Vector3(0, 0, angle);
		if (movement.sqrMagnitude != 0){
			anim.SetBool("isMoving", true);
		}else{
			anim.SetBool("isMoving", true);
		}
		sight.GetComponent<MoveTarget>().setAngle(transform.localEulerAngles);
		transform.position = new Vector3(transform.position.x, transform.position.y, -0.7f);
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
		Vector3 direction = sight.transform.position - transform.position;
		if (direction == Vector3.zero)
			return;
		Transform createdProjectile = null;
		if (Instanciate) {
			createdProjectile = Instantiate(projectile, transform.position, transform.rotation);
		} else {
			createdProjectile = projectile;
			createdProjectile.transform.rotation = transform.rotation;
		}
		if (projectile == ball)
			createdProjectile.GetComponent<ScriptBall>().launch();			
		if (projectile == inc)
			createdProjectile.GetComponent<ScriptInc>().fromPlayer = transform;
		if (projectile == blood)
			createdProjectile.GetComponent<ScriptBlood>().fromPlayer = transform;
		var script = createdProjectile.GetComponent<ScriptLaunchedProjectile>();
		script.rotation = transform.localEulerAngles;
		script.direction = direction;
		script.launch();
		
	}

	void Update() {
		Debug.Log(GamePad.GetTrigger(GamePad.Trigger.RightTrigger, gamepad));
		if (GamePad.GetTrigger(GamePad.Trigger.RightTrigger, gamepad) == 1 && Time.time - lastShoot >= relaodSecond) {
			lastShoot = Time.time;
			Fire(inc, true);
		}
		if (GameObject.FindGameObjectWithTag("Ball").GetComponent<ScriptBall>().player == gameObject &&  GamePad.GetTrigger(GamePad.Trigger.LeftTrigger, gamepad) == 1 && Time.time - lastShoot >= relaodSecond) {
			lastShoot = Time.time;
			Fire(ball, false);
		} else if (GamePad.GetTrigger(GamePad.Trigger.LeftTrigger, gamepad) == 1 && Time.time - lastShoot >= relaodSecond) {
			lastShoot = Time.time;
			Fire(blood, true);
		}
	}
}
