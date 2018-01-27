using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptArrowHUD : MonoBehaviour {

	private UnityEngine.UI.Image img;
	private GameObject player;

	private int lastScore = 0;
	private float lastTime = 0.0f;
	public Sprite up;
	public Sprite down;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
	}
	
	public void setAnchor(GameObject playerFrom, bool left, bool top) {
		player = playerFrom;
		transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
		var rect = GetComponent<RectTransform>();
		Vector2 min;
		min.x = (left) ? 0 : 1 - 0.05f;
		min.y = (top) ? 1 - 0.1f: 0;
		Vector2 max;
		max.x = (left) ? 0.05f : 1;
		max.y = (top) ? 1 : 0.1f;
		rect.anchorMin = min;
		rect.anchorMax = max;
		rect.offsetMax = new Vector2(0, 0);
		rect.offsetMin = new Vector2(0, 0);
		img.color = new Color(0, 0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		var actScore = player.GetComponent<ScriptScore>().score;
		if (actScore > lastScore) {
			img.color = new Color(255, 255, 255, 255);
			img.sprite = up;
			lastTime = Time.time;
		} else if (actScore < lastScore) {
			img.color = new Color(255, 255, 255, 255);
			img.sprite = down;
			lastTime = Time.time;
		} else if (Time.time - lastTime > 1) {
			lastTime = Time.time;
			Debug.Log("hide");
			img.color = new Color(0, 0, 0, 0);
		}
		lastScore = actScore;
	}
}
