using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class FlipFlopController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Flip Flop Settings")]
        public float Interval;

        [Header("Flip Settings")]
        public bool usingFlipEvent;
        public UnityEvent FlipEvent;

        [Header("Flop Settings")]
        public bool usingFlopEvent;
        public UnityEvent FlopEvent;

        [Header("Status")]
        [ReadOnly] public float currentClock = 0;

        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("ExecuteFlipFlop", 0, Interval);
        }

        public void ExecuteFlipFlop()
        {
            currentClock++;
            if (currentClock % 2 == 0)
            {
                if (usingFlipEvent)
                {
                    FlipEvent.Invoke();
                }
            }
            else 
            {
                if (usingFlopEvent)
                {
                    FlopEvent.Invoke();
                }
            }
        }

        public void TerminateFlipFlop()
        {
            CancelInvoke();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
