using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class MoveTarget : MonoBehaviour {

  	public Transform player;
	private Vector2 direction;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = player.gameObject.GetComponent<ScriptPlayer>().color;
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector2 dir  = GamePad.GetAxis(GamePad.Axis.RightStick, player.gameObject.GetComponent<ScriptPlayer>().gamepad);
		if (dir.magnitude > 0.2) {
			direction = dir;
		}
			transform.localPosition = new Vector3(player.position.x + direction.x, player.position.y + direction.y, player.position.z + 0.1f);		
		
	}

	public void setAngle(Vector3 angle) {
		transform.localEulerAngles = angle;
	}
}
