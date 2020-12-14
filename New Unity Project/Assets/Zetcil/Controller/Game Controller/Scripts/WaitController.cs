/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk membuat mekanisme delay
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zetcil
{

    public class WaitController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Wait Function")]
        public UnityEvent WaitFunction;

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
                InvokeWaitController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeWaitController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeWaitController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeWaitController", 1, Interval);
                    }
                }
            }
        }

        public void InvokeWaitController()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake ||
                InvokeType == GlobalVariable.CInvokeType.OnEvent)
            {
                Invoke("ExecWait", Delay);
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
            {
                if (usingDelay)
                {
                    Invoke("ExecWait", Delay);
                }
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
            {
                if (usingInterval)
                {
                    InvokeRepeating("ExecWait", 1, Interval);
                }
            }
        }

        void ExecWait()
        {
            WaitFunction.Invoke();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
