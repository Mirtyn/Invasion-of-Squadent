using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : ProjectBehavior
{
    float controlSpeed = 30f;
    float clampXRange = 10f;
    float clampYRange = 9f;

    float xThrow;
    float yThrow;

    float positionPitchFactor = -2f;
    float controlPitchFactor = -20f;
    float positionYawFactor = 2f;
    float controllRollFactor = -30f;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
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
}