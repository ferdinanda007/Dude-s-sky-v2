/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur kondisi pause dan play
 **************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Zetcil
{
    public class PauseController : MonoBehaviour
    {

        public enum CPauseType { TimeScale, GameObject }
        public enum CGameStatus { Play, Pause }

        [Space(10)]
        public bool isEnabled;

        [Header("Pause/Play Settings")]
        public CPauseType PauseType;
        public CGameStatus GameStatus;

        [Header("Trigger Key")]
        public KeyCode TriggerKey = KeyCode.P;

        [Header("Pause Condition")]
        public bool usingPauseCondition;
        public UnityEvent PauseCondition;

        [Header("Play Condition")]
        public bool usingPlayCondition;
        public UnityEvent PlayCondition;

        [Header("GameObject Condition")]
        public GameObject[] TargetObject;
        public AudioSource[] TargetAudio;

        // Use this for initialization
        void Start()
        {
            if (usingPlayCondition)
            {
                PlayCondition.Invoke();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(TriggerKey) && GameStatus == CGameStatus.Play)
            {
                SetGamePause();
            } 
            else if (Input.GetKeyDown(TriggerKey) && GameStatus == CGameStatus.Pause)
            {
                SetGamePlay();
            }

            if (PauseType == CPauseType.GameObject)
            {
                if (GameStatus == CGameStatus.Play)
                {
                    for (int i = 0; i < TargetObject.Length; i++)
                    {
                        TargetObject[i].SendMessage("SetPlay", true, SendMessageOptions.DontRequireReceiver);
                    }
                    for (int i = 0; i < TargetAudio.Length; i++)
                    {
                        TargetAudio[i].Pause();
                    }
                }
                if (GameStatus == CGameStatus.Pause)
                {
                    for (int i = 0; i < TargetObject.Length; i++)
                    {
                        TargetObject[i].SendMessage("SetPause", true, SendMessageOptions.DontRequireReceiver);
                    }
                    for (int i = 0; i < TargetAudio.Length; i++)
                    {
                        TargetAudio[i].UnPause();
                    }
                }
            }

        }

        public void SetGamePlay()
        {
            GameStatus = CGameStatus.Play;

            if (PauseType == CPauseType.TimeScale)
            {
                if (GameStatus == CGameStatus.Play)
                {
                    Time.timeScale = 1;
                }
            }

            if (usingPlayCondition)
            {
                PlayCondition.Invoke();
            }
        }

        public void SetGamePause()
        {
            GameStatus = CGameStatus.Pause;

            if (PauseType == CPauseType.TimeScale)
            {
                if (GameStatus == CGameStatus.Pause)
                {
                    Time.timeScale = 0;
                }
            }

            if (usingPauseCondition)
            {
                PauseCondition.Invoke();
            }
        }


    }
}
