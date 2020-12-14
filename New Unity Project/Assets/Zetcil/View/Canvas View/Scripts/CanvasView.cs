/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk bikin mekanismea hide/show canvas ala form di aplikasi visual biasa
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zetcil
{

    public class CanvasView : MonoBehaviour
    {
        public enum CCanvasType { ClickOnly, DelayOnly }
        public bool isEnabled;
        public CCanvasType CanvasType;

        [System.Serializable]
        public class CDelaySettings
        {
            public Canvas CanvasObject;
            public int StartTime;
            public int FinishTime;
        }

        [Header("Canvas Delay Settings")]
        public bool usingDelay;
        public CDelaySettings[] DelaySettings;

        [Header("Debug Value")]
        public int Counter;

        // Use this for initialization
        void Awake()
        {
            if (usingDelay)
            {
                for (int i = 0; i < DelaySettings.Length; i++)
                {
                    DelaySettings[i].CanvasObject.gameObject.SetActive(false);
                }
            }
        }

        void Start()
        {
            if (usingDelay)
            {
                Counter = 0;
                InvokeRepeating("ExecuteTimer", 1, 1);
            }
        }

        void ExecuteTimer()
        {
            Counter++;
            for (int i=0; i<DelaySettings.Length; i++)
            {
                if (Counter == DelaySettings[i].StartTime)
                {
                    DelaySettings[i].CanvasObject.gameObject.SetActive(true);
                }
                if (Counter == DelaySettings[i].FinishTime)
                {
                    DelaySettings[i].CanvasObject.gameObject.SetActive(false);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void ShowCanvas(Canvas ThisCanvas)
        {
            if (isEnabled && CanvasType == CCanvasType.ClickOnly)
                ThisCanvas.gameObject.SetActive(true);
        }

        public void HideCanvas(Canvas ThisCanvas)
        {
            if (isEnabled && CanvasType == CCanvasType.ClickOnly)
                ThisCanvas.gameObject.SetActive(false);
        }

    }

}