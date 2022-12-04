using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tank_Controller : MonoBehaviour
{
    public float speed;
    public float angularSpeed;

    private void Update()
    {
        // Rotacion
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * (-angularSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * (angularSpeed * Time.deltaTime));
        }
        // Movimiento
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (speed * Time.deltaTime));
        }
    }




}
