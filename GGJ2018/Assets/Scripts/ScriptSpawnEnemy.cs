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
	Camera cam;
    // Use this for initialization
    void Start()
    {
		cam = GetComponent<Camera>();
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector3 dir;
        Vector3 position;

		spawnPosition.x = Random.Range (-17, 17);
        spawnPosition.y = Random.Range (-17, 17);
        spawnPosition.z = 0.0f;

		// Spawn an amount of enemies (numberOfEnemy) randomly on the map
		for(int i = 0; i < numberOfEnemy; i++)
		{
			dir = Random.insideUnitCircle;
			position = Vector3.zero;

			// Check if there's a gameobject present on a random position 
			if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
			{//make it appear on the side
				position = new Vector3(Mathf.Sign(dir.x) * Camera.main.orthographicSize * Camera.main.aspect,
										0,
										dir.y * Camera.main.orthographicSize);
			}
			else
			{//make it appear on the top/bottom
				position = new Vector3(dir.x * Camera.main.orthographicSize * Camera.main.aspect,
										0,
										Mathf.Sign(dir.y) * Camera.main.orthographicSize);
			}
			Instantiate(enemy, position, Quaternion.identity);
		}
       
    }
}
