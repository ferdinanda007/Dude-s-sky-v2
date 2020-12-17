using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class MMOController : MonoBehaviour
    {
        public enum CMoveDirection { XYAxis, XZAxis }

        [Space(10)]
        public bool isEnabled;

        [Header("Joystick Settings")]
        public CMoveDirection MoveDirection;
        public MMOJoystickController joystickMove;
        public float speed = 10f;

        CharacterController controller;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            transform.localScale = new Vector3(1, 1, 1);
        }

        void Update()
        {
            if (isEnabled)
            {
                if (joystickMove && joystickMove.IsWorking)
                {
                    if (MoveDirection == CMoveDirection.XYAxis)
                    {
                        transform.position += (Vector3)joystickMove.Output * speed * Time.deltaTime;
                        //transform.rotation = Quaternion.FromToRotation(Vector3.up, joystickLook.Output);
                    }
                    else if (MoveDirection == CMoveDirection.XZAxis)
                    {
                        Vector3 joyMove = (Vector3)joystickMove.Output;
                        joyMove.z = joyMove.y;
                        joyMove.y = 0;
                        //transform.position += (Vector3)joyMove * speed * Time.deltaTime;
                        controller.Move((Vector3)joyMove * speed * Time.deltaTime);

                        transform.rotation = Quaternion.FromToRotation(Vector3.forward, joyMove);
                    }
                }
                //transform.Translate(joystickMove.Output * speed * Time.deltaTime);
                //-- to be defined
                //if (joystickLook && joystickLook.IsWorking)
                //{
                //    transform.rotation = Quaternion.FromToRotation(Vector3.up, joystickLook.Output);
                    //float angle = Vector2.SignedAngle(Vector3.up, joystickLook.Output);
                    //transform.localRotation = Quaternion.Euler(0f, 0f, angle);

                    //transform.localRotation = Quaternion.LookRotation(joystickLook.Output);
                //}
            }
        }
    }
}
