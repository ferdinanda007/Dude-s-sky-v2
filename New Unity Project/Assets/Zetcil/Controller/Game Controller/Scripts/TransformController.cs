/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class TransformController : MonoBehaviour
    {
        public enum CTranslate { VectorUp, VectorDown, VectorForward, VectorBack, VectorLeft, VectorRight }

        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("GameObject Settings")]
        public GameObject TargetObject;

        [Header("Position Settings")]
        public bool usingPosition;
        public Vector3 PositionValue;

        [Header("Rotation Settings")]
        public bool usingRotation;
        public Vector3 RotationValue;

        [Header("Scale Settings")]
        public bool usingScale;
        public Vector3 ScaleValue;

        [Header("Translate Settings")]
        public bool usingTranslate;
        public CTranslate TranslateValue;
        public float TranslateSpeed;

        [Header("Ping Pong Settings")]
        public bool usingPingPong;
        public Vector3 PingPongValue;
        public float PingPongSpeed;
        public bool usingPingPongDirection;
        public float Distance;
        public UnityEvent StartDirection;
        public UnityEvent EndDirection;
        Vector3 StartPosition;
        Vector3 EndPosition;

        [Header("Additional Settings")]
        public bool usingAdditionalSettings;
        public UnityEvent AdditionalEvent;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        private Transform follow = null;
        private Vector3 originalLocalPosition;
        private Quaternion originalLocalRotation;

        void Awake()
        {
            originalLocalPosition = Vector3.zero;

            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeTransformController();
            }
        }
        // Start is called before the first frame update
        void Start()
        {

            if (isEnabled)
            {
                originalLocalPosition = Vector3.zero;

                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeTransformController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeTransformController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeTransformController", 1, Interval);
                    }
                }

                if (usingPingPong)
                {
                    StartPosition = TargetObject.transform.position;
                }
            }

        }

        void InvokeTransformController()
        {

            if (usingPosition)
            {
                TargetObject.transform.position += PositionValue;
            }
            if (usingRotation)
            {
                TargetObject.transform.Rotate(RotationValue);
            }
            if (usingScale)
            {
                TargetObject.transform.localScale += ScaleValue;
            }
            if (usingTranslate)
            {
                switch (TranslateValue)
                {
                    case CTranslate.VectorUp:
                        TargetObject.transform.Translate(Vector3.up * TranslateSpeed * Time.deltaTime);
                        break;
                    case CTranslate.VectorDown:
                        TargetObject.transform.Translate(Vector3.down * TranslateSpeed * Time.deltaTime);
                        break;
                    case CTranslate.VectorForward:
                        TargetObject.transform.Translate(Vector3.forward * TranslateSpeed * Time.deltaTime);
                        break;
                    case CTranslate.VectorBack:
                        TargetObject.transform.Translate(Vector3.back * TranslateSpeed * Time.deltaTime);
                        break;
                    case CTranslate.VectorLeft:
                        TargetObject.transform.Translate(Vector3.left * TranslateSpeed * Time.deltaTime);
                        break;
                    case CTranslate.VectorRight:
                        TargetObject.transform.Translate(Vector3.right * TranslateSpeed * Time.deltaTime);
                        break;
                }
            }
            if (usingPingPong)
            {
                float pingPong = Mathf.PingPong(Time.time * PingPongSpeed, 1);
                EndPosition = StartPosition + PingPongValue;
                TargetObject.transform.position = Vector3.Lerp(StartPosition, EndPosition, pingPong);
                if (usingPingPongDirection)
                {
                    if (Vector3.Distance(TargetObject.transform.position, EndPosition) < Distance)
                    {
                        EndDirection.Invoke();
                    }
                    else if (Vector3.Distance(TargetObject.transform.position, StartPosition) < Distance)
                    {
                        StartDirection.Invoke();
                    }
                }

            }
            if (usingAdditionalSettings)
            {
                AdditionalEvent.Invoke();
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isEnabled)
            {
                if (TargetObject != null)
                {
                    if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                    {
                        //InvokeTransformController();
                    }
                }
            }
        }

        void SyncronizeParent()
        {
            transform.position = follow.position;

            follow.RotateAround(follow.position, follow.forward, -originalLocalRotation.eulerAngles.z);
            follow.RotateAround(follow.position, follow.right, -originalLocalRotation.eulerAngles.x);
            follow.RotateAround(follow.position, follow.up, -originalLocalRotation.eulerAngles.y);
            transform.rotation = follow.rotation;

            transform.position += -transform.right * originalLocalPosition.x;
            transform.position += -transform.up * originalLocalPosition.y;
            transform.position += -transform.forward * originalLocalPosition.z;
        }

        public void SetTransformPosition()
        {
            TargetObject.transform.position += PositionValue;
        }

        public void SetTransformPositionX(float aX)
        {
            TargetObject.transform.position += new Vector3(aX, 0, 0);
        }

        public void SetTransformPositionY(float aY)
        {
            TargetObject.transform.position += new Vector3(0, aY, 0);
        }

        public void SetTransformPositionZ(float aZ)
        {
            TargetObject.transform.position += new Vector3(0, 0, aZ);
        }

        public void SetTransformRotation()
        {
            TargetObject.transform.Rotate(RotationValue);
        }

        public void SetFixedTransformRotationX(float aX)
        {
            TargetObject.transform.rotation = Quaternion.Euler(new Vector3(aX, 0, 0));
        }

        public void SetFixedTransformRotationY(float aY)
        {
            TargetObject.transform.rotation = Quaternion.Euler(new Vector3(0, aY, 0));
        }
        public void SetFixedTransformRotationZ(float aZ)
        {
            TargetObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, aZ));
        }

        public void SetTransformRotationX(float aX)
        {
            TargetObject.transform.Rotate(aX, 0, 0);
        }

        public void SetTransformRotationY(float aY)
        {
            TargetObject.transform.Rotate(0, aY, 0);
        }

        public void SetTransformRotationZ(float aZ)
        {
            TargetObject.transform.Rotate(0, 0, aZ);
        }

        public void SetTransformScale()
        {
            TargetObject.transform.localScale += ScaleValue;
        }

        public void SetTransformScaleX(float aX)
        {
            TargetObject.transform.localScale += new Vector3(aX, 0, 0);
        }

        public void SetTransformScaleY(float aY)
        {
            TargetObject.transform.localScale += new Vector3(0, aY, 0);
        }

        public void SetTransformScaleZ(float aZ)
        {
            TargetObject.transform.localScale += new Vector3(0, 0, aZ);
        }
        public void SetTransformTranslateVectorUp()
        {
            TargetObject.transform.Translate(Vector3.up * TranslateSpeed * Time.deltaTime);
        }

        public void SetTransformTranslateVectorDown()
        {
            TargetObject.transform.Translate(Vector3.down * TranslateSpeed * Time.deltaTime);
        }

        public void SetTransformTranslateVectorLeft()
        {
            TargetObject.transform.Translate(Vector3.left * TranslateSpeed * Time.deltaTime);
        }

        public void SetTransformTranslateVectorRight()
        {
            TargetObject.transform.Translate(Vector3.right * TranslateSpeed * Time.deltaTime);
        }

        public void SetTransformTranslateVectorForward()
        {
            TargetObject.transform.Translate(Vector3.forward * TranslateSpeed * Time.deltaTime);
        }

        public void SetTransformTranslateVectorBack()
        {
            TargetObject.transform.Translate(Vector3.back * TranslateSpeed * Time.deltaTime);
        }

        public void ExecuteAdditionalSettings()
        {
            if (usingAdditionalSettings)
            {
                AdditionalEvent.Invoke();
            }
        }
    }
}
