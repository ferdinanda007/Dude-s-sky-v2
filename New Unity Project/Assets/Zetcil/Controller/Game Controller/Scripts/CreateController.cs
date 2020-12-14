/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 // * Desc   : Script untuk mengatur Create objek
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class CreateController : MonoBehaviour
    {
        public enum CEnumAfterCreate { StillWithParent, DetachFromParent }

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
        public CEnumAfterCreate AfterCreate;

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
                InvokeCreateController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeCreateController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeCreateController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeCreateController", 1, Interval);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InvokeCreateController()
        {
            if (usingParent)
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation, TargetParent);
                if (AfterCreate == CEnumAfterCreate.DetachFromParent)
                {
                    temp.transform.parent = null;
                }
                if (temp == null) Debug.Log("Create Failed.");
            }
            else
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation);
                if (temp == null) Debug.Log("Create Failed.");
            }
        }
    }
}
