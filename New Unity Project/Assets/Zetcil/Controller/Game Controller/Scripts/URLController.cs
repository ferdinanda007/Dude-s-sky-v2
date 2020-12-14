using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class URLController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("URL Settings")]
        public string URL;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeURLController();
            }
        }

        void Start()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnStart)
            {
                InvokeURLController();
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
            {
                if (usingDelay)
                {
                    Invoke("InvokeURLController", Delay);
                }
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
            {
                if (usingInterval)
                {
                    InvokeRepeating("InvokeURLController", 1, Interval);
                }
            }
        }

        public void InvokeURLController()
        {
            Application.OpenURL(URL);
        }

        public void InvokeURLController(string aURL)
        {
            Application.OpenURL(aURL);
        }

        public void ExecuteURLController()
        {
            Application.OpenURL(URL);
        }

        public void ExecuteURLController(string aURL)
        {
            Application.OpenURL(aURL);
        }
    }
}
