/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 // * Desc   : Script untuk mengatur Spawn objek
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class SpawnController : MonoBehaviour
    {
        public enum CEnumAfterSpawn { StillWithParent, DetachFromParent }

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
        public CEnumAfterSpawn AfterSpawn;

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
                InvokeSpawnController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeSpawnController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeSpawnController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeSpawnController", 1, Interval);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExecuteSpawnController()
        {
            InvokeSpawnController();
        }

        public void InvokeSpawnController()
        {
            if (usingParent)
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation, TargetParent);
                if (AfterSpawn == CEnumAfterSpawn.DetachFromParent)
                {
                    temp.transform.parent = null;
                }
                if (temp == null) Debug.Log("Spawn Failed.");
            }
            else
            {
                GameObject temp = Instantiate(TargetPrefab, TargetPosition.position, TargetPosition.rotation);
                if (temp == null) Debug.Log("Spawn Failed.");
            }
        }

    }
}
