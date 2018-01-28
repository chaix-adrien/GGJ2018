using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptButtonExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(quitGame);
	}
	
	void quitGame() {
		Application.Quit();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
