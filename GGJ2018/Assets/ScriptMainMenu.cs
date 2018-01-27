using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GamepadInput;
using System.Linq;
public class ScriptMainMenu : MonoBehaviour {

	private Button startButton;
	private Toggle[] toggles = new Toggle[4];
	private GamePad.Index?[] gamepads = {null, null, null, null};
	private bool[] gamepadIsRegistered = {false, false, false, false};
	int playersReadyCount = 0;

	void Start() {
		startButton = GetComponentInChildren<Button>();
		toggles[0] = GameObject.FindWithTag("Player1Toggle").GetComponent<Toggle>();
		toggles[1] = GameObject.FindWithTag("Player2Toggle").GetComponent<Toggle>();
		toggles[2] = GameObject.FindWithTag("Player3Toggle").GetComponent<Toggle>();
		toggles[3] = GameObject.FindWithTag("Player4Toggle").GetComponent<Toggle>();
		startButton.onClick.AddListener(LoadLevel);
	}

	void FixedUpdate() {
		if (GamePad.GetButton(GamePad.Button.Start, GamePad.Index.Any)) {
			LoadLevel();
			
		}
		if (playersReadyCount < 4) {
			for (int i = 0; i < 4; i++) {
				if (!gamepadIsRegistered[i] && GetButton(i+1, GamePad.Button.A)) {
					gamepadIsRegistered[i] = true;
					gamepads[i] = (GamePad.Index)(i+1);
					toggles[i].isOn = true;
					playersReadyCount++;
				}
			}
		}
		if (playersReadyCount > 0) {
			for (int i = 0; i < 4; ++i) {
				if (gamepadIsRegistered[i] && GetButton(i+1, GamePad.Button.B)) {
					gamepadIsRegistered[i] = false;
					gamepads[i] = null;
					toggles[i].isOn = false;
					playersReadyCount--;
				}
			}
		}
	}

	void LoadLevel() {
		if (playersReadyCount >= 1) {
			ScriptGameOptions.playersNumber = playersReadyCount;
			ScriptGameOptions.gamepads = gamepads;
			SceneManager.LoadScene("Game");
		}
	}

	bool GetButton(int index, GamePad.Button button) {
		GamePad.Index gamepadIndex;
		switch (index) {
			case 1:
			gamepadIndex = GamePad.Index.One;
			break;
			case 2:
			gamepadIndex = GamePad.Index.Two;
			break;
			case 3:
			gamepadIndex = GamePad.Index.Three;
			break;
			case 4:
			gamepadIndex = GamePad.Index.Four;
			break;
			case 0:
			default:
			gamepadIndex = GamePad.Index.Any;
			break;
		}
		return GamePad.GetButton(button, gamepadIndex);
	}
}
