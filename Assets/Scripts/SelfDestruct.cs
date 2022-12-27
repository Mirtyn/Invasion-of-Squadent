using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : ProjectBehavior
{
    [SerializeField] float destroyDelay = 3f;
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}
