using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPathFinding : MonoBehaviour {
    private Rigidbody rb;
    private Transform previousPosition;
	// Use this for initialization
	 void Start()
    {
        previousPosition = GetComponent<Rigidbody>().transform;
        float time = 0.5f;
        InvokeRepeating("CheckEnemyBlocked", time, time);
    }

	void CheckEnemyBlocked()
    {
		Transform currentPosition = GetComponent<Rigidbody>().transform;
		if(Vector3.Distance(currentPosition.position, previousPosition.position) < 1)
		{

		}
    }	

	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "FullFloor")
        {
            Reoriente();
        }
    }

	void Reoriente()
	{
		GetComponent<Rigidbody>().transform.Rotate(0, 90, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
