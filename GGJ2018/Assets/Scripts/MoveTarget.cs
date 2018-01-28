using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class MoveTarget : MonoBehaviour {

  	public Transform player;
	
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = player.gameObject.GetComponent<ScriptPlayer>().color;
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector2 dir  = GamePad.GetAxis(GamePad.Axis.RightStick, player.gameObject.GetComponent<ScriptPlayer>().gamepad);
		transform.localPosition = new Vector3(player.position.x + dir.x, player.position.y + dir.y, player.position.z + 0.1f);		
	}

	public void setAngle(Vector3 angle) {
		transform.localEulerAngles = angle;
	}
}
