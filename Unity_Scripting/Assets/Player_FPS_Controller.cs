using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FPS_Controller : MonoBehaviour
{
    public GameObject cam;

    private Character_Movement movement;
    public float walkSpeed = 5f;
    public float hRotationSpeed = 100f;
    public float vRotationSpeed = 80f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        movement = GetComponent<Character_Movement>();
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
        // ahora se encargará MouseLook de la rotación
        //Rotation();       
    }

    private void Movement()
    {
        hMovement = Input.GetAxisRaw("Horizontal");
        vMovement = Input.GetAxisRaw("Vertical");


        movement.moveCharacter(hMovement, vMovement, Input.GetButtonDown("Jump"), Input.GetButtonDown("Dash"));
    }

    private void Rotation()
    {
        vCamRotation = Input.GetAxis("Mouse Y") * vRotationSpeed * Time.deltaTime;
        hPlayerRotation = Input.GetAxis("Mouse X") * hRotationSpeed * Time.deltaTime;

        transform.Rotate(0f, hPlayerRotation, 0f);
        cam.transform.Rotate(-vCamRotation, 0f, 0f);
    }
}
