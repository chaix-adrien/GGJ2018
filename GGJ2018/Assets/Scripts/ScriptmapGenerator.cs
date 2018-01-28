using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptmapGenerator : MonoBehaviour {
	public Camera mainCamera;
	public int height = 9;
	public int width = 16;
	public float fullRate = 0.1f;

	public Transform emptyBlock;
	public Transform fullBlock;


	
	// Use this for initialization
	void Awake () {
		//Delete all child object (reset map)
		mainCamera.orthographicSize = 5f/9f*height;
		
		//generate new map
		for (int w = -1; w < width + 1; w++) {
			for (int h = -1; h < height + 1; h++) {
				float number = Random.Range(0, 100) / 100f;
				Transform toPut = null;
				if (number <= fullRate || w < 0 || h < 0 || w == width || h == height) {
					toPut = fullBlock;
				} else if (number >= fullRate) {
					toPut = emptyBlock;
				}
				var block = Instantiate(toPut, new Vector3(w, h, 0), Quaternion.identity);
				block.transform.parent = transform;
			}
		}
		transform.position = new Vector3(-(width / 2), -(height / 2), 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
