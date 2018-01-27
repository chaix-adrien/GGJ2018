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
        // Instantiate(enemy, new Vector3(2,0,-1), Quaternion.identity);
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
		GameObject[] respawns;
        GameObject player;
        float playerZ;
        Vector3 position;

        // Store the list of spawnable blocks in the map
        respawns = GameObject.FindGameObjectsWithTag("EmptyFloor");

        player = GameObject.FindGameObjectWithTag("Player");
        
        playerZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        
        // Spawn an amount of enemies (numberOfEnemy) randomly on the map
		for(int i = 0; i < numberOfEnemy; i++)
		{
            // Check if there's no game object "Player" on position
			position = (respawns.GetValue( Random.Range(0, respawns.Length))  as GameObject).transform.position;
            while(position == player.transform.position)
            {
                position = (respawns.GetValue( Random.Range(0, respawns.Length))  as GameObject).transform.position;
            }

            position.z = playerZ;
			
			Instantiate(enemy, position, Quaternion.identity);		
		}
       
    }
}
