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
    private bool pathFindingNeeded;
    public float checkAngle;
    public float pathAngle;

    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Transform target = GetComponent<ScriptEnemy>().target;
        float i, j;
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
        }else{
            pathFindingNeeded = false;
        }




        //     if (hit.collider.tag != "FullFloor")
        //     {
        //         angles.Add(i);
        //     }
        // }else{
        //             angles.Add(i);
        //         }
        //     }

        //     foreach(float angle in angles)
        //     {
        //         if(Mathf.Abs(angle) < Mathf.Abs(closest))
        //         {
        //             closest = angle;
        //         }                     
        //     }

        //     // The gameobject is oriented at the closest angle
        //     if(closest< 0)
        //     {
        //         rb.transform.Rotate(0, 0, closest - precisionAngle);     
        //     }else if(closest > 0){
        //        rb.transform.Rotate(0, 0, closest + precisionAngle);   
        //     }
    }
}
