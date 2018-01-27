using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPathFinding : MonoBehaviour {

    public float precisionAngle;
    private Rigidbody rb;
   
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
        if(closest < 0)
        {
            GetComponent<Rigidbody>().transform.Rotate(0, 0, closest - precisionAngle);     
        }else if(closest > 0){
            GetComponent<Rigidbody>().transform.Rotate(0, 0, closest + precisionAngle);   
        }
       


    }
}
