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

    void FixedUpdate()
    {
        List <float> angles = new List<float>();
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        float closest = 50;
        for(int i = -45; i < 45; i+=5)
        {
            if(!Physics.Raycast(transform.position, new Vector3(rb.transform.rotation.x, rb.transform.rotation.y, rb.transform.rotation.z + i),5))
            {
                angles.Add(i);
            }
        }

        foreach(float angle in angles)
        {
            if(Mathf.Abs(angle) < Mathf.Abs(closest))
            {
                closest = angle;
            }
        }
        
        // The gameobject is oriented at the closest angle
        GetComponent<Rigidbody>().transform.Rotate(0, 0, closest);     


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
