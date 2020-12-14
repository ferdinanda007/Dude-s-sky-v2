/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur proses destroy suatu objek
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class DestroyController : MonoBehaviour
    {

        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("GameObject Settings")]
        public bool usingTargetGameObject;
        public GameObject TargetGameObject;

        [Header("GameObjectName Settings")]
        public bool usingTargetGameObjectName;
        public string TargetGameObjectName;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        // Use this for initialization
        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeDestroyController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeDestroyController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeDestroyController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeDestroyController", 1, Interval);
                    }
                }
            }
        }

        public void ExecuteDestroyController()
        {
            InvokeDestroyController();
        }

        public void InvokeDestroyController()
        {
            if (usingTargetGameObjectName)
            {
                GameObject temp = GameObject.Find(TargetGameObjectName);
                Destroy(temp);
                usingTargetGameObjectName = false;
                TargetGameObjectName = "";
            }
            if (usingTargetGameObject)
            {
                Destroy(TargetGameObject);
                usingTargetGameObject = false;
                TargetGameObject = null;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
