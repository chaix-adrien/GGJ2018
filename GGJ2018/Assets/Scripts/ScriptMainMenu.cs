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
	public GameObject instructions;
	public GameObject endPanel;
	private bool instructionEnable = false;
	private bool backUp = true;
	private GamePad.Index[] gamepads = {GamePad.Index.One, GamePad.Index.Two, GamePad.Index.Three, GamePad.Index.Four};
	private GamePad.Index?[] gamepadIsRegistered = {null, null, null, null};
	int playersReadyCount = 0;
	public int minPlayer = 2;
	public Color[] playerColors;


	void Start() {
		ScriptGameOptions.playerColors = playerColors;
		if (ScriptGameOptions.gameEnded) {
			endPanel.SetActive(true);
		}
	}

	void FixedUpdate() {
		if (!ScriptGameOptions.gameEnded) {
			if (GamePad.GetButtonDown(GamePad.Button.Back, GamePad.Index.Any) && backUp) {
				instructionEnable = !instructionEnable;
				instructions.SetActive(instructionEnable);
				backUp = false;
			}
			if (GamePad.GetButtonUp(GamePad.Button.Back, GamePad.Index.Any)) {
				backUp = true;
			}
			if (!instructionEnable) {
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
		} else {
			if (GamePad.GetButton(GamePad.Button.Back, GamePad.Index.Any)) {
				ScriptGameOptions.gameEnded = false;
				endPanel.SetActive(false);				
			}
			if (GamePad.GetButton(GamePad.Button.Start, GamePad.Index.Any)) {
				ScriptGameOptions.gameEnded = false;
				playersReadyCount = ScriptGameOptions.playersNumber;
				gamepadIsRegistered = ScriptGameOptions.gamepads;
				LoadLevel();
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
