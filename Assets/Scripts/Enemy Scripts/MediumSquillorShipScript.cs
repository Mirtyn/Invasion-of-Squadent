using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSquillorShipScript : ProjectBehavior
{
    [SerializeField] GameObject EnemyDeathExplosion;
    [SerializeField] GameObject EnemyHitExplosion;
    [SerializeField] Transform Parent;

    [SerializeField] GameObject scoreBoard;
    int scorePointsKill = 300;
    float scorePointsDamage;
    float damageScoreMultiplayer = 0.6f;

    [SerializeField] PlayerDamage playerDamage;

    float hitPoints = 250f;

    float hitPointsBeforeHit;

    void OnParticleCollision(GameObject other)
    {
        Hit();
    }

    void Hit()
    {
        GameObject enemyHitExp = Instantiate(EnemyHitExplosion, transform.position, Quaternion.identity);
        enemyHitExp.transform.parent = Parent;

        hitPointsBeforeHit = hitPoints;

        hitPoints -= playerDamage._PlayerDamage;
        if (hitPoints <= 0)
        {
            hitPoints = 0;
        }

        CalculateHitScorePoints();
        scoreBoard.GetComponent<ScoreBoard>().IncreaseScore((int)scorePointsDamage);

        if (hitPoints <= 0)
        {
            Death();
        }
    }

    void CalculateHitScorePoints()
    {
        scorePointsDamage = (hitPointsBeforeHit - hitPoints) * damageScoreMultiplayer;
    }

    void Death()
    {
        GameObject enemyExp = Instantiate(EnemyDeathExplosion, transform.position, Quaternion.identity);
        enemyExp.transform.parent = Parent;
        Destroy(gameObject);
        scoreBoard.GetComponent<ScoreBoard>().IncreaseScore(scorePointsKill);
    }
}
