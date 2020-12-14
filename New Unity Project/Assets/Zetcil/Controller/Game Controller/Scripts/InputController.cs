/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menunjukkan dasar-dasar pergerakan dalam Unity yang terdiri dari Position, Rotation, & Scale.
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{

    public class InputController : MonoBehaviour
    {

        [System.Serializable]
        public class CKeyboardArray
        {
            [SearchableEnum] public KeyCode InputKeyDown;
            public UnityEvent KeyDownEvent;

            [Space(10)]
            [SearchableEnum] public KeyCode InputKey;
            public UnityEvent KeyEvent;

            [Space(10)]
            [SearchableEnum] public KeyCode InputKeyUp;
            public UnityEvent KeyUpEvent;
        }

        [Space(10)]
        public bool isEnabled;

        [Header("Input Settings")]
        public List<CKeyboardArray> KeyboardInput;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                for (int i = 0; i < KeyboardInput.Count; i++)
                {
                    if (Input.GetKeyDown(KeyboardInput[i].InputKeyDown))
                    {
                        KeyboardInput[i].KeyDownEvent.Invoke();
                    }
                    if (Input.GetKey(KeyboardInput[i].InputKey))
                    {
                        KeyboardInput[i].KeyEvent.Invoke();
                    }
                    if (Input.GetKeyUp(KeyboardInput[i].InputKeyUp))
                    {
                        KeyboardInput[i].KeyUpEvent.Invoke();
                    }
                }
            }
        }
    }
}
