using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour {

  	public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		float dirHorizontal = Input.GetAxis ("HorizontalRight");
        float dirVertical = Input.GetAxis ("VerticalRight");
		transform.position = new Vector3(player.position.x + dirHorizontal, player.position.y + dirVertical, player.position.z);
	}
}
