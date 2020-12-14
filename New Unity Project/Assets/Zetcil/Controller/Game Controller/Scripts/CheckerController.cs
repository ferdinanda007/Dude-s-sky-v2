/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur action suatu object jika kondisi tertentu terpenuhi secara otomatis
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;
using UnityEngine.Events;

namespace Zetcil
{
    public class CheckerController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Invoke Settings")]
        public GlobalVariable.CInvokeType InvokeType;

        [Header("Condition Settings")]
        [Separator]
        public GlobalVariable.CVariableType VariableType;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarTime TimeVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarHealth HealthVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarMana ManaVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarExp ExpVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarScore ScoreVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarInteger IntVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarFloat FloatVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarString StringVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarBoolean BoolVariables;
        [Tooltip("Nilai atribut/variable ini TIDAK BOLEH kosong")] public VarObject ObjectVariables;

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

        [Header("Equal Condition")]
        [Separator]
        public bool usingEqualCondition;
        public string EqualConditionValue;
        public UnityEvent EqualConditionEvent;
        bool isEqualInvoke = false;

        [Header("Not Equal Condition")]
        public bool usingNotEqualCondition;
        public string NotEqualConditionValue;
        public UnityEvent NotEqualConditionEvent;
        bool isNotEqualInvoke = false;

        [Header("Tag Equal Condition")]
        [Separator]
        public bool usingTagEqualCondition;
        [Tag] public string TagEqualConditionValue;
        public UnityEvent TagEqualConditionEvent;
        bool isTagEqualInvoke = false;

        [Header("Not Tag Equal Condition")]
        public bool usingNotTagEqualCondition;
        [Tag] public string NotTagEqualConditionValue;
        public UnityEvent NotTagEqualConditionEvent;
        bool isNotTagEqualInvoke = false;

        [Header("Name Equal Condition")]
        public bool usingNameEqualCondition;
        public string NameEqualConditionValue;
        public UnityEvent NameEqualConditionEvent;
        bool isNameEqualInvoke = false;

        [Header("Not Name Equal Condition")]
        public bool usingNotNameEqualCondition;
        [Tag] public string NotNameEqualConditionValue;
        public UnityEvent NotNameEqualConditionEvent;
        bool isNotNameEqualInvoke = false;

        [Header("Greater Condition")]
        public bool usingGreaterCondition;
        public string GreaterConditionValue;
        public UnityEvent GreaterConditionEvent;
        bool isGreaterInvoke = false;

        [Header("Less Condition")]
        public bool usingLessCondition;
        public string LessConditionValue;
        public UnityEvent LessConditionEvent;
        bool isLessInvoke = false;

        [Header("Delay Settings")]
        public bool usingDelay;
        public float Delay;

        [Header("Interval Settings")]
        public bool usingInterval;
        public float Interval;

        // Use this for initialization
        void Awake()
        {
            if (InvokeType == GlobalVariable.CInvokeType.OnAwake)
            {
                InvokeCheckerController();
            }
        }

        void Start()
        {
            if (isEnabled)
            {
                isChecking = true;
                if (InvokeType == GlobalVariable.CInvokeType.OnStart)
                {
                    InvokeCheckerController();
                }
                if (InvokeType == GlobalVariable.CInvokeType.OnDelay)
                {
                    if (usingDelay)
                    {
                        Invoke("InvokeCheckerController", Delay);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                if (InvokeType == GlobalVariable.CInvokeType.OnInterval && usingInterval)
                {
                    InvokeCheckerController(); 
                }
            }

        }

        public void InvokeCheckerController()
        {
            if (isChecking)
            {
                if (VariableType == GlobalVariable.CVariableType.timeVar)
                {
                    if (usingEqualCondition && EqualConditionValue == TimeVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != TimeVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingGreaterCondition && int.Parse(GreaterConditionValue) < TimeVariables.CurrentValue)
                    {
                        if (!isGreaterInvoke)
                        {
                            isGreaterInvoke = true;
                            GreaterConditionEvent.Invoke();
                            Invoke("GreaterCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingLessCondition && int.Parse(LessConditionValue) > TimeVariables.CurrentValue)
                    {
                        if (!isLessInvoke)
                        {
                            isLessInvoke = true;
                            LessConditionEvent.Invoke();
                            Invoke("LessCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }
            }

            if (VariableType == GlobalVariable.CVariableType.healthVar)
            {
                if (isChecking)
                {
                    if (usingEqualCondition && EqualConditionValue == HealthVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != HealthVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingGreaterCondition && int.Parse(GreaterConditionValue) < HealthVariables.CurrentValue)
                    {
                        if (!isGreaterInvoke)
                        {
                            isGreaterInvoke = true;
                            GreaterConditionEvent.Invoke();
                            Invoke("GreaterCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingLessCondition && int.Parse(LessConditionValue) > HealthVariables.CurrentValue)
                    {
                        if (!isLessInvoke)
                        {
                            isLessInvoke = true;
                            LessConditionEvent.Invoke();
                            Invoke("LessCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }
            }

            if (VariableType == GlobalVariable.CVariableType.manaVar)
            {
                if (isChecking)
                {
                    if (usingEqualCondition && EqualConditionValue == ManaVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != ManaVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingGreaterCondition && int.Parse(GreaterConditionValue) < ManaVariables.CurrentValue)
                    {
                        if (!isGreaterInvoke)
                        {
                            isGreaterInvoke = true;
                            GreaterConditionEvent.Invoke();
                            Invoke("GreaterCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingLessCondition && int.Parse(LessConditionValue) > ManaVariables.CurrentValue)
                    {
                        if (!isLessInvoke)
                        {
                            isLessInvoke = true;
                            LessConditionEvent.Invoke();
                            Invoke("LessCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }

            }

            if (VariableType == GlobalVariable.CVariableType.expVar)
            {
                if (isChecking)
                {
                    if (usingEqualCondition && EqualConditionValue == ExpVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != ExpVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingGreaterCondition && int.Parse(GreaterConditionValue) < ExpVariables.CurrentValue)
                    {
                        if (!isGreaterInvoke)
                        {
                            isGreaterInvoke = true;
                            GreaterConditionEvent.Invoke();
                            Invoke("GreaterCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingLessCondition && int.Parse(LessConditionValue) > ExpVariables.CurrentValue)
                    {
                        if (!isLessInvoke)
                        {
                            isLessInvoke = true;
                            LessConditionEvent.Invoke();
                            Invoke("LessCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }

            }

            if (VariableType == GlobalVariable.CVariableType.scoreVar)
            {
                if (isChecking)
                {
                    if (usingEqualCondition && EqualConditionValue == ScoreVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != ScoreVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingGreaterCondition && int.Parse(GreaterConditionValue) < ScoreVariables.CurrentValue)
                    {
                        if (!isGreaterInvoke)
                        {
                            isGreaterInvoke = true;
                            GreaterConditionEvent.Invoke();
                            Invoke("GreaterCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingLessCondition && int.Parse(LessConditionValue) > ScoreVariables.CurrentValue)
                    {
                        if (!isLessInvoke)
                        {
                            isLessInvoke = true;
                            LessConditionEvent.Invoke();
                            Invoke("LessCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }
            }

            if (VariableType == GlobalVariable.CVariableType.intVar)
            {
                if (isChecking)
                {
                    if (usingEqualCondition && EqualConditionValue == IntVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != IntVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingGreaterCondition && int.Parse(GreaterConditionValue) < IntVariables.CurrentValue)
                    {
                        if (!isGreaterInvoke)
                        {
                            isGreaterInvoke = true;
                            GreaterConditionEvent.Invoke();
                            Invoke("GreaterCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingLessCondition && int.Parse(LessConditionValue) > IntVariables.CurrentValue)
                    {
                        if (!isLessInvoke)
                        {
                            isLessInvoke = true;
                            LessConditionEvent.Invoke();
                            Invoke("LessCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }
            }

            if (VariableType == GlobalVariable.CVariableType.floatVar)
            {
                if (isChecking)
                {
                    if (usingEqualCondition && EqualConditionValue == FloatVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != FloatVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingGreaterCondition && int.Parse(GreaterConditionValue) < FloatVariables.CurrentValue)
                    {
                        if (!isGreaterInvoke)
                        {
                            isGreaterInvoke = true;
                            GreaterConditionEvent.Invoke();
                            Invoke("GreaterCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingLessCondition && int.Parse(LessConditionValue) > FloatVariables.CurrentValue)
                    {
                        if (!isLessInvoke)
                        {
                            isLessInvoke = true;
                            LessConditionEvent.Invoke();
                            Invoke("LessCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }
            }

            if (VariableType == GlobalVariable.CVariableType.stringVar)
            {
                if (isChecking)
                {
                    if (usingEqualCondition && EqualConditionValue == StringVariables.CurrentValue.ToString())
                    {
                        if (!isEqualInvoke)
                        {
                            isEqualInvoke = true;
                            EqualConditionEvent.Invoke();
                            Invoke("EqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingNotEqualCondition && NotEqualConditionValue != StringVariables.CurrentValue.ToString())
                    {
                        if (!isNotEqualInvoke)
                        {
                            isNotEqualInvoke = true;
                            NotEqualConditionEvent.Invoke();
                            Invoke("NotEqualCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }
            }

            if (VariableType == GlobalVariable.CVariableType.boolVar)
            {
                if (isChecking)
                {
                    if (usingTrueCondition && TrueConditionValue == BoolVariables.CurrentValue)
                    {
                        if (!isTrueInvoke)
                        {
                            isTrueInvoke = true;
                            TrueConditionEvent.Invoke();
                            Invoke("TrueCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                    if (usingFalseCondition && FalseConditionValue == BoolVariables.CurrentValue)
                    {
                        if (!isFalseInvoke)
                        {
                            isFalseInvoke = true;
                            FalseConditionEvent.Invoke();
                            Invoke("FalseCooldown", 1);
                            if (!RepeatChecking)
                            {
                                isChecking = false;
                            }
                        }
                    }
                }
            }

            if (VariableType == GlobalVariable.CVariableType.objectVar)
            {
                if (usingTagEqualCondition && ObjectVariables.CurrentValue && TagEqualConditionValue == ObjectVariables.CurrentValue.tag)
                {
                    if (!isTagEqualInvoke)
                    {
                        isTagEqualInvoke = true;
                        TagEqualConditionEvent.Invoke();
                        Invoke("TagEqualCooldown", 1);
                    }
                }
                if (usingNotTagEqualCondition && ObjectVariables.CurrentValue && NotTagEqualConditionValue != ObjectVariables.CurrentValue.tag)
                {
                    if (!isNotTagEqualInvoke)
                    {
                        isNotTagEqualInvoke = true;
                        NotTagEqualConditionEvent.Invoke();
                        Invoke("NotTagEqualCooldown", 1);
                    }
                }
                if (usingNameEqualCondition && ObjectVariables.CurrentValue && NameEqualConditionValue == ObjectVariables.CurrentValue.name)
                {
                    if (!isNameEqualInvoke)
                    {
                        isNameEqualInvoke = true;
                        NameEqualConditionEvent.Invoke();
                        Invoke("NameEqualCooldown", 1);
                    }
                }
                if (usingNotNameEqualCondition && ObjectVariables.CurrentValue && NotNameEqualConditionValue != ObjectVariables.CurrentValue.name)
                {
                    if (!isNotNameEqualInvoke)
                    {
                        isNotNameEqualInvoke = true;
                        NotNameEqualConditionEvent.Invoke();
                        Invoke("NotNameEqualCooldown", 1);
                    }
                }
            }
        }


        void EqualCooldown()
        {
            isEqualInvoke = false;
        }

        void NotEqualCooldown()
        {
            isNotEqualInvoke = false;
        }

        void TagEqualCooldown()
        {
            isTagEqualInvoke = false;
        }

        void NotTagEqualCooldown()
        {
            isNotTagEqualInvoke = false;
        }

        void NameEqualCooldown()
        {
            isNameEqualInvoke = false;
        }

        void NotNameEqualCooldown()
        {
            isNotNameEqualInvoke = false;
        }

        void TrueCooldown()
        {
            isTrueInvoke = false;
        }

        void FalseCooldown()
        {
            isFalseInvoke = false;
        }

        void GreaterCooldown()
        {
            isGreaterInvoke = false;
        }

        void LessCooldown()
        {
            isLessInvoke = false;
        }
    }
}
