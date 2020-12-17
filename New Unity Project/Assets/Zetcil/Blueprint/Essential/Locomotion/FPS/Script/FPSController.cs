using UnityEngine;

namespace Zetcil
{
    public class FPSController : MonoBehaviour
    {
        public enum CMovementType { Keyboard, Dpad }

        [Space(10)]
        public bool isEnabled;

        [Header("Camera Settings")]
        public Camera TargetCamera;

        [Header("Movement Settings")]
        public CMovementType MovementType;
        public float walkSpeed = 6.0F;
        public float jumpSpeed = 8.0F;
        public float runSpeed = 8.0F;
        public float gravity = 20.0F;

        [Header("Dpad Settings")]
        public bool usingDpad;
        public FPSDpadController DpadController;

        private Vector3 moveDirection = Vector3.zero;
        private CharacterController controller;

        bool isJump = false;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            transform.localScale = new Vector3(1, 1, 1);
        }

        void Update()
        {
            if (controller.isGrounded)
            {
                if (MovementType == CMovementType.Keyboard)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDirection = TargetCamera.transform.TransformDirection(moveDirection);
                    moveDirection *= walkSpeed;
                    if (Input.GetKey(KeyCode.Space))
                        InvokeJump();

                } else if (MovementType == CMovementType.Dpad)
                {
                    if (usingDpad)
                    {
                        moveDirection = new Vector3(DpadController.Output.x, 0, DpadController.Output.y);
                        moveDirection = TargetCamera.transform.TransformDirection(moveDirection);
                        moveDirection *= walkSpeed;
                        if (isJump)
                        {
                            isJump = false;
                            moveDirection.y = jumpSpeed;
                        }
                    }

                }
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        public void InvokeJump()
        {
            moveDirection.y = jumpSpeed;
            isJump = true;
        }
    }

}