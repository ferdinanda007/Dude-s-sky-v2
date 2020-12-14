/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk bikin tampilan UI health - versi ini ditampilin di canvas pada layout screen 
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zetcil
{
    public class UIHealth : MonoBehaviour
    {

        [Space(10)]
        public bool isEnabled;

        [Header("UI Variables")]
        public Slider TargetSlider;

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

        [Header("Rotation Settings")]
        public bool usingAutoRotation;
        public Canvas TargetCanvas;
        [HideInInspector]
        public Camera TargetCamera;

        // Use this for initialization
        void Start()
        {
            TargetCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                switch (VariableType)
                {
                    case GlobalVariable.CVariableType.intVar:
                        TargetSlider.value = IntVariables.GetCurrentValue();
                        break;
                    case GlobalVariable.CVariableType.floatVar:
                        TargetSlider.value = Mathf.RoundToInt(TimeVariables.GetCurrentValue() / TimeVariables.MaxValue * 100);
                        break;
                    case GlobalVariable.CVariableType.healthVar:
                        TargetSlider.value = Mathf.RoundToInt(HealthVariables.GetCurrentValue() / HealthVariables.GetMaxValue() * 100);
                        break;
                    case GlobalVariable.CVariableType.manaVar:
                        TargetSlider.value = Mathf.RoundToInt(ManaVariables.GetCurrentValue() / ManaVariables.GetMaxValue() * 100);
                        break;
                    case GlobalVariable.CVariableType.expVar:
                        TargetSlider.value = Mathf.RoundToInt(ExpVariables.GetCurrentValue() / ExpVariables.GetMaxValue() * 100);
                        break;
                    case GlobalVariable.CVariableType.scoreVar:
                        TargetSlider.value = Mathf.RoundToInt(ScoreVariables.GetCurrentValue());
                        break;
                    case GlobalVariable.CVariableType.timeVar:
                        TargetSlider.value = Mathf.RoundToInt(TimeVariables.GetCurrentValue());
                        break;
                }
                if (TargetSlider.value <= 0)
                {
                    TargetSlider.transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    TargetSlider.transform.GetChild(1).gameObject.SetActive(true);
                }

                if (usingAutoRotation)
                {
                    TargetCanvas.transform.LookAt(TargetCamera.transform);
                }
            }
        }
    }
}