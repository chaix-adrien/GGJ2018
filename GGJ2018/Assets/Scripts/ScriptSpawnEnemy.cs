using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpawnEnemy : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime;
	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("SpawnEnemy", spawnTime, spawnTime);
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void SpawnEnemy()
	{
		//Instantiate(enemy,new Vector3(,0,0), Quaternion.identity);
	}
}
