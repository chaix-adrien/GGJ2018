using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptEndGameScore : MonoBehaviour {
	public GameObject[] squids;
	public GameObject winSquid;
	public GameObject[] scores;
	// Use this for initialization
	void Start () {
		Debug.Log("startScore");
		winSquid.GetComponent<Image>().color = ScriptGameOptions.scores[0].Key;
		for (int i = 0; i < ScriptGameOptions.scores.Length; i++) {
			Debug.Log("startScorez " + ScriptGameOptions.scores[i].Value.ToString());
			squids[i].GetComponent<Image>().color = ScriptGameOptions.scores[i].Key;
			scores[i].GetComponent<Text>().text = ScriptGameOptions.scores[i].Value.ToString();
			if (ScriptGameOptions.gamepads[i] == null)
				scores[i].SetActive(false);
			else
				scores[i].SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
