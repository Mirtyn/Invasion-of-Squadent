using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : ProjectBehavior
{
    [Header("General Setup Settings")]
    [Tooltip("How fast the playership moves up and down based on the players input.")]
    [SerializeField] float controlSpeed = 30f;
    [Tooltip("How far the ship can move away from the center of the screen on the X-axis. In unity units.")]
    [SerializeField] float clampXRange = 13f;
    [Tooltip("How far the ship can move away from the center of the screen on the Y-axis. In unity units.")]
    [SerializeField] float clampYRange = 11.5f;
    
    [Header("Laser gun array")]
    [Tooltip("All the player lazers(shooters).")]
    [SerializeField] GameObject[] lazers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controllRollFactor = -30f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        ProcessQuiting();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -clampXRange, clampXRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -clampYRange, clampYRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controllRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1") == true)
        {
            SetLazersActive(true);
        }
        else
        {
            SetLazersActive(false);
        }
    }

    void SetLazersActive(bool isActive)
    {
        foreach (GameObject lazer in lazers)
        {
            var emissionModule = lazer.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    void ProcessQuiting()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}