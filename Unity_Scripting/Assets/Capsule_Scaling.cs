using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_Scaling : MonoBehaviour
{
    [SerializeField]
    private Vector3 axes;
    public float scaleUnits;

    // referencia a CapsuleMovement
    private Capsule_Movement movement;
    private void Start()
    {
        movement = GetComponent<Capsule_Movement>();
    }

    private void Update()
    {
        // utilizo el método público de capsuleMovement para acotarlo
        axes = movement.ClampVector(axes);

        transform.localScale += axes * (scaleUnits * Time.deltaTime);
    }
}
