using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;
using UnityEngine.Events;

namespace Zetcil
{

    public class ParameterController : MonoBehaviour
    {
        public enum CEventType { OnAwake, OnRepeat, OnKeyboard, OnEvent }
        public enum CParameterType { Int, Float, Bool, Trigger }

        [Space(10)]
        public bool isEnabled;

        [Header("Animation Settings")]
        public Animator TargetAnimator;
        public CEventType EventType;

        [Header("Parameter Settings")] 
        public CParameterType ParameterType;
        public string ParameterName;
        public VarFloat ParameterFloat;
        public VarInteger ParameterInteger;
        public VarBoolean ParameterBoolean;
        public VarBoolean ParameterTrigger;

        [Header("Keyboard Settings")]
        [SearchableEnum] public KeyCode ParameterKey;
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
                if (EventType == CEventType.OnAwake)
                {
                    ExecuteParameter();
                }
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isEnabled)
            {
                if (EventType == CEventType.OnRepeat)
                {
                    ExecuteParameter();
                }
                if (EventType == CEventType.OnKeyboard)
                {
                    if (usingKeyDown && Input.GetKeyDown(ParameterKey))
                    {
                        KeyDownEvent.Invoke();
                        ExecuteParameter();
                    }
                    if (usingKeyPress && Input.GetKey(ParameterKey))
                    {
                        KeyPressEvent.Invoke();
                        ExecuteParameter();
                    }
                    if (usingKeyUp && Input.GetKeyUp(ParameterKey))
                    {
                        KeyUpEvent.Invoke();
                        ExecuteParameter();
                    }
                }
            }
        }

        public void ExecuteParameter()
        {
            if (ParameterType == CParameterType.Float)
            {
                TargetAnimator.SetFloat(ParameterName, ParameterFloat.CurrentValue);
                if (usingAdditionalSettings)
                {
                    AdditionalEvent.Invoke();
                }
            }
            if (ParameterType == CParameterType.Int)
            {
                TargetAnimator.SetInteger(ParameterName, ParameterInteger.CurrentValue);
                if (usingAdditionalSettings)
                {
                    AdditionalEvent.Invoke();
                }
            }
            if (ParameterType == CParameterType.Bool)
            {
                TargetAnimator.SetBool(ParameterName, ParameterBoolean.CurrentValue);
                if (usingAdditionalSettings)
                {
                    AdditionalEvent.Invoke();
                }
            }
            if (ParameterType == CParameterType.Trigger)
            {
                if (ParameterTrigger.CurrentValue) {
                    TargetAnimator.SetTrigger(ParameterName);
                    ParameterTrigger.CurrentValue = false;
                }
                if (usingAdditionalSettings)
                {
                    AdditionalEvent.Invoke();
                }
            }
        }


    }
}
