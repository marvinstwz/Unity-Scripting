using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public GameObject camerasParent;
    public float hRotationSpeed = 100f;
    public float vRotationSpeed = 80f;
    public float maxVerticalAngle;
    public float minVerticalAngle;
    public float smoothTime = 0.05f;

    float vCamRotationAngles;
    float hPlayerRotation;
    float currentHVelocity;
    float currentVvelocity;
    float targetCamEulers;
    Vector3 targetCamRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void HandleRotation(float hInput, float vInput)
    {
        // getRotation based on input
        float targetPlayerRotation = hInput * hRotationSpeed * Time.deltaTime;
        targetCamEulers += vInput * vRotationSpeed * Time.deltaTime;

        // player rotation
        hPlayerRotation = Mathf.SmoothDamp(hPlayerRotation, targetPlayerRotation, ref currentHVelocity, smoothTime);
        transform.Rotate(0f, hPlayerRotation, 0f);

        // cam rotation
        targetCamEulers = Mathf.Clamp(targetCamEulers, minVerticalAngle, maxVerticalAngle);
        vCamRotationAngles = Mathf.SmoothDamp(vCamRotationAngles, targetCamEulers, ref currentVvelocity, smoothTime);
        targetCamRotation.Set(-vCamRotationAngles, 0f, 0f);
        camerasParent.transform.localEulerAngles = targetCamRotation;


    }

}
