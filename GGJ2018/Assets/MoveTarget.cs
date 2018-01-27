using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class MoveTarget : MonoBehaviour {

  	public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		Vector2 dir  = GamePad.GetAxis(GamePad.Axis.RightStick, player.gameObject.GetComponent<ScriptPlayer>().gamepad);
		transform.position = new Vector3(player.position.x + dir.x, player.position.y + dir.y, player.position.z);
	}
}
