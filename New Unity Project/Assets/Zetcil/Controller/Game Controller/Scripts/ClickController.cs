using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class ClickController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("True Click Settings")]
        public bool usingTrueClickEvent;
        public UnityEvent TrueClickEvent;

        [Header("False Click Settings")]
        public bool usingFalseClickEvent;
        public UnityEvent FalseClickEvent;

        [Header("Readonly Status")]
        [ReadOnly] public bool ClickStatus; 

        // Start is called before the first frame update
        void Start()
        {
            ClickStatus = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseDown()
        {
            ClickStatus = !ClickStatus;
            if (usingTrueClickEvent)
            {
                if (ClickStatus)
                {
                    TrueClickEvent.Invoke();
                }
            }
            if (usingFalseClickEvent)
            {
                if (!ClickStatus)
                {
                    FalseClickEvent.Invoke();
                }
            }
        }

        void InvokeTrueEvent()
        {
            TrueClickEvent.Invoke();
        }

        void InvokeFalseEvent()
        {
            FalseClickEvent.Invoke();
        }

    }
}
