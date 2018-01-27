using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSpawnEnemy : MonoBehaviour
{

    public GameObject enemy;
    public float spawnDistanceFromPlayer;
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
        GameObject[] respawns;
        GameObject[] players;
        float playerZ;
        Vector3 position;
        int numberOfPlayers;

        // Store the list of spawnable blocks in the map
        respawns = GameObject.FindGameObjectsWithTag("EmptyFloor");

        players = GameObject.FindGameObjectsWithTag("Player");
        numberOfPlayers = players.Length;
        playerZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;

        // Spawn an amount of enemies (numberOfEnemy) randomly on the map
        for (int i = 0; i < numberOfEnemy * Mathf.FloorToInt(GameObject.FindGameObjectWithTag("Ball").GetComponent<ScriptAggro>().aggro / 10); i++)
        {
            // Get a random position map
            position = (respawns.GetValue(Random.Range(0, respawns.Length)) as GameObject).transform.position; 
            // Check if there's no game object "Player" on or near
            switch(numberOfPlayers)
            {
                case 1:
                    while(Vector3.Distance (players[0].transform.position, position) < spawnDistanceFromPlayer)
                    {
                        position = (respawns.GetValue(Random.Range(0, respawns.Length)) as GameObject).transform.position; 
                    }
                break;
                case 2:
                    while(Vector3.Distance (players[0].transform.position, position) < spawnDistanceFromPlayer || Vector3.Distance (players[1].transform.position, position) < spawnDistanceFromPlayer )
                    {
                        position = (respawns.GetValue(Random.Range(0, respawns.Length)) as GameObject).transform.position; 
                    }
                break;
                case 3:
                    while(Vector3.Distance (players[0].transform.position, position) < spawnDistanceFromPlayer || Vector3.Distance (players[1].transform.position, position) < spawnDistanceFromPlayer || Vector3.Distance (players[2].transform.position, position) < spawnDistanceFromPlayer)
                    {
                        position = (respawns.GetValue(Random.Range(0, respawns.Length)) as GameObject).transform.position; 
                    }
                break;
                case 4:
                    while(Vector3.Distance (players[0].transform.position, position) < spawnDistanceFromPlayer || Vector3.Distance (players[1].transform.position, position) < spawnDistanceFromPlayer || Vector3.Distance (players[2].transform.position, position) < spawnDistanceFromPlayer || Vector3.Distance (players[3].transform.position, position) < spawnDistanceFromPlayer)
                    {
                        position = (respawns.GetValue(Random.Range(0, respawns.Length)) as GameObject).transform.position; 
                    }
                break;
            }
            position.z = playerZ;
            Instantiate(enemy, position, Quaternion.identity);
        }
    }
}
