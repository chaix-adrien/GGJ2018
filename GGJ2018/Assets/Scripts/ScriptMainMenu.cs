using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GamepadInput;
using System.Linq;

public class ScriptMainMenu : MonoBehaviour {

	private Button startButton;
	public GameObject[] toggles;
	private GamePad.Index[] gamepads = {GamePad.Index.One, GamePad.Index.Two, GamePad.Index.Three, GamePad.Index.Four};
	private GamePad.Index?[] gamepadIsRegistered = {null, null, null, null};
	int playersReadyCount = 0;
	public int minPlayer = 2;
	public Color[] playerColors;


	void Start() {
		ScriptGameOptions.playerColors = playerColors;
	}

	void FixedUpdate() {
		if (GamePad.GetButton(GamePad.Button.Start, GamePad.Index.Any)) {
			LoadLevel();
		}
		for (int i = 0; i < 4; i++) {
			if (GamePad.GetButton(GamePad.Button.B, gamepads[i]) && gamepadIsRegistered[i] != null) {
				gamepadIsRegistered[i] = null;
				toggles[i].SetActive(false);
				playersReadyCount--;
			}
		}
		for (int i = 0; i < 4; i++) {
			if (GamePad.GetButton(GamePad.Button.A, gamepads[i]) && gamepadIsRegistered[i] == null) {
				gamepadIsRegistered[i] = gamepads[i];
				toggles[i].SetActive(true);
				playersReadyCount++;
			}
		}
	}

	void LoadLevel() {
		if (playersReadyCount >= minPlayer) {
			ScriptGameOptions.playersNumber = playersReadyCount;
			ScriptGameOptions.gamepads = gamepadIsRegistered;
			SceneManager.LoadScene("Game");
		}
	}
}
