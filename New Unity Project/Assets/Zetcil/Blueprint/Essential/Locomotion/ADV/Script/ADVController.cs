using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class ADVController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Movement Settings")]
        public float speed = 3.0f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;
        public float smoothSpeed = 10.0f;
        public float smoothDirection = 10.0f;
        public bool canJump = true;

        private Vector3 moveDirection = Vector3.zero;
        private float verticalSpeed = 0.0f;
        private float moveSpeed = 0.0f;
        private bool grounded = false;
        private bool jumping = false;
        private float targetAngle = 0.0f;

        CharacterController controller;

        void Awake()
        {
            moveDirection = transform.TransformDirection(Vector3.forward);
            controller = GetComponent<CharacterController>();
        }

        void Start()
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        void UpdateSmoothedMovementDirection()
        {
            if (isActiveAndEnabled)
            {
                if (GameObject.FindGameObjectWithTag("MainCamera"))
                {
                    var cameraTransform = Camera.main.transform;

                    var forward = cameraTransform.TransformDirection(Vector3.forward);
                    forward.y = 0;
                    forward = forward.normalized;
                    var right = new Vector3(forward.z, 0, -forward.x);

                    var targetDirection = Input.GetAxis("Horizontal") * right + Input.GetAxis("Vertical") * forward;

                    if (targetDirection != Vector3.zero)
                    {
                        moveDirection = Vector3.Lerp(moveDirection, targetDirection, smoothDirection * Time.deltaTime);
                        moveDirection = moveDirection.normalized;
                    }

                    float curSmooth = smoothSpeed * Time.deltaTime;
                    if (!grounded)
                    {
                        curSmooth *= 0.5f;
                    }

                    moveSpeed = Mathf.Lerp(moveSpeed, targetDirection.magnitude * speed, curSmooth);
                }
            }
        }

        void Update()
        {
            if (isEnabled && this.isActiveAndEnabled)
            {
                UpdateSmoothedMovementDirection();

                if (grounded)
                {
                    verticalSpeed = 0.0f;
                    if (canJump == Input.GetKey(KeyCode.Space))
                    {
                        verticalSpeed = jumpSpeed;
                        jumping = true;
                        SendMessage("DidJump", SendMessageOptions.DontRequireReceiver);
                    }
                }
                verticalSpeed -= gravity * Time.deltaTime;

                var movement = moveDirection * moveSpeed + new Vector3(0, verticalSpeed, 0);
                movement *= Time.deltaTime;

                var flags = controller.Move(movement);
                grounded = (flags == CollisionFlags.CollidedBelow);

                transform.rotation = Quaternion.LookRotation(moveDirection);

                if (grounded == jumping)
                {
                    jumping = false;
                    SendMessage("DidLand", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

        float GetSpeed()
        {
            return moveSpeed;
        }

        bool IsJumping()
        {
            return jumping;
        }

        Vector3 GetDirection()
        {
            return moveDirection;
        }

    }
}
