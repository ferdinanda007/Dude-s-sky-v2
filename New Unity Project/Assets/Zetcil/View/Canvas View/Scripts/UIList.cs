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

    public class UIList : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("UI Variables")]
        public Text TargetText;

        [Header("Global Variables")]
        public VarList ListVariables;

        [Header("Additional Settings")]
        public string PrefixText;
        public string PostfixText;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            TargetText.text = PrefixText + ListVariables.GetCurrentValue() + PostfixText;
        }

    }
}
