using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptArrowHUD : MonoBehaviour {

	private UnityEngine.UI.Image img;
	private GameObject player;

	private int lastAggro = 0;
	private float lastTime = 0.0f;
	public Sprite up;
	public Sprite down;
	private Animator anim;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
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
		var actAggro = player.GetComponent<ScriptAggro>().aggro;
		if (Time.time - lastTime > 1) {
			if (actAggro > lastAggro) {
				img.color = new Color(255, 255, 255, 255);
				img.sprite = up;
				//anim.SetBool("up", true);
			} else if (actAggro < lastAggro) {
				img.color = new Color(255, 255, 255, 255);
				img.sprite = down;
	//			anim.SetBool("up", true);
				
			} else {
				img.color = new Color(0, 0, 0, 0);
			}
			lastTime = Time.time;
			lastAggro = actAggro;
		}
		
		
	}
}
