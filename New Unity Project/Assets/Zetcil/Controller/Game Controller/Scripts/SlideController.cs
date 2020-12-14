/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur tampilan slider per canvas
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class SlideController : MonoBehaviour
    {
        public enum CSlideType { OnKeyboard, OnEvent, OnInterval }

        [Space(10)]
        public bool isEnabled;

        [Header("Action Settings")]
        public CSlideType SlideType;
        public KeyCode PrevKey;
        public KeyCode NextKey;
        public float Interval;

        [Header("SlideObject Settings")]
        public bool usingSlideObject;
        public GameObject[] SlideObject;

        [ReadOnly] public int CurrentIndex;

        public void GoToSlide(int aValue)
        {
            if (isEnabled)
            {
                if (aValue < SlideObject.Length - 1 && aValue > 0)
                {
                    CurrentIndex = aValue;
                    CloseAllSlide();
                    if (usingSlideObject)
                    {
                        SlideObject[CurrentIndex].SetActive(true);
                    }
                }
            }
        }

        public void NextSlide()
        {
            if (isEnabled)
            {
                if (CurrentIndex < SlideObject.Length - 1)
                {
                    CurrentIndex++;
                }
                CloseAllSlide();
                if (usingSlideObject)
                {
                    SlideObject[CurrentIndex].SetActive(true);
                }
            }
        }

        public void PrevSlide()
        {
            if (isEnabled)
            {
                if (CurrentIndex > 0)
                {
                    CurrentIndex--;
                }
                CloseAllSlide();
                if (usingSlideObject)
                {
                    SlideObject[CurrentIndex].SetActive(true);
                }
            }
        }

        public void FirstSlide()
        {
            if (isEnabled)
            {
                CurrentIndex = 0;
                CloseAllSlide();
                if (usingSlideObject)
                {
                    SlideObject[CurrentIndex].SetActive(true);
                }
            }
        }

        public void CloseAllSlide()
        {
            if (usingSlideObject)
            {
                for (int i = 0; i < SlideObject.Length; i++)
                {
                    SlideObject[i].SetActive(false);
                }
            }
        }

        void SlideShow()
        {
            if (isEnabled)
            {
                if (CurrentIndex < SlideObject.Length - 1)
                {
                    CurrentIndex++;
                }
                CloseAllSlide();
                if (usingSlideObject)
                {
                    SlideObject[CurrentIndex].SetActive(true);
                }
            }
        }

        // Use this for initialization
        void Start()
        {
            FirstSlide();
            if (SlideType == CSlideType.OnInterval)
            {
                InvokeRepeating("SlideShow", 1, Interval);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (SlideType == CSlideType.OnKeyboard)
            {
                if (Input.GetKeyUp(PrevKey))
                {
                    PrevSlide();
                }
                if (Input.GetKeyUp(NextKey))
                {
                    NextSlide();
                }
            }
        }
    }
}
