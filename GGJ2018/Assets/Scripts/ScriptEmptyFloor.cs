using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEmptyFloor : MonoBehaviour {

	// Use this for initialization
	public Material[] materials;
	public Mesh[] mesh;
	void Start () {
		GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
		//GetComponent<MeshFilter>().mesh = mesh[Random.Range(0, mesh.Length)];
	}
}
