/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menampilkan nilai variabel
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{

    public class UITextMesh : MonoBehaviour
    {
        public enum CTimeFormat { None, SS, MMSS, HHMMSS }
        [Space(10)]
        public bool isEnabled;

        [Header("UI Variables")]
        public TextMesh TargetText;
        public string PrefixText;
        public string PostfixText;

        [Header("Global Variables")]
        public GlobalVariable.CVariableType VariableType;
        public VarTime TimeVariables;
        public VarHealth HealthVariables;
        public VarMana ManaVariables;
        public VarExp ExpVariables;
        public VarScore ScoreVariables;
        public VarInteger IntVariables;
        public VarFloat FloatVariables;
        public VarString StringVariables;
        public VarBoolean BoolVariables;

        [Header("Readonly Variables")]
        public bool usingDebug;
        [ConditionalField("usingDebug")] [ReadOnly] public string DebugText;

        [Header("Time Format")]
        public bool usingTimeFormat;
        [ConditionalField("usingTimeFormat")] public CTimeFormat TimeFormat;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                if (usingDebug)
                {
                    if (VariableType == GlobalVariable.CVariableType.timeVar)
                    {
                        DebugText = TimeVariables.CurrentValue.ToString();
                    }
                    if (VariableType == GlobalVariable.CVariableType.healthVar)
                    {
                        DebugText = HealthVariables.CurrentValue.ToString();
                    }
                    if (VariableType == GlobalVariable.CVariableType.scoreVar)
                    {
                        DebugText = ScoreVariables.CurrentValue.ToString();
                    }
                    if (VariableType == GlobalVariable.CVariableType.intVar)
                    {
                        DebugText = IntVariables.CurrentValue.ToString();
                    }
                    if (VariableType == GlobalVariable.CVariableType.floatVar)
                    {
                        DebugText = FloatVariables.CurrentValue.ToString();
                    }
                    if (VariableType == GlobalVariable.CVariableType.stringVar)
                    {
                        DebugText = StringVariables.CurrentValue.ToString();
                    }
                    if (VariableType == GlobalVariable.CVariableType.boolVar)
                    {
                        DebugText = BoolVariables.CurrentValue.ToString();
                    }
                }
                if (VariableType == GlobalVariable.CVariableType.timeVar)
                {
                    TargetText.text = PrefixText + TimeVariables.CurrentValue.ToString() + PostfixText;
                }
                if (VariableType == GlobalVariable.CVariableType.healthVar)
                {
                    TargetText.text = PrefixText + HealthVariables.CurrentValue.ToString() + PostfixText;
                }
                if (VariableType == GlobalVariable.CVariableType.scoreVar)
                {
                    TargetText.text = PrefixText + ScoreVariables.CurrentValue.ToString() + PostfixText;
                }
                if (VariableType == GlobalVariable.CVariableType.intVar)
                {
                    TargetText.text = PrefixText + IntVariables.CurrentValue.ToString() + PostfixText;
                }
                if (VariableType == GlobalVariable.CVariableType.floatVar)
                {
                    TargetText.text = PrefixText + FloatVariables.CurrentValue.ToString() + PostfixText;
                }
                if (VariableType == GlobalVariable.CVariableType.stringVar)
                {
                    TargetText.text = PrefixText + StringVariables.CurrentValue.ToString() + PostfixText;
                }
                if (VariableType == GlobalVariable.CVariableType.boolVar)
                {
                    TargetText.text = PrefixText + BoolVariables.CurrentValue.ToString() + PostfixText;
                }
                if (usingTimeFormat)
                {
                    if (VariableType == GlobalVariable.CVariableType.timeVar)
                    {
                        if (TimeFormat == CTimeFormat.None)
                        {
                            TargetText.text = PrefixText + FloatToTime(TimeVariables.GetCurrentValue(), "None") + PostfixText;
                        }
                        if (TimeFormat == CTimeFormat.SS)
                        {
                            TargetText.text = PrefixText + FloatToTime(TimeVariables.GetCurrentValue(), "SS") + PostfixText;
                        }
                        if (TimeFormat == CTimeFormat.MMSS)
                        {
                            TargetText.text = PrefixText + FloatToTime(TimeVariables.GetCurrentValue(), "MMSS") + PostfixText;
                        }
                        if (TimeFormat == CTimeFormat.HHMMSS)
                        {
                            TargetText.text = PrefixText + FloatToTime(TimeVariables.GetCurrentValue(), "HHMMSS") + PostfixText;
                        }
                    }
                }
            }
        }

        public string FloatToTime(float toConvert, string format)
        {
            switch (format)
            {
                case "None":
                    return string.Format("{0:00}",
                        Mathf.Floor(toConvert) //seconds
                        );//miliseconds

                case "SS":
                    return string.Format("{0:00}",
                        Mathf.Floor(toConvert) % 60//seconds
                        );//miliseconds

                case "MMSS":
                    return string.Format("{0:00}:{1:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60//seconds
                        );//miliseconds

                case "HHMMSS":
                    return string.Format("{0:00}:{1:00}:{2:00}",
                        Mathf.Floor(toConvert / 3600),//hours
                        Mathf.Floor(toConvert / 60) - (Mathf.Floor(toConvert / 3600) * 60), //minutes
                        Mathf.Floor(toConvert) % 60//seconds
                        );//miliseconds

                case "00.0":
                    return string.Format("{0:00}:{1:0}:{2:0}",
                        Mathf.Floor(toConvert) / 3600,//seconds
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds

                case "#0.0":
                    return string.Format("{0:#0}:{1:0}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds

                case "00.00":
                    return string.Format("{0:00}:{1:00}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 100) % 100));//miliseconds

                case "00.000":
                    return string.Format("{0:00}:{1:000}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

                case "#00.000":
                    return string.Format("{0:#00}:{1:000}",
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

                case "#0:00":
                    return string.Format("{0:#0}:{1:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60);//seconds

                case "#00:00":
                    return string.Format("{0:#00}:{1:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60);//seconds

                case "0:00.0":
                    return string.Format("{0:0}:{1:00}.{2:0}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds

                case "#0:00.0":
                    return string.Format("{0:#0}:{1:00}.{2:0}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 10) % 10));//miliseconds

                case "0:00.00":
                    return string.Format("{0:0}:{1:00}.{2:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 100) % 100));//miliseconds

                case "#0:00.00":
                    return string.Format("{0:#0}:{1:00}.{2:00}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 100) % 100));//miliseconds

                case "0:00.000":
                    return string.Format("{0:0}:{1:00}.{2:000}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

                case "#0:00.000":
                    return string.Format("{0:#0}:{1:00}.{2:000}",
                        Mathf.Floor(toConvert / 60),//minutes
                        Mathf.Floor(toConvert) % 60,//seconds
                        Mathf.Floor((toConvert * 1000) % 1000));//miliseconds

            }
            return "error";
        }

    }
}
