using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : ProjectBehavior
{
    [SerializeField] ParticleSystem Explosion1;
    [SerializeField] ParticleSystem Explosion2;
    [SerializeField] ParticleSystem Explosion3;
    [SerializeField] ParticleSystem BiggestExplosion;
    [SerializeField] ParticleSystem ExplodeCamParticle;
    float loadDelay = 2.75f;
    float explodeCam = 2.25f;
    float RandomDeathExplosionDelay;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        RandomDeathExplosionDelay = UnityEngine.Random.Range(0.0f, 1f);
        Invoke("Exp1", RandomDeathExplosionDelay);
        RandomDeathExplosionDelay = UnityEngine.Random.Range(0.0f, 1f);
        Invoke("Exp2", RandomDeathExplosionDelay);
        RandomDeathExplosionDelay = UnityEngine.Random.Range(0.0f, 1f);
        Invoke("Exp3", RandomDeathExplosionDelay);
        RandomDeathExplosionDelay = UnityEngine.Random.Range(0.2f, 0.8f);
        Invoke("BigExp", RandomDeathExplosionDelay + 0.75f);
        Invoke("DisapearPlayerAfterDeath", RandomDeathExplosionDelay + 1f);
        Invoke("ExplodeCam", explodeCam);
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    // "Exp1/2/3 = Explosion"
    void Exp1()
    {
        Explosion1.Play();
    }

    void Exp2()
    {
        Explosion2.Play();
    }

    void Exp3()
    {
        Explosion3.Play();
    }

    void BigExp()
    {
        BiggestExplosion.Play();
    }

    void DisapearPlayerAfterDeath()
    {
        GetComponent<MeshRenderer>().enabled = false;
        Explosion1.Stop();
        Explosion2.Stop();
        Explosion3.Stop();
    }

    void ExplodeCam()
    {
        ExplodeCamParticle.Play();
    }
}
