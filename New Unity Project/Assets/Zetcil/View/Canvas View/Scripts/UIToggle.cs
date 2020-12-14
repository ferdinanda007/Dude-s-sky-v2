/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk membuat toggle gameobject
 **************************************************************************************************************/

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Zetcil
{
    public class UIToggle : MonoBehaviour
    {

        public enum CToggleType { ToggleGroup, ToggleEach }

        [Space(10)]
        public bool isEnabled;

        [Header("Toggle On Event")]
        public bool usingToggleOn;
        public UnityEvent ToggleOnEvent;

        [Header("Toggle Off Event")]
        public bool usingToggleOff;
        public UnityEvent ToggleOffEvent;

        [Header("Toggle Settings")]
        public bool usingToggleGroup;
        public CToggleType ToggleType;

        [System.Serializable]
        public class CToggleObject
        {
            public GameObject TargetObject;
            public KeyCode TriggerKey;
        }

        public CToggleObject[] ToggleObject;

        public void InvokeChangeToggleStatus(Toggle aValue)
        {
            if (aValue.isOn)
            {
                InvokeToggleOnEvent();
            } else
            {
                InvokeToggleOffEvent();
            }
        }

        public void InvokeToggleOnEvent()
        {
            if (isEnabled && usingToggleOn)
            {
                ToggleOnEvent.Invoke();
            }
        }

        public void InvokeToggleOffEvent()
        {
            if (isEnabled && usingToggleOff)
            {
                ToggleOffEvent.Invoke();
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled && usingToggleGroup)
            {
                for (int i = 0; i < ToggleObject.Length; i++)
                {
                    if (ToggleType == CToggleType.ToggleEach)
                    {
                        if (Input.GetKeyUp(ToggleObject[i].TriggerKey))
                        {
                            ToggleObject[i].TargetObject.SetActive(!ToggleObject[i].TargetObject.activeSelf);
                        }
                    }
                    else if (ToggleType == CToggleType.ToggleGroup)
                    {
                        if (Input.GetKeyUp(ToggleObject[i].TriggerKey))
                        {
                            for (int j = 0; j < ToggleObject.Length; j++)
                            {
                                ToggleObject[j].TargetObject.SetActive(false);
                            }
                            ToggleObject[i].TargetObject.SetActive(!ToggleObject[i].TargetObject.activeSelf);
                        }
                    }
                }
            }
        }
    }
}
