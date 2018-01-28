using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPathFinding : MonoBehaviour {

    public float precisionAngle;
    public float raycastDistance;
    private Rigidbody rb;
   
    void FixedUpdate()
    {
        print("FIXED UPDATE PATHFINDING");
        rb =  GetComponent<Rigidbody>();
        List <float> angles = new List<float>();
        float closest = 50;
        for(int i = -45; i < 45; i+=5)
        {
            if(!Physics.Raycast(rb.transform.position, new Vector3(rb.transform.rotation.x, rb.transform.rotation.y, rb.transform.rotation.z + i),raycastDistance))
            {
                print("FREE PATH");
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
            rb.transform.Rotate(0, 0, closest - precisionAngle);     
        }else if(closest > 0){
           rb.transform.Rotate(0, 0, closest + precisionAngle);   
        }
       


    }
}
