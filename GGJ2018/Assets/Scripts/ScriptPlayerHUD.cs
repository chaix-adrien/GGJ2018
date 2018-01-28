using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPlayerHUD : MonoBehaviour {

	// Use this for initialization
	public bool left = true;
	public bool top = true;
	public Transform ScorePrefab;
	public Transform ImgPrefab;
	private Transform img;
	private Transform score;
	void Start () {
		score = Instantiate(ScorePrefab, new Vector3(0, 0, 0), Quaternion.identity);
		img = Instantiate(ImgPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		img.GetComponent<ScriptArrowHUD>().setAnchor(gameObject, left, top);
		score.GetComponent<Text>().color = GetComponent<ScriptPlayer>().color;

		score.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
		var rect = score.GetComponent<RectTransform>();
		Vector2 min;
		min.x = (left) ? 0.05f : 1 - 0.3f - 0.05f;
		min.y = (top) ? 1 - 0.2f -0.05f: 0.05f;
		Vector2 max;
		max.x = (left) ? 0.3f + 0.05f : 1 - 0.05f;
		max.y = (top) ? 1 - 0.05f: 0.2f + 0.05f;
		
		rect.anchorMin = min;
		rect.anchorMax = max;
		score.gameObject.GetComponent<Text>().alignment = (left) ? ((top) ? TextAnchor.UpperLeft : TextAnchor.LowerLeft): ((top) ? TextAnchor.UpperRight : TextAnchor.LowerRight);
	}
	
	// Update is called once per frame
	void Update () {
		
		score.gameObject.GetComponent<Text>().text =  gameObject.GetComponent<ScriptScore>().score.ToString();
	}
}
