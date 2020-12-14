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
    public class IfController : MonoBehaviour
    {

        public enum CEventType { OnAwake, OnRepeat, OnEvent }
        public enum CKeyType { OnKeyDown, OnKeyPress, OnKeyUp }
        public enum CLogicType { AND, OR, TRUE, FALSE }

        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Logic Operator Settings")]
        public CLogicType LogicType;


        [System.Serializable]
        public class CInputCondition
        {
            [Header("Input Key Condition")]
            public CKeyType KeyType;
            [SearchableEnum] public KeyCode KeyVariables;
            public float CoolDown;
            [HideInInspector]
            public bool isCoolDown; 
            [Header("Condition Status")]
            [ReadOnly] public bool ConditionStatus;
        }

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
        public class CManaCondition
        {
            public VarMana ManaVariables;
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
        public class CExpCondition
        {
            public VarExp ExpVariables;
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
        public class CStringCondition
        {
            public VarString StringVariables;
            [Header("Equal Condition")]
            public bool usingEqualCondition;
            public string EqualConditionValue;
            [Header("Not Equal Condition")]
            public bool usingNotEqualCondition;
            public string NotEqualConditionValue;
            [Header("Condition Status")]
            [ReadOnly] public bool ConditionStatus;
        }


        [System.Serializable]
        public class CBooleanCondition
        {
            public VarBoolean BoolVariables;
            [ReadOnly] public bool ConditionStatus;
        }

        [Header("Condition Logic Settings")]
        [Separator]
        public bool usingConditionLogic;

        [Header("Input Condition")]
        public bool usingInputCondition;
        public CInputCondition[] InputCondition;

        [Header("Variable Condition")]
        public bool usingTimeVariable;
        public CTimeCondition[] TimeCondition;
        [Space(10)]

        public bool usingScoreVariable;
        public CScoreCondition[] ScoreCondition;
        [Space(10)]

        public bool usingHealthVariable;
        public CHealthCondition[] HealthCondition;
        [Space(10)]

        public bool usingManaVariable;
        public CManaCondition[] ManaCondition;
        [Space(10)]

        public bool usingExpVariable;
        public CExpCondition[] ExpCondition;
        [Space(10)]

        public bool usingIntegerVariable;
        public CIntCondition[] IntegerCondition;
        [Space(10)]

        public bool usingFloatVariable;
        public CFloatCondition[] FloatCondition;
        [Space(10)]

        public bool usingStringVariable;
        public CStringCondition[] StringCondition;
        [Space(10)]

        public bool usingBooleanVariable;
        public CBooleanCondition[] BooleanCondition;

        [Header("Event Status Settings")]
        [Separator]
        public bool usingEventStatus;
        [ReadOnly] public bool ConditionResult = false;

        [Header("True Event")]
        public bool usingTrueEventSettings;
        public UnityEvent TrueEventSettings;

        [Header("False Event")]
        public bool usingFalseEventSettings;
        public UnityEvent FalseEventSettings;

        [Header("Checker Condition")]
        public bool RepeatChecking;
        bool isChecking = true;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        void AllCooldown()
        {
            for (int i = 0; i < InputCondition.Length; i++)
            {
                InputCondition[i].isCoolDown = false;
            }
        }

        void Awake()
        {
            for (int i = 0; i < InputCondition.Length; i++)
            {
                InputCondition[i].isCoolDown = false;
            }
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                ExecuteIfController();
            }
        }

        // Use this for initialization
        void Start()
        {
            if (isEnabled)
            {
                for (int i=0; i< InputCondition.Length; i++)
                {
                    InputCondition[i].isCoolDown = false;
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    ExecuteIfController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("ExecuteIfController", Delay);
                    }
                }
            }
        }

        void Update()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval)
                {
                    ExecuteIfController();
                }
            }
        }

        IEnumerator DelaySecond(float aTime)
        {
            yield return new WaitForSeconds(aTime);
        }

        public void InvokeIfController()
        {
            ExecuteIfController();
        }

        void ExecuteCondition()
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
            if (usingManaVariable)
            {
                for (int i = 0; i < ManaCondition.Length; i++)
                {
                    ManaCondition[i].ConditionStatus = false;

                    if (ManaCondition[i].usingEqualCondition && ManaCondition[i].EqualConditionValue == ManaCondition[i].ManaVariables.CurrentValue.ToString())
                    {
                        ManaCondition[i].ConditionStatus = true;
                    }
                    if (ManaCondition[i].usingGreaterCondition && int.Parse(ManaCondition[i].GreaterConditionValue) < ManaCondition[i].ManaVariables.CurrentValue)
                    {
                        ManaCondition[i].ConditionStatus = true;
                    }
                    if (ManaCondition[i].usingLessCondition && int.Parse(ManaCondition[i].LessConditionValue) > ManaCondition[i].ManaVariables.CurrentValue)
                    {
                        ManaCondition[i].ConditionStatus = true;
                    }
                }
            }
            if (usingExpVariable)
            {
                for (int i = 0; i < ExpCondition.Length; i++)
                {
                    ExpCondition[i].ConditionStatus = false;

                    if (ExpCondition[i].usingEqualCondition && ExpCondition[i].EqualConditionValue == ExpCondition[i].ExpVariables.CurrentValue.ToString())
                    {
                        ExpCondition[i].ConditionStatus = true;
                    }
                    if (ExpCondition[i].usingGreaterCondition && int.Parse(ExpCondition[i].GreaterConditionValue) < ExpCondition[i].ExpVariables.CurrentValue)
                    {
                        ExpCondition[i].ConditionStatus = true;
                    }
                    if (ExpCondition[i].usingLessCondition && int.Parse(ExpCondition[i].LessConditionValue) > ExpCondition[i].ExpVariables.CurrentValue)
                    {
                        ExpCondition[i].ConditionStatus = true;
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
                    BooleanCondition[i].ConditionStatus = BooleanCondition[i].BoolVariables.CurrentValue;
                }
            }
            if (usingStringVariable)
            {
                for (int i = 0; i < StringCondition.Length; i++)
                {
                    StringCondition[i].ConditionStatus = false;

                    if (StringCondition[i].usingEqualCondition && StringCondition[i].EqualConditionValue == StringCondition[i].StringVariables.CurrentValue)
                    {
                        StringCondition[i].ConditionStatus = true;
                    }
                    if (StringCondition[i].usingNotEqualCondition && StringCondition[i].NotEqualConditionValue == StringCondition[i].StringVariables.CurrentValue)
                    {
                        StringCondition[i].ConditionStatus = true;
                    }
                }
            }
            if (usingInputCondition)
            {
                for (int i = 0; i < InputCondition.Length; i++)
                {
                    InputCondition[i].ConditionStatus = false;

                    if (InputCondition[i].KeyType == CKeyType.OnKeyDown)
                    {
                        if (Input.GetKeyDown(InputCondition[i].KeyVariables))
                        {
                            InputCondition[i].ConditionStatus = true;
                        }
                    }
                    if (InputCondition[i].KeyType == CKeyType.OnKeyPress)
                    {
                        if (!InputCondition[i].isCoolDown)
                        {
                            if (Input.GetKey(InputCondition[i].KeyVariables))
                            {
                                InputCondition[i].ConditionStatus = true;
                            }

                            InputCondition[i].isCoolDown = true;
                            Invoke("AllCooldown", InputCondition[i].CoolDown);
                        }
                    }
                    if (InputCondition[i].KeyType == CKeyType.OnKeyUp)
                    {
                        if (Input.GetKeyUp(InputCondition[i].KeyVariables))
                        {
                            InputCondition[i].ConditionStatus = true;
                        }
                    }
                }
            }

        }

        void ExecuteEvent()
        {
            if (LogicType == CLogicType.TRUE)
            {
                ConditionResult = true;
            }
            if (LogicType == CLogicType.FALSE)
            {
                ConditionResult = false;
            }
            if (LogicType == CLogicType.AND)
            {
                ConditionResult = true;
            }
            if (LogicType == CLogicType.OR)
            {
                ConditionResult = false;
            }

            if (usingInputCondition)
            {
                for (int i = 0; i < InputCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && InputCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || InputCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingTimeVariable)
            {
                for (int i = 0; i < TimeCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    { 
                        ConditionResult = ConditionResult && TimeCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || TimeCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingScoreVariable)
            {
                for (int i = 0; i < ScoreCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && ScoreCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || ScoreCondition[i].ConditionStatus;
                    }
               }
            }
            if (usingHealthVariable)
            {
                for (int i = 0; i < HealthCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && HealthCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || HealthCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingManaVariable)
            {
                for (int i = 0; i < ManaCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && ManaCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || ManaCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingExpVariable)
            {
                for (int i = 0; i < ManaCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && ManaCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || ManaCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingIntegerVariable)
            {
                for (int i = 0; i < IntegerCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && IntegerCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || IntegerCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingFloatVariable)
            {
                for (int i = 0; i < FloatCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && FloatCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || FloatCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingBooleanVariable)
            {
                for (int i = 0; i < BooleanCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && BooleanCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || BooleanCondition[i].ConditionStatus;
                    }
                }
            }
            if (usingStringVariable)
            {
                for (int i = 0; i < StringCondition.Length; i++)
                {
                    if (LogicType == CLogicType.AND)
                    {
                        ConditionResult = ConditionResult && StringCondition[i].ConditionStatus;
                    }
                    if (LogicType == CLogicType.OR)
                    {
                        ConditionResult = ConditionResult || StringCondition[i].ConditionStatus;
                    }
                }
            }

            if (isChecking)
            {
                if (ConditionResult)
                {
                    if (usingTrueEventSettings)
                    {
                        TrueEventSettings.Invoke();
                        if (!RepeatChecking)
                        {
                            isChecking = false;
                        }
                    }
                }
                else
                {
                    if (usingFalseEventSettings)
                    {
                        FalseEventSettings.Invoke();
                        if (!RepeatChecking)
                        {
                            isChecking = false;
                        }
                    }
                }
            }
        }

        public void ExecuteIfController()
        {
            ExecuteCondition();
            ExecuteEvent();
        }

    }
}
