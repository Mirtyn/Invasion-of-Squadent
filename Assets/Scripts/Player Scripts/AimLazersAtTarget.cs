using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLazersAtTarget : ProjectBehavior
{
    public Transform Target;
    public float Turnspeed = 0.85f;
    Quaternion rotationGoal;
    Vector3 direction;
    void Update()
    {
        direction = (Target.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, Turnspeed);
    }
}
