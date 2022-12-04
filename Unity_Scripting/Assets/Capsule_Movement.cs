using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule_Movement : MonoBehaviour
{
    public float MoveSpeed;
    [SerializeField]
    private Vector3 MoveDirection;

    // probablemente sería mejor utilizar FixedUpdate aquí pero en la actividad se usa Update
    private void Update()
    {
        // desplazamiento con dirección acotada y ajustada al tiempo real 
        transform.Translate(MoveSpeed * Time.deltaTime * ClampVector(MoveDirection));
    }

    public Vector3 ClampVector(Vector3 target)
    {
        float clampedX = Mathf.Clamp(target.x, -1, 1);
        float clampedY = Mathf.Clamp(target.y, -1, 1);
        float clampedZ = Mathf.Clamp(target.z, -1, 1);

        return new Vector3(clampedX,clampedY ,clampedZ);
    }
}
