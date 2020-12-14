/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur event yang akan dijalankan pada satu kondisi
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zetcil
{

    public class EventController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;
        
        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Event Settings")]
        public UnityEvent GameObjectEvent;
        public bool Singleton;
        bool isExecute = false;

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
                InvokeEventController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeEventController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeEventController", Delay);
                    }
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    if (usingInterval)
                    {
                        InvokeRepeating("InvokeEventController", 1, Interval);
                    }
                }
            }
        }

        public void InvokeEventController()
        {
            if (Singleton)
            {
                if (!isExecute)
                {
                    GameObjectEvent.Invoke();
                    isExecute = true;
                }
            } else
            {
                GameObjectEvent.Invoke();
            }
        }

        public void ExecuteEventController()
        {
            if (Singleton)
            {
                if (!isExecute)
                {
                    GameObjectEvent.Invoke();
                    isExecute = true;
                }
            }
            else
            {
                GameObjectEvent.Invoke();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
