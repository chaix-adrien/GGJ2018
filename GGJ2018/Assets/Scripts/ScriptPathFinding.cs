using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPathFinding : MonoBehaviour 
{
    public float precisionAngle;
    public float raycastDistance;
    private Rigidbody rb;
    private List <float> angles;
    private float closest;
    private Ray obstaclesRay;
    private RaycastHit hit;
    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        angles = new List<float>();
        closest = 50;
        for(float i = -45; i < 45; i+=5)
        {
            obstaclesRay = new Ray(rb.transform.position, new Vector3(rb.transform.rotation.x, rb.transform.rotation.y, rb.transform.rotation.z + i));
            
            if(Physics.Raycast( obstaclesRay, out hit, raycastDistance))
            {
                if(hit.collider.tag != "FullFloor")
                {
                    angles.Add(i);
                }
            }else{
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
