using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptScore : MonoBehaviour {
	private float elapsed;
	public int score;
	public float scoreImplementInterval = 1.0f;
	public string scoreText = "";
	private int death = 0;
	private GameObject ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Ball");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		elapsed += Time.fixedDeltaTime;
        if (elapsed >= scoreImplementInterval)
        {
			elapsed = elapsed % scoreImplementInterval;
			bool hasObject = ball.GetComponent<ScriptBall>().player == gameObject;
			if (hasObject){
				score += ball.GetComponent<ScriptAggro>().aggro;
			}
			int deathPlayer = 0;
			if (death>deathPlayer){
				score -= 100;
			}
		}
		scoreText = "Score: " + score.ToString();
		Debug.Log(scoreText);
		
	}
	public void DecreaseScore(int decrease) {
		score -= decrease;
		if (score < 0)
			score = 0;
	}
}
