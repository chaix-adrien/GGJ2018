using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptEndGame : MonoBehaviour {
	public float gameDurationMin = 3;
	// Use this for initialization
	void Start () {
		Invoke("EndGame", gameDurationMin * 60);
	}
	

	void EndGame() {
		ScriptGameOptions.gameEnded = true;
		KeyValuePair<Color, int>[] scores = new KeyValuePair<Color, int>[4];
		
		var players = GameObject.FindGameObjectsWithTag("Player");
		var scoresValuesSorted = new List<int>();
		var scoresValues = new List<int>();
		for (int i = 0; i < players.Length; ++i) {			
			scoresValuesSorted.Add(players[i].GetComponent<ScriptScore>().score);
			scoresValues.Add(players[i].GetComponent<ScriptScore>().score);			
		}
		scoresValuesSorted.Sort();
		int p = 0;
		foreach (var scoreAct in scoresValuesSorted) {
			int id = scoresValues.IndexOf(scoreAct);
			Color color;
			if (ScriptGameOptions.gamepads[id] != null)
				color = players[id].GetComponent<ScriptPlayer>().color;
			else
				color = new Color(0, 0, 0, 0);
			scores[p] = new KeyValuePair<Color, int>(color, (int)scoreAct);
		}
		ScriptGameOptions.scores = scores;
		SceneManager.LoadScene("Menu");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
