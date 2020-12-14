/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 // * Desc   : Script untuk mengatur instantiate objek
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class InstantiateController : MonoBehaviour
    {
        public enum CEnumAfterInstantiate {  StillWithParent, DetachFromParent }

        [Space(10)]
        public bool isEnabled;
        
        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Prefab Settings")]
        public GameObject TargetPrefab;

        [Header("Position Settings")]
        public Transform TargetPosition;

        [Header("Parent Settings")]
        public bool usingParent;
        public Transform TargetParent;
        public CEnumAfterInstantiate AfterInstantiate;

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
                InvokeInstantiateController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeInstantiateController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeInstantiateController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeInstantiateController", 1, Interval);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExecuteInstantiateObjectWithDelay()
        {
            if (usingDelay)
            {
                Invoke("InvokeInstantiateController", Delay);
            }
        }

        public void InvokeInstantiateController()
        {
            if (usingParent)
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation, TargetParent);
                if (AfterInstantiate == CEnumAfterInstantiate.DetachFromParent)
                {
                    temp.transform.parent = null;
                }
                if (temp == null) Debug.Log("Instantiate Failed.");
            }
            else
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation);
                if (temp == null) Debug.Log("Instantiate Failed.");
            }
        }

        public void ExecuteInstantiateObject()
        {
            if (usingParent)
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation, TargetParent);
                if (AfterInstantiate == CEnumAfterInstantiate.DetachFromParent)
                {
                    temp.transform.parent = null;
                }
                if (temp == null) Debug.Log("Instantiate Failed.");
            }
            else
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation);
                if (temp == null) Debug.Log("Instantiate Failed.");
            }
        }

        public void InstantiateAnotherObjectWithDelay()
        {
            if (usingDelay)
            {
                Invoke("InvokeInstantiateController", Delay);
            }
        }

        public void InstantiateAnotherObject()
        {
            if (usingParent)
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation, TargetParent);
                if (AfterInstantiate == CEnumAfterInstantiate.DetachFromParent)
                {
                    temp.transform.parent = null;
                }
                if (temp == null) Debug.Log("Instantiate Failed.");
            }
            else
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation);
                if (temp == null) Debug.Log("Instantiate Failed.");
            }
        }
    }
}
