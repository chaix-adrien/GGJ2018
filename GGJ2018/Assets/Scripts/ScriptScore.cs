using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptScore : MonoBehaviour {
	private float elapsed;
	public int score;
	public float scoreImplementInterval = 1.0f;
	public Text scoreText;
	private int death = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		elapsed += Time.fixedDeltaTime;
        if (elapsed >= scoreImplementInterval)
        {
			elapsed = elapsed % scoreImplementInterval;
			bool hasObject = GetComponent<ScriptPlayer>().hasObject;
			if (hasObject){
				score+=10;
			}
			int deathPlayer = GetComponent<ScriptPlayer>().death;
			if (death>deathPlayer){
				score -= 100;
			}
		}
		scoreText.text = "Score: " + scoreText.ToString();
		
	}
}
