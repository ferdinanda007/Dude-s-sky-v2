using UnityEngine;
using System.Collections;

namespace Zetcil
{
    public class RPCController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Main Settings")]
        public Rigidbody2D carRigidbody;

        [Header("Movement Settings")]
        public WheelJoint2D frontwheel;
        public WheelJoint2D backwheel;
        public float speedF;
        public float speedB;
        public float torqueF;
        public float torqueB;
        public bool TractionFront = true;
        public bool TractionBack = true;
        public float carRotationSpeed;

        JointMotor2D motorFront;

        JointMotor2D motorBack;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                if (TractionFront)
                {
                    motorFront.motorSpeed = speedF * -1;
                    motorFront.maxMotorTorque = torqueF;
                    frontwheel.motor = motorFront;
                }

                if (TractionBack)
                {
                    motorBack.motorSpeed = speedF * -1;
                    motorBack.maxMotorTorque = torqueF;
                    backwheel.motor = motorBack;
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                if (TractionFront)
                {
                    motorFront.motorSpeed = speedB * -1;
                    motorFront.maxMotorTorque = torqueB;
                    frontwheel.motor = motorFront;
                }
                if (TractionBack)
                {
                    motorBack.motorSpeed = speedB * -1;
                    motorBack.maxMotorTorque = torqueB;
                    backwheel.motor = motorBack;

                }
            }
            else
            {
                backwheel.useMotor = false;
                frontwheel.useMotor = false;
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                carRigidbody.AddTorque(carRotationSpeed * Input.GetAxisRaw("Vertical") * -1);
            }

        }
    }
}
