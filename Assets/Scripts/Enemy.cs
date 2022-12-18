using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ProjectBehavior
{
    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
