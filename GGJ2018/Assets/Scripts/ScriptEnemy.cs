using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour
{
    public enum EnemyType { NORMAL, TARGETING };

	public float typeChangeProb = 0.5f;
	public float typeChangeInterval = 3.0f;
    public EnemyType enemyType = EnemyType.NORMAL;
    public float normalMoveSpeed = 5.0f;
    public float targetingMoveSpeed = 10.0f;
    public string targetTag = "Player";
    private GameObject[] players;

    private Transform target = null;
    private Rigidbody rb = null;
    void Awake() {
        rb = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag(targetTag);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        doEnemyBehavior();
    }

    void doEnemyBehavior() {
		var moveSpeed = 0f;
		switch (enemyType) {
			case EnemyType.NORMAL:
				{
					target = GetClosestPlayer(players).transform;
					moveSpeed = normalMoveSpeed;
				}
				break;
			case EnemyType.TARGETING:
			{
				moveSpeed = targetingMoveSpeed;
			}
			break;
		}
        transform.right = target.position - transform.position;
        if (Vector3.Distance(transform.position, target.position) > Mathf.Epsilon) {
            rb.velocity = transform.right * moveSpeed;
        }
        else {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    GameObject GetClosestPlayer(GameObject[] players)
    {
        GameObject closest = null;
        var closestDstSqr = Mathf.Infinity;
        var currPosition = transform.position;
        foreach (var player in players)
        {
            var dstToPlayer = player.transform.position - currPosition;
            if (dstToPlayer.sqrMagnitude < closestDstSqr)
            {
                closestDstSqr = dstToPlayer.sqrMagnitude;
                closest = player;
            }
        }
        return closest;
    }

	GameObject GetRandomPlayerByAgro(GameObject[] players) {
		var agroValues = new int[players.Length];
		var agroTotal = 0;
		foreach (var player in players) {
			agroTotal += player.GetComponent<ScriptPlayer>().agroLevel;
		}

        int result = 0, total = 0;
        int randVal = Random.Range( 0, agroTotal );
        for ( result = 0; result < agroValues.Length; result++ ) {
            total += agroValues[result];
            if (total > randVal) break;
        }
        return players[result];
	}
}
