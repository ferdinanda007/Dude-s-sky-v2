/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script editor untuk global switch gameobject yang sama
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zetcil
{
    public class SwitchController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Switch Action Settings")]
        public KeyCode TriggerKey1;
        public UnityEvent KeyCondition1;
        [Space(10)]
        public KeyCode TriggerKey2;
        public UnityEvent KeyCondition2;

        bool Condition = true;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (Input.GetKeyDown(TriggerKey1) && Condition)
            {
                Condition = false;
                KeyCondition1.Invoke();
            }
            else if (Input.GetKeyDown(TriggerKey2) && !Condition)
            {
                Condition = true;
                KeyCondition2.Invoke();
            }
        }
    }
}
