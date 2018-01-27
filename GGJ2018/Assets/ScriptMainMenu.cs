using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptMainMenu : MonoBehaviour {

	private Button startButton;
	private Dropdown playersDropdown;

	void Start() {
		startButton = GetComponentInChildren<Button>();
		playersDropdown = GetComponentInChildren<Dropdown>();
		startButton.onClick.AddListener(LoadLevel);
	}

	void LoadLevel() {
		ScriptGameOptions.playersNumber = playersDropdown.value + 2;
		Debug.Log(ScriptGameOptions.playersNumber);
		SceneManager.LoadScene("Game");
	}
}
