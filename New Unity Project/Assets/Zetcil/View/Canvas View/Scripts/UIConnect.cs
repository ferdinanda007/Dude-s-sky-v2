using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zetcil
{
    public class UIConnect : MonoBehaviour
    {
        public bool isEnabled;

        [Header("Main Settings")]
        public GameObject RedBar;
        public GameObject YellowBar;
        public GameObject GreenBar;

        [Header("Text Settings")]
        public Text ConnectionText;

        // Start is called before the first frame update
        void Start()
        {
            if (isEnabled)
            {
                RedBar.SetActive(true);
                YellowBar.SetActive(false);
                GreenBar.SetActive(false);
                ConnectionText.text = "Initialize...";
            }
        }

        public void ActiveGreenBar(string aText)
        {
            RedBar.SetActive(false);
            YellowBar.SetActive(false);
            GreenBar.SetActive(true);
            ConnectionText.text = aText;
        }

        public void ActiveRedBar(string aText)
        {
            RedBar.SetActive(true);
            YellowBar.SetActive(false);
            GreenBar.SetActive(false);
            ConnectionText.text = aText;
        }

        public void ActiveYellowBar(string aText)
        {
            RedBar.SetActive(false);
            YellowBar.SetActive(true);
            GreenBar.SetActive(false);
            ConnectionText.text = aText;
        }

        public void ActiveGreenBar(VarString aText)
        {
            RedBar.SetActive(false);
            YellowBar.SetActive(false);
            GreenBar.SetActive(true);
            ConnectionText.text = aText.CurrentValue;
        }

        public void ActiveRedBar(VarString aText)
        {
            RedBar.SetActive(true);
            YellowBar.SetActive(false);
            GreenBar.SetActive(false);
            ConnectionText.text = aText.CurrentValue;
        }

        public void ActiveYellowBar(VarString aText)
        {
            RedBar.SetActive(false);
            YellowBar.SetActive(true);
            GreenBar.SetActive(false);
            ConnectionText.text = aText.CurrentValue;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
