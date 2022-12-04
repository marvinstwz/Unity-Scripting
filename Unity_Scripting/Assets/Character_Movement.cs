using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    [Range(0.01f, 1f)]
    public float forwardJumpFactor = 0.05f;
    public float gravity = -9.8f;
    public float DashFactor = 2f;
    public Vector3 Drag = new Vector3(1f,2f,1f);
    public float smoothTime = 0.15f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private Vector3 smoothMoveDirection;
    private Vector3 smoother;
    private Vector3 horizontalVelocity;

    public bool isGrounded { get { return controller.isGrounded; } }
    public float currentSpeed { get { return horizontalVelocity.magnitude; } }
    public float currentNormalizedSpeed { get { return horizontalVelocity.normalized.magnitude; } }


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void moveCharacter(float h, float v, bool j, bool dash)
    {
        float delta = Time.deltaTime;
        float dashF = 1f;
        if (controller.isGrounded)
        {
            moveDirection = (h * transform.right + v * transform.forward).normalized;
            if (dash)
            {
                dashF = DashFactor;
            }
            if (j)
            {
                if (Mathf.Abs(moveDirection.x) > 0f || Mathf.Abs(moveDirection.z) > 0f)
                {
                    moveDirection += moveDirection.normalized * (Mathf.Sqrt(jumpHeight * forwardJumpFactor * -gravity / 2) * dashF);
                }

                moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        // grav
        moveDirection.y += gravity * delta;

        // drag
        moveDirection.x /= 1 + Drag.x * delta;
        moveDirection.y /= 1 + Drag.y * delta;
        moveDirection.z /= 1 + Drag.z * delta;

        // smoothDirection
        smoothMoveDirection = Vector3.SmoothDamp(smoothMoveDirection, moveDirection, ref smoother, smoothTime);

        // jump not smoothed
        smoothMoveDirection.y = moveDirection.y;

        // apply move
        controller.Move(smoothMoveDirection * (delta * speed * dashF));

        // cache horizontal speed
        horizontalVelocity.Set(controller.velocity.x, 0 , controller.velocity.z);
    }
}
