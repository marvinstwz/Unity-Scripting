using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_Rotation : MonoBehaviour
{
    public float RotationSpeed;
    public Vector3 RotationAxis;

    // guardo referencia al movimiento para acceder al clamp de Vector
    private Capsule_Movement movement;
    private void Start()
    {
        movement = GetComponent<Capsule_Movement>();
    }

    private void Update()
    {
        transform.Rotate(movement.ClampVector(RotationAxis * RotationSpeed * Time.deltaTime)) ;
    }
}
