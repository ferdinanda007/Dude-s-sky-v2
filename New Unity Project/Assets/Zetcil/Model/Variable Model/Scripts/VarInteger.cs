/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk menampung nilai global variabel
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TechnomediaLabs;

namespace Zetcil
{
    public class VarInteger : MonoBehaviour
    {

        [Space(10)]
        public bool isEnabled;
        [ConditionalField("isEnabled")] public int CurrentValue;
        [ConditionalField("isEnabled")] public bool Constraint;
        [ConditionalField("Constraint")] public int MinValue;
        [ConditionalField("Constraint")] public int MaxValue;

        public void SetPrefCurrentValue(string aID)
        {
            PlayerPrefs.SetInt(aID, CurrentValue);
        }

        public void GetPrefCurrentValue(string aID)
        {
            CurrentValue = PlayerPrefs.GetInt(aID);
        }

        void Start()
        {
            if (MaxValue == 0)
            {
                MaxValue = CurrentValue;
            }

        }

        public float GetMinValue()
        {
            return MinValue;
        }

        public float GetMaxValue()
        {
            return MaxValue;
        }

        public void SetMinValue(int aValue)
        {
            MinValue = aValue;
        }

        public void SetMaxValue(int aValue)
        {
            MaxValue = aValue;
        }


        public int GetCurrentValue()
        {
            return CurrentValue;
        }

        public void GetCurrentValue(InputField aValue)
        {
            aValue.text = CurrentValue.ToString();
        }
        public void OutputFromCurrentValue(InputField aValue)
        {
            aValue.text = CurrentValue.ToString();
        }

        public void SetCurrentValue(int aValue)
        {
            CurrentValue = aValue;
            if (Constraint && CurrentValue >= MaxValue) CurrentValue = MaxValue;
            if (Constraint && CurrentValue <= MinValue) CurrentValue = MinValue;
        }

        public void SetCurrentValue(VarInteger aValue)
        {
            CurrentValue = aValue.CurrentValue;
            if (Constraint && CurrentValue >= MaxValue) CurrentValue = MaxValue;
            if (Constraint && CurrentValue <= MinValue) CurrentValue = MinValue;
        }

        public void SetCurrentValue(InputField aValue)
        {
            if (aValue.contentType == InputField.ContentType.IntegerNumber)
            {
                CurrentValue = int.Parse(aValue.text);
            }
            if (Constraint && CurrentValue >= MaxValue) CurrentValue = MaxValue;
            if (Constraint && CurrentValue <= MinValue) CurrentValue = MinValue;
        }

        public void AddCycleToCurrentValue(int aValue)
        {
            CurrentValue += aValue;
            if (Constraint && CurrentValue > MaxValue) CurrentValue = MinValue;
        }

        public void AddToCurrentValue(int aValue)
        {
            CurrentValue += aValue;
            if (Constraint && CurrentValue > MaxValue) CurrentValue = MaxValue;
        }

        public void AddToCurrentValue(VarInteger aValue)
        {
            CurrentValue += aValue.CurrentValue;
            if (Constraint && CurrentValue >= MaxValue) CurrentValue = MaxValue;
            if (Constraint && CurrentValue <= MinValue) CurrentValue = MinValue;
        }

        public void AddToCurrentValue(InputField aValue)
        {
            if (aValue.contentType == InputField.ContentType.IntegerNumber)
            {
                CurrentValue += int.Parse(aValue.text);
            }
            if (Constraint && CurrentValue >= MaxValue) CurrentValue = MaxValue;
            if (Constraint && CurrentValue <= MinValue) CurrentValue = MinValue;
        }


        public void SubtractFromCurrentValue(int aValue)
        {
            CurrentValue -= aValue;
            if (Constraint && CurrentValue < MinValue) CurrentValue = MinValue;
        }

        public void SubtractFromCurrentValue(VarInteger aValue)
        {
            CurrentValue -= aValue.CurrentValue;
            if (Constraint && CurrentValue >= MaxValue) CurrentValue = MaxValue;
            if (Constraint && CurrentValue <= MinValue) CurrentValue = MinValue;
        }

        public void SubtractFromCurrentValue(InputField aValue)
        {
            if (aValue.contentType == InputField.ContentType.IntegerNumber)
            {
                CurrentValue -= int.Parse(aValue.text);
            }
            if (Constraint && CurrentValue >= MaxValue) CurrentValue = MaxValue;
            if (Constraint && CurrentValue <= MinValue) CurrentValue = MinValue;
        }


        public bool IsShutdown()
        {
            return CurrentValue <= 0;
        }

        public void InputToCurrentValue(InputField aValue)
        {
            if (aValue.contentType == InputField.ContentType.IntegerNumber)
            {
                CurrentValue = int.Parse(aValue.text);
            }
            else
            {
                Debug.Log("Error type: Invalid InputField.ContentType.IntegerNumber");
            }
        }
    }
}