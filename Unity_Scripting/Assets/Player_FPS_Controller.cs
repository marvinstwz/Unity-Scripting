using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FPS_Controller : MonoBehaviour
{
    public GameObject cam;
    public float walkSpeed = 5f;
    public float hRotationSpeed = 100f;
    public float vRotationSpeed = 80f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameObject.Find("Capsula").SetActive(false);
    }

    private float hMovement;
    private float vMovement;
    private Vector3 movementDirection;

    private float vCamRotation;
    private float hPlayerRotation;

    private void Update()
    {
        Movement();
        Rotation();       
    }

    private void Movement()
    {
        hMovement = Input.GetAxisRaw("Horizontal");
        vMovement = Input.GetAxisRaw("Vertical");

        movementDirection = hMovement * Vector3.right + vMovement * Vector3.forward;
        transform.Translate(movementDirection * (walkSpeed * Time.deltaTime));
    }

    private void Rotation()
    {
        vCamRotation = Input.GetAxis("Mouse Y") * vRotationSpeed * Time.deltaTime;
        hPlayerRotation = Input.GetAxis("Mouse X") * hRotationSpeed * Time.deltaTime;

        transform.Rotate(0f, hPlayerRotation, 0f);
        cam.transform.Rotate(-vCamRotation, 0f, 0f);
    }
}
