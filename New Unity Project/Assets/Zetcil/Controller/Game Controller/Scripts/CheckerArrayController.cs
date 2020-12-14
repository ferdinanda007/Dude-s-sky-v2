/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur Event suatu object jika kondisi tertentu terpenuhi
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;
using UnityEngine.Events;

namespace Zetcil
{
    public class CheckerArrayController : MonoBehaviour
    {

        public enum CEventType { InvokeOnAwake, InvokeOnEvent }

        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [System.Serializable]
        public class CTimeCondition
        {
            public VarTime TimeVariables;
            [Header("Equal Condition")]
            public bool usingEqualCondition;
            public string EqualConditionValue;
            [Header("Greater Condition")]
            public bool usingGreaterCondition;
            public string GreaterConditionValue;
            [Header("Less Condition")]
            public bool usingLessCondition;
            public string LessConditionValue;
            [Header("Condition Status")]
            [ReadOnly] public bool ConditionStatus;
        }

        [System.Serializable]
        public class CScoreCondition
        {
            public VarScore ScoreVariables;
            [Header("Equal Condition")]
            public bool usingEqualCondition;
            public string EqualConditionValue;
            [Header("Greater Condition")]
            public bool usingGreaterCondition;
            public string GreaterConditionValue;
            [Header("Less Condition")]
            public bool usingLessCondition;
            public string LessConditionValue;
            [Header("Condition Status")]
            [ReadOnly] public bool ConditionStatus;
        }

        [System.Serializable]
        public class CHealthCondition
        {
            public VarHealth HealthVariables;
            [Header("Equal Condition")]
            public bool usingEqualCondition;
            public string EqualConditionValue;
            [Header("Greater Condition")]
            public bool usingGreaterCondition;
            public string GreaterConditionValue;
            [Header("Less Condition")]
            public bool usingLessCondition;
            public string LessConditionValue;
            [Header("Condition Status")]
            [ReadOnly] public bool ConditionStatus;
        }

        [System.Serializable]
        public class CIntCondition
        {
            public VarInteger IntVariables;
            [Header("Equal Condition")]
            public bool usingEqualCondition;
            public string EqualConditionValue;
            [Header("Greater Condition")]
            public bool usingGreaterCondition;
            public string GreaterConditionValue;
            [Header("Less Condition")]
            public bool usingLessCondition;
            public string LessConditionValue;
            [Header("Condition Status")]
            [ReadOnly] public bool ConditionStatus;
        }

        [System.Serializable]
        public class CFloatCondition
        {
            public VarFloat FloatVariables;
            [Header("Equal Condition")]
            public bool usingEqualCondition;
            public string EqualConditionValue;
            [Header("Greater Condition")]
            public bool usingGreaterCondition;
            public string GreaterConditionValue;
            [Header("Less Condition")]
            public bool usingLessCondition;
            public string LessConditionValue;
            [Header("Condition Status")]
            [ReadOnly] public bool ConditionStatus;
        }

        [System.Serializable]
        public class CBooleanCondition
        {
            public VarBoolean BoolVariables;
            [Header("Equal Condition")]
            public bool usingBooleanCondition;
            public bool BooleanConditionValue;
            [ReadOnly] public bool ConditionStatus;
        }

        [Header("Condition Settings")]
        [Separator]
        public bool usingTimeVariable;
        public CTimeCondition[] TimeCondition;
        [Space(10)]

        public bool usingScoreVariable;
        public CScoreCondition[] ScoreCondition;
        [Space(10)]

        public bool usingHealthVariable;
        public CHealthCondition[] HealthCondition;
        [Space(10)]

        public bool usingIntegerVariable;
        public CIntCondition[] IntegerCondition;
        [Space(10)]

        public bool usingFloatVariable;
        public CFloatCondition[] FloatCondition;
        [Space(10)]

        public bool usingBooleanVariable;
        public CBooleanCondition[] BooleanCondition;

        [Header("True Condition")]
        [Separator]
        public bool usingTrueCondition;
        [ReadOnly] public bool TrueConditionValue = true;
        public UnityEvent TrueConditionEvent;
        bool isTrueInvoke = false;

        [Header("False Condition")]
        public bool usingFalseCondition;
        [ReadOnly] public bool FalseConditionValue = false;
        public UnityEvent FalseConditionEvent;
        bool isFalseInvoke = false;

        [Header("Checker Condition")]
        public bool RepeatChecking;
        bool isChecking = true;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        bool FinalResult = true;

        // Use this for initialization
        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeCheckerArrayController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeCheckerArrayController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeCheckerArrayController", Delay);
                    }
                }
            }
        }

        public void InvokeCheckerArrayController()
        {
            if (usingTimeVariable)
            {
                for (int i = 0; i < TimeCondition.Length; i++)
                {
                    TimeCondition[i].ConditionStatus = false;

                    if (TimeCondition[i].usingEqualCondition && TimeCondition[i].EqualConditionValue == TimeCondition[i].TimeVariables.CurrentValue.ToString())
                    {
                        TimeCondition[i].ConditionStatus = true;
                    }
                    if (TimeCondition[i].usingGreaterCondition && int.Parse(TimeCondition[i].GreaterConditionValue) < TimeCondition[i].TimeVariables.CurrentValue)
                    {
                        TimeCondition[i].ConditionStatus = true;
                    }
                    if (TimeCondition[i].usingLessCondition && int.Parse(TimeCondition[i].LessConditionValue) > TimeCondition[i].TimeVariables.CurrentValue)
                    {
                        TimeCondition[i].ConditionStatus = true;
                    }
                }
            }
            if (usingScoreVariable)
            {
                for (int i = 0; i < ScoreCondition.Length; i++)
                {
                    ScoreCondition[i].ConditionStatus = false;

                    if (ScoreCondition[i].usingEqualCondition && ScoreCondition[i].EqualConditionValue == ScoreCondition[i].ScoreVariables.CurrentValue.ToString())
                    {
                        ScoreCondition[i].ConditionStatus = true;
                    }
                    if (ScoreCondition[i].usingGreaterCondition && int.Parse(ScoreCondition[i].GreaterConditionValue) < ScoreCondition[i].ScoreVariables.CurrentValue)
                    {
                        ScoreCondition[i].ConditionStatus = true;
                    }
                    if (ScoreCondition[i].usingLessCondition && int.Parse(ScoreCondition[i].LessConditionValue) > ScoreCondition[i].ScoreVariables.CurrentValue)
                    {
                        ScoreCondition[i].ConditionStatus = true;
                    }
                }
            }
            if (usingHealthVariable)
            {
                for (int i = 0; i < HealthCondition.Length; i++)
                {
                    HealthCondition[i].ConditionStatus = false;

                    if (HealthCondition[i].usingEqualCondition && HealthCondition[i].EqualConditionValue == HealthCondition[i].HealthVariables.CurrentValue.ToString())
                    {
                        HealthCondition[i].ConditionStatus = true;
                    }
                    if (HealthCondition[i].usingGreaterCondition && int.Parse(HealthCondition[i].GreaterConditionValue) < HealthCondition[i].HealthVariables.CurrentValue)
                    {
                        HealthCondition[i].ConditionStatus = true;
                    }
                    if (HealthCondition[i].usingLessCondition && int.Parse(HealthCondition[i].LessConditionValue) > HealthCondition[i].HealthVariables.CurrentValue)
                    {
                        HealthCondition[i].ConditionStatus = true;
                    }
                }
            }
            if (usingIntegerVariable)
            {
                for (int i = 0; i < IntegerCondition.Length; i++)
                {
                    IntegerCondition[i].ConditionStatus = false;

                    if (IntegerCondition[i].usingEqualCondition && IntegerCondition[i].EqualConditionValue == IntegerCondition[i].IntVariables.CurrentValue.ToString())
                    {
                        IntegerCondition[i].ConditionStatus = true;
                    }
                    if (IntegerCondition[i].usingGreaterCondition && int.Parse(IntegerCondition[i].GreaterConditionValue) < IntegerCondition[i].IntVariables.CurrentValue)
                    {
                        IntegerCondition[i].ConditionStatus = true;
                    }
                    if (IntegerCondition[i].usingLessCondition && int.Parse(IntegerCondition[i].LessConditionValue) > IntegerCondition[i].IntVariables.CurrentValue)
                    {
                        IntegerCondition[i].ConditionStatus = true;
                    }
                }
            }
            if (usingFloatVariable)
            {
                for (int i = 0; i < FloatCondition.Length; i++)
                {
                    FloatCondition[i].ConditionStatus = false;

                    if (FloatCondition[i].usingEqualCondition && FloatCondition[i].EqualConditionValue == FloatCondition[i].FloatVariables.CurrentValue.ToString())
                    {
                        FloatCondition[i].ConditionStatus = true;
                    }
                    if (FloatCondition[i].usingGreaterCondition && int.Parse(FloatCondition[i].GreaterConditionValue) < FloatCondition[i].FloatVariables.CurrentValue)
                    {
                        FloatCondition[i].ConditionStatus = true;
                    }
                    if (FloatCondition[i].usingLessCondition && int.Parse(FloatCondition[i].LessConditionValue) > FloatCondition[i].FloatVariables.CurrentValue)
                    {
                        FloatCondition[i].ConditionStatus = true;
                    }
                }
            }
            if (usingBooleanVariable)
            {
                for (int i = 0; i < BooleanCondition.Length; i++)
                {
                    BooleanCondition[i].ConditionStatus = false;

                    if (BooleanCondition[i].usingBooleanCondition && BooleanCondition[i].BooleanConditionValue == BooleanCondition[i].BoolVariables.CurrentValue)
                    {
                        BooleanCondition[i].ConditionStatus = true;
                    }
                }
            }

            ExecuteEvent();
        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                if (usingInterval)
                {
                    InvokeCheckerArrayController();
                }
            }

        }

        public void ExecuteEvent()
        {
            FinalResult = true;

            if (usingTimeVariable)
            {
                for (int i = 0; i < TimeCondition.Length; i++)
                {
                    FinalResult = FinalResult && TimeCondition[i].ConditionStatus;
                }
            }
            if (usingScoreVariable)
            {
                for (int i = 0; i < ScoreCondition.Length; i++)
                {
                    FinalResult = FinalResult && ScoreCondition[i].ConditionStatus;
                }
            }
            if (usingHealthVariable)
            {
                for (int i = 0; i < HealthCondition.Length; i++)
                {
                    FinalResult = FinalResult && HealthCondition[i].ConditionStatus;
                }
            }
            if (usingIntegerVariable)
            {
                for (int i = 0; i < IntegerCondition.Length; i++)
                {
                    FinalResult = FinalResult && IntegerCondition[i].ConditionStatus;
                }
            }
            if (usingFloatVariable)
            {
                for (int i = 0; i < FloatCondition.Length; i++)
                {
                    FinalResult = FinalResult && FloatCondition[i].ConditionStatus;
                }
            }
            if (usingBooleanVariable)
            {
                for (int i = 0; i < BooleanCondition.Length; i++)
                {
                    FinalResult = FinalResult && BooleanCondition[i].ConditionStatus;
                }
            }

            if (isChecking)
            {
                if (FinalResult)
                {
                    if (usingTrueCondition)
                    {
                        TrueConditionEvent.Invoke();
                        Debug.Log("Execute True Condition Event");
                        if (!RepeatChecking)
                        {
                            isChecking = false;
                        }
                    }
                }
                else if (!FinalResult)
                {
                    if (usingFalseCondition)
                    {
                        FalseConditionEvent.Invoke();
                        Debug.Log("Execute False Condition Event");
                        if (!RepeatChecking)
                        {
                            isChecking = false;
                        }
                    }
                }
            }
        }

    }
}
