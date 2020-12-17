using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;
using UnityEngine.Events;

namespace Zetcil
{

    public class LegacyController : MonoBehaviour
    {
        public enum CEventType { OnAwake, OnRepeat, OnKeyboard, OnEvent }

        [Space(10)]
        public bool isEnabled;

        [Header("Animation Settings")]
        public Animator TargetAnimator;
        public CEventType EventType;

        [Header("Animation Settings")]
        public bool usingStaticAnimationName;
        public string StaticAnimationName;

        [Header("Keyboard Settings")]
        [SearchableEnum] public List<KeyCode> ParameterKey;

        [Header("Event Settings")]
        public bool usingKeyDown;
        public UnityEvent KeyDownEvent;
        public bool usingKeyPress;
        public UnityEvent KeyPressEvent;
        public bool usingKeyUp;
        public UnityEvent KeyUpEvent;

        [Header("Additional Settings")]
        public bool usingAdditionalSettings;
        public UnityEvent AdditionalEvent;


        // Start is called before the first frame update
        void Start()
        {
            if (isEnabled)
            {
                transform.localScale = new Vector3(1, 1, 1);

                if (EventType == CEventType.OnAwake)
                {
                    ExecuteStaticAnimation();
                }
            }
        }

        bool isValidKeyDown()
        {
            bool result = false;
            for (int i = 0; i < ParameterKey.Count; i++)
            {
                if (Input.GetKeyDown(ParameterKey[i]))
                {
                    result = true;
                }
            }
            return result;
        }

        bool isValidKeyPress()
        {
            bool result = false;
            for (int i = 0; i < ParameterKey.Count; i++)
            {
                if (Input.GetKey(ParameterKey[i]))
                {
                    result = true;
                }
            }
            return result;
        }

        bool isValidKeyUp()
        {
            bool result = false;
            for (int i = 0; i < ParameterKey.Count; i++)
            {
                if (Input.GetKeyUp(ParameterKey[i]))
                {
                    result = true;
                }
            }
            return result;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isEnabled)
            {
                if (EventType == CEventType.OnRepeat)
                {
                    ExecuteStaticAnimation();
                }
                if (EventType == CEventType.OnKeyboard)
                {
                    if (usingKeyUp && isValidKeyUp())
                    {
                        KeyUpEvent.Invoke();
                        ExecuteStaticAnimation();
                    }
                    if (usingKeyDown && isValidKeyDown())
                    {
                        KeyDownEvent.Invoke();
                        ExecuteStaticAnimation();
                    }
                    if (usingKeyPress && isValidKeyPress())
                    {
                        KeyPressEvent.Invoke();
                        ExecuteStaticAnimation();
                    }
                    else
                    {
                        KeyUpEvent.Invoke();
                        ExecuteStaticAnimation();
                    }
                }
            }
        }

        public void ExecuteStaticAnimation()
        {
            if (usingStaticAnimationName)
            {
                TargetAnimator.Play(StaticAnimationName);
            }
        }

        public void ExecuteDynamicAnimation(string AnimationName)
        {
            TargetAnimator.Play(AnimationName);
        }
    }
}
