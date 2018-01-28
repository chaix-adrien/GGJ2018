using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptPathFinding : MonoBehaviour 
{
    public float raycastDistance;

    private Rigidbody rb;
    private List <float> angles;
    private float closest;
    private Ray obstaclesRay;
    private RaycastHit hit;
    public bool pathFindingNeeded = false;
    public float checkAngle;
    public float pathAngle;

    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        /*
        if(!GetComponent<ScriptPathFinding>().pathFindingNeeded)
        {
            
        }       
        
         */
        Transform target = GetComponent<ScriptEnemy>().target;
        float i, j, theAngle=1000;
        angles = new List<float>();
        closest = 50;
        obstaclesRay = new Ray(rb.transform.position, target.position - rb.transform.position);
        if (Physics.Raycast(obstaclesRay, out hit, raycastDistance))
        {
            pathFindingNeeded = true;
            for (i = 0; i < checkAngle; i += 5)
            {
                obstaclesRay = new Ray(rb.transform.position, new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + i));
                if (!Physics.Raycast(obstaclesRay, out hit, raycastDistance) || hit.collider.tag != "FullFloor")
                {
                    for (j = i; j < i + pathAngle; j += 2)
                    {
                        obstaclesRay = new Ray(rb.transform.position, new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + j));
                        if (!Physics.Raycast(obstaclesRay, out hit, raycastDistance) || hit.collider.tag != "FullFloor")
                        {

                        }else{
                            break;
                        }
                        angles.Add(i + pathAngle/2);
                    }
                }
            }
            for (i = 0; i > -checkAngle; i -= 5)
            {
                obstaclesRay = new Ray(rb.transform.position, new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + i));
                if (!Physics.Raycast(obstaclesRay, out hit, raycastDistance) || hit.collider.tag != "FullFloor")
                {
                    for (j = i; j < i - pathAngle; j -= 2)
                    {
                        obstaclesRay = new Ray(rb.transform.position, new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + j));
                        if (!Physics.Raycast(obstaclesRay, out hit, raycastDistance) || hit.collider.tag != "FullFloor")
                        {

                        }else{
                            break;
                        }
                        angles.Add(i - pathAngle/2);
                    }
                }
            }
            foreach(float angle in angles)
            {
                if(Math.Abs(angle) < theAngle)
                {
                    theAngle = angle;
                }
            }
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + theAngle, transform.rotation.w);
            rb.velocity = transform.right * GetComponent<ScriptEnemy>().moveSpeed;
        }else{
            pathFindingNeeded = false;
        }


    }
}
