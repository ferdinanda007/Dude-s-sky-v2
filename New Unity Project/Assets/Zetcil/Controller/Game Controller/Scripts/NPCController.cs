using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;
using UnityEngine.Events;

namespace Zetcil
{

    public class NPCController : MonoBehaviour
    {
        public enum CTranslate { VectorUp, VectorDown, VectorForward, VectorBack, VectorLeft, VectorRight }
        public enum CEventType { OnAwake, OnEvent }
        [Space(10)]
        public bool isEnabled;

        [Header("Animation Settings")]
        public CEventType EventType;
        public Animator TargetAnimator;

        [System.Serializable]
        public class CParameterSettings
        {
            public string ParameterName;

            [Header("Transition Settings")]
            public bool usingFloat;
            [ConditionalField("usingFloat")] public float ParameterFloat;
            [Space(10)]

            public bool usingInteger;
            [ConditionalField("usingInteger")] public int ParameterInteger;
            [Space(10)]

            public bool usingBoolean;
            [ConditionalField("usingBoolean")] public bool ParameterBoolean;
            [Space(10)]

            public bool usingTrigger;
            [ConditionalField("usingTrigger")] public bool ParameterTrigger;
        }


        [System.Serializable]
        public class CNPCSettings
        {
            public bool isActive;

            [Header("Animation State Settings")]
            public string AnimationName;

            [Header("Parameter Settings")]
            public CParameterSettings ParameterSetting;

            [Header("Timer Settings")]
            public bool usingTimerSettings;
            public float TimerSettings;

            [Header("Translate Settings")]
            public bool usingTranslateSettings;
            public CTranslate TranslateType;
            public float Speed;

            [Header("Additional Settings")]
            public bool usingAdditionalSettings;
            public UnityEvent AdditionalEvent;
        }

        [Header("NPC Settings")]
        public List<CNPCSettings> NPCSetting;

        [Header("ReadOnly Status")]
        [ReadOnly] public int ClockTimer = 0;


        bool InvokeStatus = false;
        int CurrentIndex;

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

        void InvokeTimer()
        {
            ClockTimer++;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isEnabled)
            {
                if (InvokeStatus)
                {
                    ExecuteParameter();
                }
            }
        }

        public void ExecuteParameter()
        {
            if (!InvokeStatus)
            {
                InvokeStatus = true;
                InvokeRepeating("InvokeTimer", 1, 1);
            }

            if (NPCSetting[CurrentIndex].isActive)
            {
                NPCSetting[CurrentIndex].isActive = false;

                if (NPCSetting[CurrentIndex].ParameterSetting.usingFloat)
                {
                    TargetAnimator.SetFloat(NPCSetting[CurrentIndex].ParameterSetting.ParameterName, NPCSetting[CurrentIndex].ParameterSetting.ParameterFloat);
                    if (NPCSetting[CurrentIndex].usingAdditionalSettings)
                    {
                        NPCSetting[CurrentIndex].AdditionalEvent.Invoke();
                    }
                }
                if (NPCSetting[CurrentIndex].ParameterSetting.usingInteger)
                {
                    TargetAnimator.SetInteger(NPCSetting[CurrentIndex].ParameterSetting.ParameterName, NPCSetting[CurrentIndex].ParameterSetting.ParameterInteger);
                    if (NPCSetting[CurrentIndex].usingAdditionalSettings)
                    {
                        NPCSetting[CurrentIndex].AdditionalEvent.Invoke();
                    }
                }
                if (NPCSetting[CurrentIndex].ParameterSetting.usingBoolean)
                {
                    TargetAnimator.SetBool(NPCSetting[CurrentIndex].ParameterSetting.ParameterName, NPCSetting[CurrentIndex].ParameterSetting.ParameterBoolean);
                    if (NPCSetting[CurrentIndex].usingAdditionalSettings)
                    {
                        NPCSetting[CurrentIndex].AdditionalEvent.Invoke();
                    }
                }
                if (NPCSetting[CurrentIndex].ParameterSetting.usingTrigger)
                {
                    if (NPCSetting[CurrentIndex].ParameterSetting.ParameterTrigger)
                    {
                        TargetAnimator.SetTrigger(NPCSetting[CurrentIndex].ParameterSetting.ParameterName);
                        NPCSetting[CurrentIndex].ParameterSetting.ParameterTrigger = false;
                    }
                    if (NPCSetting[CurrentIndex].usingAdditionalSettings)
                    {
                        NPCSetting[CurrentIndex].AdditionalEvent.Invoke();
                    }
                }
            }

            if (NPCSetting[CurrentIndex].usingTimerSettings)
            {
                if (NPCSetting[CurrentIndex].TimerSettings == ClockTimer)
                {
                    if (CurrentIndex < NPCSetting.Count - 1)
                    {
                        CurrentIndex++;
                    }
                }
            }

            switch (NPCSetting[CurrentIndex].TranslateType)
            {
                case CTranslate.VectorUp:
                    TargetAnimator.gameObject.transform.Translate(Vector3.up * NPCSetting[CurrentIndex].Speed * Time.deltaTime);
                    break;
                case CTranslate.VectorDown:
                    TargetAnimator.gameObject.transform.Translate(Vector3.down * NPCSetting[CurrentIndex].Speed * Time.deltaTime);
                    break;
                case CTranslate.VectorForward:
                    TargetAnimator.gameObject.transform.Translate(Vector3.forward * NPCSetting[CurrentIndex].Speed * Time.deltaTime);
                    break;
                case CTranslate.VectorBack:
                    TargetAnimator.gameObject.transform.Translate(Vector3.back * NPCSetting[CurrentIndex].Speed * Time.deltaTime);
                    break;
                case CTranslate.VectorLeft:
                    TargetAnimator.gameObject.transform.Translate(Vector3.left * NPCSetting[CurrentIndex].Speed * Time.deltaTime);
                    break;
                case CTranslate.VectorRight:
                    TargetAnimator.gameObject.transform.Translate(Vector3.right * NPCSetting[CurrentIndex].Speed * Time.deltaTime);
                    break;
            }
        }


    }
}
