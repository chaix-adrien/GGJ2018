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
	public int minPlayer = 2;
	public Color[] playerColors;


	void Start() {
		startButton = GetComponentInChildren<Button>();
		toggles[0] = GameObject.FindWithTag("Player1Toggle").GetComponent<Toggle>();
		toggles[1] = GameObject.FindWithTag("Player2Toggle").GetComponent<Toggle>();
		toggles[2] = GameObject.FindWithTag("Player3Toggle").GetComponent<Toggle>();
		toggles[3] = GameObject.FindWithTag("Player4Toggle").GetComponent<Toggle>();
		startButton.onClick.AddListener(LoadLevel);
		ScriptGameOptions.playerColors = playerColors;
	}

	void FixedUpdate() {
		if (GamePad.GetButton(GamePad.Button.Start, GamePad.Index.Any)) {
			LoadLevel();
			
		}
		if (GamePad.GetButton(GamePad.Button.Back, GamePad.Index.Any)) {
			foreach (var toggle in toggles) {
				toggle.isOn = false;
			}
			gamepadIsRegistered = Enumerable.Repeat<bool>(false, 4).ToArray();
			playersReadyCount = 0;
			gamepads = Enumerable.Repeat<GamePad.Index?>(null, 4).ToArray();
		}
		if (playersReadyCount < 4 && GetButtonA(0)) {
			for (int i = 0; i < 4; i++) {
				if (GetButtonA(i+1)) {
					if (!gamepadIsRegistered[i]) {
						gamepadIsRegistered[i] = true;
						gamepads[playersReadyCount] = (GamePad.Index)(i+1);
						toggles[playersReadyCount].isOn = true;
						playersReadyCount++;
					}
				}
			}
		}
	}

	void LoadLevel() {
		if (playersReadyCount >= minPlayer) {
			ScriptGameOptions.playersNumber = playersReadyCount;
			ScriptGameOptions.gamepads = gamepads;
			SceneManager.LoadScene("Game");
		}
	}

	bool GetButtonA(int index) {
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
		return GamePad.GetButton(GamePad.Button.A, gamepadIndex);
	}
}
