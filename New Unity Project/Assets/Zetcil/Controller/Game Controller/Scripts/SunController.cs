/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk membuat auto day/night
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{
    public class SunController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Light Settings")]
        public GameObject DirectLight;
        public Vector3 RotateDirection;
        public float RotateDelay;

        [Header("Key Settings")]
        public bool usingKeyboard;
        public KeyCode TriggerForwardKey;
        public KeyCode TriggerBackwardKey;
        public int Speed;

        [Header("Readonly Value")]
        [ReadOnly] public float TimeElapsed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                if (usingKeyboard && Input.GetKey(TriggerForwardKey))
                {
                    DirectLight.transform.Rotate(RotateDirection * Speed);
                }
                else
                if (usingKeyboard && Input.GetKey(TriggerBackwardKey))
                {
                    DirectLight.transform.Rotate(RotateDirection * -Speed);
                }
                else
                {
                    DirectLight.transform.Rotate(RotateDirection * RotateDelay);
                    TimeElapsed = TimeElapsed + RotateDelay;
                }

            }
        }
    }
}
