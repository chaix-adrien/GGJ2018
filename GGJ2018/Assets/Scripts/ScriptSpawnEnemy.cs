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
        // Store the list of spawnable blocks in the map
		GameObject[] respawns;
        Vector3 position;


        respawns = GameObject.FindGameObjectsWithTag("EmptyFloor");
        position = (respawns.GetValue( Random.Range(0, respawns.Length))  as GameObject).transform.position;

        // Spawn an amount of enemies (numberOfEnemy) randomly on the map
		for(int i = 0; i < numberOfEnemy; i++)
		{
			
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
