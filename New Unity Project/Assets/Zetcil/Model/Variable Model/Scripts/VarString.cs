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
    public class VarString : MonoBehaviour
    {

        [Space(10)]
        public bool isEnabled;
        [ConditionalField("isEnabled")] public string CurrentValue;

        public void SetPrefCurrentValue(string aID)
        {
            PlayerPrefs.SetString(aID, CurrentValue);
        }

        public void GetPrefCurrentValue(string aID)
        {
            CurrentValue = PlayerPrefs.GetString(aID);
        }

        public string GetCurrentValue()
        {
            return CurrentValue;
        }

        public void SetCurrentValue(string aValue)
        {
            CurrentValue = aValue;
        }

        public void SetCurrentValue(VarString aValue)
        {
            CurrentValue = aValue.CurrentValue;
        }

        public void SetCurrentValue(Text aValue)
        {
            CurrentValue = aValue.text;
        }

        public void SetCurrentValue(InputField aValue)
        {
            CurrentValue = aValue.text;
        }

        public void ClearCurrentValue(float Delay)
        {
            Invoke("ClearThisValue", Delay);
        }

        void ClearThisValue()
        {
            CurrentValue = "";
        }

        public void AddToCurrentValue(string aValue)
        {
            CurrentValue += aValue;
        }

        public void InputToCurrentValue(InputField aValue)
        {
            CurrentValue = aValue.text;
        }

        void Update()
        {
        }

    }

}