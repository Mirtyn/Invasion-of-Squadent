using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquillorDispatchDroneScript : ProjectBehavior
{
    [SerializeField] GameObject EnemyDeathExplosion;
    [SerializeField] Transform Parent;

    [SerializeField] GameObject scoreBoard;
    int scorePointsKill = 60;

    [SerializeField] PlayerDamage playerDamage;

    float hitPoints = 1f;

    void OnParticleCollision(GameObject other)
    {
        Death();
    }

    void Death()
    {
        hitPoints = 0f;
        GameObject enemyExp = Instantiate(EnemyDeathExplosion, transform.position, Quaternion.identity);
        enemyExp.transform.parent = Parent;
        Destroy(gameObject);
        scoreBoard.GetComponent<ScoreBoard>().IncreaseScore(scorePointsKill);
    }
}
