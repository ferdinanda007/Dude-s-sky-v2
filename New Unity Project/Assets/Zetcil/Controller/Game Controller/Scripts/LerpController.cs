using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{
    public class LerpController : MonoBehaviour
    {
        public enum CTransformType { Position, Rotation, Scale, Transform }

        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        public bool usingBooleanCondition;
        public VarBoolean BooleanCondition;

        [Header("Lerp Settings")]
        public CTransformType TransformType;

        [Header("GameObject Settings")]
        public GameObject TargetObject;
        public Transform StartTransform;
        public Transform EndTransform;
        
        [Header("Offset Settings")]
        public float Offset;
        public float Speed;

        [Header("CoolDown Settings")]
        public bool usingCoolDown;
        public float CoolDown;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        bool LerpEventCaller = false;

        public void ExecuteLerpEvent()
        {
            LerpEventCaller = true;
            PrepareLerp();
        }

        public void PrepareLerp()
        {
            LerpEventCaller = true;

            if (TransformType == CTransformType.Position || TransformType == CTransformType.Transform)
            {
                TargetObject.transform.position = StartTransform.position;
            }
            if (TransformType == CTransformType.Rotation || TransformType == CTransformType.Transform)
            {
                TargetObject.transform.rotation = Quaternion.Euler(StartTransform.eulerAngles);
            }
            if (TransformType == CTransformType.Scale || TransformType == CTransformType.Transform)
            {
                TargetObject.transform.localScale = StartTransform.localScale;
            }
            if (usingCoolDown) Invoke("LerpCoolDown", CoolDown);
        }

        public void ExecuteLerpController()
        {
            InvokeLerpController();
        }

        public void AwakeLerpController()
        {
            LerpEventCaller = true;

            if (TransformType == CTransformType.Position || TransformType == CTransformType.Transform)
            {
                TargetObject.transform.position = StartTransform.position;
            }
            if (TransformType == CTransformType.Rotation || TransformType == CTransformType.Transform)
            {
                TargetObject.transform.rotation = Quaternion.Euler(StartTransform.eulerAngles);
            }
            if (TransformType == CTransformType.Scale || TransformType == CTransformType.Transform)
            {
                TargetObject.transform.localScale = StartTransform.localScale;
            }

            if (usingCoolDown) Invoke("LerpCoolDown", CoolDown);
        }

        void LerpCoolDown()
        {
            LerpEventCaller = false;
            CancelInvoke();
        }

        void InvokeLerpController()
        {
            if (TransformType == CTransformType.Position || TransformType == CTransformType.Transform)
            {
                if (Vector3.Distance(TargetObject.transform.position, EndTransform.position) > Offset)
                {
                    TargetObject.transform.position = Vector3.Lerp(TargetObject.transform.position, EndTransform.position, Speed * Time.deltaTime);
                } 
            }
            if (TransformType == CTransformType.Rotation || TransformType == CTransformType.Transform)
            {
                if (Vector3.Distance(TargetObject.transform.eulerAngles, EndTransform.eulerAngles) > Offset)
                {
                    TargetObject.transform.rotation = Quaternion.Slerp(TargetObject.transform.rotation, EndTransform.rotation, Speed * Time.deltaTime);
                }
                
            }
            if (TransformType == CTransformType.Scale || TransformType == CTransformType.Transform)
            {
                if (Vector3.Distance(TargetObject.transform.localScale, EndTransform.localScale) > Offset)
                {
                    TargetObject.transform.localScale = Vector3.Lerp(TargetObject.transform.localScale, EndTransform.localScale, Speed * Time.deltaTime);
                }
            }
        }

        // Start is called before the first frame update
        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                AwakeLerpController();
                InvokeLerpController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    AwakeLerpController();
                    InvokeLerpController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        AwakeLerpController();
                        Invoke("InvokeLerpController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval && !usingBooleanCondition)
                    {
                        AwakeLerpController();
                        InvokeRepeating("InvokeLerpController", 1, Interval);
                    }
                    if (usingInterval && usingBooleanCondition)
                    {
                        AwakeLerpController();
                    }
                }

            }

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled && InvokeType == GlobalVariable.CInvokeType.OnInterval && LerpEventCaller)
            {
                if (usingBooleanCondition)
                {
                    if (BooleanCondition.CurrentValue)
                    {
                        InvokeLerpController();
                    }
                }
            }
        }
    }

}
