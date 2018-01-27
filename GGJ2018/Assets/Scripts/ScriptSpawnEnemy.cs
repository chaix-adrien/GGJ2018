using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    public float spawnTime;
	public int numberOfEnemy;
    private float spawnX;
    private float spawnY;
	private Vector3 spawnPosition;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
		GameObject[] respawns = GameObject.FindGameObjectsWithTag("e");

        Vector3 dir;
        Vector3 position;
		// Spawn an amount of enemies (numberOfEnemy) randomly on the map
		for(int i = 0; i < numberOfEnemy; i++)
		{
			position.x = Random.Range(0.0f, Camera.main.pixelWidth);
 			position.y = Random.Range(0.0f, Camera.main.pixelHeight);
			position.z = 0.0f;
			// Get list of spawnable objects with tags



			// Check if there's no game object "Player" on 
			// Check if there's a gameobject present on a random position 
			if (Mathf.Abs(position.x) > Mathf.Abs(position.y))
			{
				Instantiate(enemy, position, Quaternion.identity);
			}
			
		}
       
    }
}
