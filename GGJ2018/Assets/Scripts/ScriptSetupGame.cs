using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ScriptSetupGame : MonoBehaviour {
	public GameObject player;
	public GameObject ball;
	public float playerZ;
	private GamePad.Index?[] gamepads;
	public Color[] playerColors;

	void Awake() {
		gamepads = ScriptGameOptions.gamepads;
		GameObject newBall = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
		for (int i = 0; i < gamepads.Length; ++i) {
			if (gamepads[i] != null) {
				GameObject newPlayer = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
				newPlayer.GetComponent<ScriptPlayer>().color = ScriptGameOptions.playerColors[i];
				newPlayer.GetComponent<ScriptPlayerHUD>().top = i < 2;
				newPlayer.GetComponent<ScriptPlayerHUD>().left = i % 2 == 0;
				newPlayer.GetComponent<ScriptPlayer>().ball = newBall.transform;
				Debug.Log( (GamePad.Index)gamepads[i]);
				newPlayer.GetComponent<ScriptPlayer>().gamepad = (GamePad.Index)gamepads[i];
				newPlayer.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

			}
		}
	}
}
