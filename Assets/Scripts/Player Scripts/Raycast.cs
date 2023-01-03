using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : ProjectBehavior
{
    Camera cam;
    public LayerMask mask;
    public Vector3 MousePos;
    Vector3 rot;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Draw Ray
        MousePos = Input.mousePosition;
        MousePos.z = 100f;
        MousePos = cam.ScreenToWorldPoint(MousePos);
        Debug.DrawRay(transform.position, MousePos - transform.position, Color.blue);
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        rot = ray.direction;
        
        transform.forward = rot;

        



        //direction = (Target.position - transform.position).normalized;
        //rotationGoal = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, Turnspeed);




        //Physics.Raycast(ray, out hit, 100, mask);

        //Debug.Log(hit.transform.name);
        //hit.transform.GetComponent<Renderer>().material.color = Color.red;




        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 100, mask))
        //    {
        //        Debug.Log(hit.transform.name);
        //        hit.transform.GetComponent<Renderer>().material.color = Color.red;

        //    }
        //}
    }
}
