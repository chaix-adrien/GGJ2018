using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAggroGlow : MonoBehaviour {

	public float maxLightSize = 5f;
	public float maxLightIntensity = 5f;
	private Light aggroLight;

	void Start() {
		aggroLight = GetComponentInChildren<Light>();
	}

	void FixedUpdate() {
		int aggroLevel = GetComponent<ScriptAggro>().aggro;
		aggroLight.intensity = (aggroLevel / 100f) * maxLightIntensity;
		aggroLight.range = (aggroLevel / 100f) * maxLightSize;
	}
}
