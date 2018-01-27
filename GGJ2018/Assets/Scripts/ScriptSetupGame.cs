using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class ScriptSetupGame : MonoBehaviour {
	public GameObject player;
	public GameObject ball;
	public float playerZ;
	private GamePad.Index?[] gamepads;
	void Awake() {
		List<GameObject> spawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("EmptyFloor"));
		gamepads = ScriptGameOptions.gamepads;
		for (int i = 0; i < 4; ++i) {
			if (gamepads[i] != null) {
				Debug.Log(spawns.Count);
				GameObject spawn = spawns[Random.Range(0, spawns.Count)] as GameObject;
				Vector3 position = spawn.transform.position;
				GameObject newPlayer = Instantiate(player, new Vector3(position.x, position.y, playerZ), Quaternion.identity);
				newPlayer.GetComponent<ScriptPlayer>().gamepad = (GamePad.Index)gamepads[i];
				spawns.Remove(spawn);
			}
		}
		GameObject ballSpawn = spawns[Random.Range(0, spawns.Count)] as GameObject;
		Vector3 ballPosition = ballSpawn.transform.position;
		GameObject newBall = Instantiate(ball, new Vector3(ballPosition.x, ballPosition.y, playerZ), Quaternion.identity);
	}
}
