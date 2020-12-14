using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zetcil
{

    public class AnimatorController : MonoBehaviour
    {
        public enum CAnimType { AnimationByName, AnimationByParameter }
        public enum CParameterType { Int, Float, Bool, Trigger }
        [Space(10)]
        public bool isEnabled;

        [Header("Animation Settings")]
        public Animator TargetAnimator;
        public CAnimType AnimationType;

        [Header("Animation by Name")]
        public string AnimationStateName;

        [Header("Animation by Parameter")]
        public CParameterType ParameterType;
        public string ParameterName;
        [Header("Transition Settings")]
        public string TransitionValue;
        string PositiveValue;
        string NegativeValue;

        [Header("Additional Settings")]
        public bool usingAdditionalSettings;
        public UnityEvent AdditionalEvent;

        // Start is called before the first frame update
        void Start()
        {
            if (isEnabled)
            {
                if (AnimationType == CAnimType.AnimationByName)
                {
                    TargetAnimator.Play(AnimationStateName);
                }
                if (AnimationType == CAnimType.AnimationByParameter)
                {
                    if (ParameterType == CParameterType.Float)
                    {
                        PositiveValue = TransitionValue;
                        float dummyvalue = float.Parse(PositiveValue) + 1;
                        TargetAnimator.SetFloat(ParameterName, dummyvalue);
                        if (usingAdditionalSettings)
                        {
                            AdditionalEvent.Invoke();
                        }
                    }
                    if (ParameterType == CParameterType.Int)
                    {
                        PositiveValue = TransitionValue;
                        int dummyvalue = int.Parse(PositiveValue) + 1;
                        TargetAnimator.SetInteger(ParameterName, dummyvalue);
                        if (usingAdditionalSettings)
                        {
                            AdditionalEvent.Invoke();
                        }
                    }
                    if (ParameterType == CParameterType.Bool)
                    {
                        PositiveValue = TransitionValue;
                        bool dummyvalue = bool.Parse(PositiveValue);
                        TargetAnimator.SetBool(ParameterName, dummyvalue);
                        if (usingAdditionalSettings)
                        {
                            AdditionalEvent.Invoke();
                        }
                    }
                    if (ParameterType == CParameterType.Trigger)
                    {
                        TargetAnimator.SetTrigger(ParameterName);
                        if (usingAdditionalSettings)
                        {
                            AdditionalEvent.Invoke();
                        }
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
