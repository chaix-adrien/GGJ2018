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
        List<Vector3> positions = new List<Vector3>();

        // Store the list of spawnable blocks in the map
        respawns = GameObject.FindGameObjectsWithTag("EmptyFloor");

        player = GameObject.FindGameObjectWithTag("Player");

        playerZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;

        // Spawn an amount of enemies (numberOfEnemy) randomly on the map
        for (int i = 0; i < numberOfEnemy; i++)
        {
            // Get a random position map
            position = (respawns.GetValue(Random.Range(0, respawns.Length)) as GameObject).transform.position;
            // Check if there's no game object "Player" on position
            Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, 2);
            foreach (Collider collider in hitColliders)
            {
                while (position == collider.transform.position)
                {
                    positions.Add(position);
                }
            }


            while (position == player.transform.position)
            {
                position = (respawns.GetValue(Random.Range(0, respawns.Length)) as GameObject).transform.position;
            }

            position.z = playerZ;

            Instantiate(enemy, position, Quaternion.identity);
        }
    }
}
