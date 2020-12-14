using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class ActivationController : MonoBehaviour
    {
        public enum CObjectType { GameObject, MeshRenderer, Collider }
        public enum CStatusType { True, False }

        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("GameObject Settings")]
        public CObjectType ObjectType;
        public CStatusType StatusType;

        [Header("GameObject List")]
        public List<GameObject> TargetGameObject;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        [Header("Events Settings")]
        public bool usingActivationEvent;
        public UnityEvent ActivationEvent;

        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeActivationController();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnStart)
            {
                InvokeActivationController();
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
            {
                if (usingDelay)
                {
                    Invoke("InvokeActivationController", Delay);
                }
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
            {
                if (usingInterval)
                {
                    InvokeRepeating("InvokeActivationController", 1, Interval);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InvokeActivationController()
        {
            ExecuteActivation();
        }
        public void ExecuteActivation()
        {
            bool objectStatus = StatusType == CStatusType.True;
            for (int i = 0; i < TargetGameObject.Count; i++)
            {
                if (ObjectType == CObjectType.GameObject)
                {
                    TargetGameObject[i].SetActive(objectStatus);
                }
                if (ObjectType == CObjectType.MeshRenderer)
                {
                    if (TargetGameObject[i].GetComponent<MeshRenderer>())
                    {
                        TargetGameObject[i].GetComponent<MeshRenderer>().enabled = objectStatus;
                    }
                }
                if (ObjectType == CObjectType.Collider)
                {
                    if (TargetGameObject[i].GetComponent<BoxCollider>())
                    {
                        TargetGameObject[i].GetComponent<BoxCollider>().enabled = objectStatus;
                    }
                    if (TargetGameObject[i].GetComponent<SphereCollider>())
                    {
                        TargetGameObject[i].GetComponent<SphereCollider>().enabled = objectStatus;
                    }
                }
            }
            if (usingActivationEvent)
            {
                ActivationEvent.Invoke();
            }
        }
    }
}
