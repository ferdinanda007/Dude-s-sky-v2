using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;
using UnityEngine.Events;

namespace Zetcil
{

    public class MecanimController : MonoBehaviour
    {
        public enum CEventType { OnAwake, OnRepeat, OnKeyboard, OnEvent, OnVelocity }
        public enum CParameterType { Int, Float, Bool, Trigger }

        [Space(10)]
        public bool isEnabled;

        [Header("Animation Settings")]
        public Animator TargetAnimator;
        public CEventType EventType;

        [Header("Parameter Settings")]
        public CParameterType ParameterType;
        public string ParameterName;
        public float ParameterFloat;
        public int ParameterInteger;
        public bool ParameterBoolean;
        public bool ParameterTrigger;

        [Header("Keyboard Settings")]
        [SearchableEnum] public List<KeyCode> ParameterKey;

        [Header("Input Settings")]
        public bool usingKeyDown;
        public UnityEvent KeyDownEvent;
        public bool usingKeyPress;
        public UnityEvent KeyPressEvent;
        public bool usingKeyUp;
        public UnityEvent KeyUpEvent;

        [Header("Velocity Settings")]
        public bool usingIdle;
        public UnityEvent IdleEvent;
        public bool usingMoving;
        public UnityEvent MovingEvent;

        [Header("Event Settings")]
        public bool usingCustomEvent;
        public UnityEvent CustomEvent;

        [Header("Additional Settings")]
        public bool usingAdditionalSettings;
        public UnityEvent AdditionalEvent;

        CharacterController controller;
        bool TriggerOnce = false;
            
        public void ParameterFloatSetCurrentValue(float aValue)
        {
            ParameterFloat = aValue;
        }
        public void ParameterIntSetCurrentValue(int aValue)
        {
            ParameterInteger = aValue;
        }
        public void ParameterBoolSetCurrentValue(bool aValue)
        {
            ParameterBoolean = aValue;
        }
        public void ParameterTriggerSetCurrentValue(bool aValue)
        {
            ParameterTrigger = aValue;
        }



        // Start is called before the first frame update
        void Start()
        {
            if (isEnabled)
            {
                transform.localScale = new Vector3(1, 1, 1);

                if (EventType == CEventType.OnAwake)
                {
                    ExecuteParameter();
                }
                if (EventType == CEventType.OnEvent || EventType == CEventType.OnKeyboard ||
                    EventType == CEventType.OnVelocity)
                {
                    if (transform.parent != null)
                    {
                        if (transform.parent.GetComponent<CharacterController>())
                        {
                            controller = transform.parent.GetComponent<CharacterController>();
                        }
                    }
                }
            }
        }

        bool isValidKeyDown()
        {
            bool result = false;
            for (int i=0; i<ParameterKey.Count; i++)
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
        void Update()
        {
            if (isEnabled)
            {
                if (EventType == CEventType.OnRepeat)
                {
                    ExecuteParameter();
                }
                if (EventType == CEventType.OnKeyboard)
                {
                    if (usingKeyUp && isValidKeyUp())
                    {
                        KeyUpEvent.Invoke();
                        ExecuteParameter();
                    }
                    if (usingKeyDown && isValidKeyDown())
                    {
                        KeyDownEvent.Invoke();
                        ExecuteParameter();
                    }
                    if (usingKeyPress && isValidKeyPress())
                    {
                        KeyPressEvent.Invoke();
                        ExecuteParameter();
                    }
                    else
                    {
                        KeyUpEvent.Invoke();
                        ExecuteParameter();
                    }
                }
                if (EventType == CEventType.OnVelocity)
                {
                    if (controller)
                    {
                        if (controller.velocity == Vector3.zero)
                        {
                            IdleEvent.Invoke();
                            ExecuteParameter();
                        }
                        else
                        {
                            MovingEvent.Invoke();
                            ExecuteParameter();
                        }
                    }
                }
            }
        }

        public void ExecuteParameter()
        {
            if (ParameterType == CParameterType.Float)
            {
                TargetAnimator.SetFloat(ParameterName, ParameterFloat);
                if (usingAdditionalSettings)
                {
                    AdditionalEvent.Invoke();
                }
            }
            if (ParameterType == CParameterType.Int)
            {
                TargetAnimator.SetInteger(ParameterName, ParameterInteger);
                if (usingAdditionalSettings)
                {
                    AdditionalEvent.Invoke();
                }
            }
            if (ParameterType == CParameterType.Bool)
            {
                TargetAnimator.SetBool(ParameterName, ParameterBoolean);
                if (usingAdditionalSettings)
                {
                    AdditionalEvent.Invoke();
                }
            }
            if (ParameterType == CParameterType.Trigger)
            {
                if (!TriggerOnce)
                {
                    TriggerOnce = true;
                    ParameterTrigger = true;
                    if (ParameterTrigger)
                    {
                        TargetAnimator.SetTrigger(ParameterName);
                        ParameterTrigger = false;
                    }
                    if (usingAdditionalSettings)
                    {
                        AdditionalEvent.Invoke();
                    }
                    Invoke("Cooldown", 1);
                }
            }
        }

        void Cooldown()
        {
            TriggerOnce = false;
        }

    }
}
