/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur action jika terjadi collision
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class NPCCollisionController : MonoBehaviour
    {

        public enum CCollisionDestroy { ThisGameObject, ThatGameObject, BothGameObject }
        public enum CCollisionType { isTrigger, isCollision }

        public enum CTalkType { None, Autotalk, Keytalk, Camtalk }

        [Space(10)]
        public bool isEnabled;

        [Header("Rigidbody3D Settings")]
        public bool usingRigidbody3D;
        public Rigidbody TargetRigidbody;

        [Header("Collision Settings")]
        public CCollisionType CollisionType;
        public Canvas CanvasTalk;
        public GameObject TalkObject;

        [Header("TalkType Settings")]
        public CTalkType TalkType;

        [Header("Key Settings")]
        [SearchableEnum] public KeyCode KeyTalk;
        public GameObject KeyObject;

        [Header("Camera Settings")]
        [SearchableEnum] public KeyCode CamTalk;
        public Camera PlayerCamera;
        public Camera NPCCamera;
        public GameObject CamObject;

        [Header("Trigger Enter Settings")]
        public bool usingTriggerEnter;
        [Tag] public string[] TriggerEnterTag;

        [Header("TalksOn Settings")]
        public UnityEvent TalkOnEvent;

        [Header("KeyOn Settings")]
        public UnityEvent KeyOnEvent;

        [Header("CamOn Settings")]
        public UnityEvent CamOnEvent;

        [Header("Enter Event Settings")]
        public UnityEvent TriggerEnterEvent;

        [Header("Trigger Exit Settings")]
        public bool usingTriggerExit;
        [Tag] public string[] TriggerExitTag;

        [Header("TalksOff Settings")]
        public UnityEvent TalkOffEvent;

        [Header("KeyOff Settings")]
        public UnityEvent KeyOffEvent;

        [Header("CamOff Settings")]
        public UnityEvent CamOffEvent;

        [Header("Exit Event Settings")]
        public UnityEvent TriggerExitEvent;

        public void ExecuteTalkOn()
        {
            TalkOnEvent.Invoke();
        }

        public void ExecuteTalkOff()
        {
            TalkOffEvent.Invoke();
        }

        public void ExecuteKeyOn()
        {
            KeyOnEvent.Invoke();
        }

        public void ExecuteKeyOff()
        {
            KeyOffEvent.Invoke();
        }

        public void ExecuteCamOn()
        {
            CamOnEvent.Invoke();
        }

        public void ExecuteCamOff()
        {
            PlayerCamera.gameObject.SetActive(true);
            NPCCamera.gameObject.SetActive(false);
            TalkObject.SetActive(false);
            CamOffEvent.Invoke();
        }
        // Use this for initialization
        void Start()
        {
            CanvasTalk.transform.SetParent(null);
        }

        // Update is called once per frame
        void Update()
        {
            if (TalkType == CTalkType.Keytalk)
            {
                if (KeyObject.activeSelf)
                {
                    if (Input.GetKeyDown(KeyTalk))
                    {
                        KeyObject.SetActive(false);
                        TalkObject.SetActive(true);
                        KeyOnEvent.Invoke();
                    }
                }
            }
            if (TalkType == CTalkType.Camtalk)
            {
                if (CamObject.activeSelf)
                {
                    if (Input.GetKeyDown(CamTalk))
                    {
                        CamObject.SetActive(false);
                        PlayerCamera.gameObject.SetActive(false);
                        NPCCamera.gameObject.SetActive(true);
                        TalkObject.SetActive(true);
                        CamOnEvent.Invoke();
                    }
                }
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            if (usingTriggerEnter)
            {
                for (int i = 0; i < TriggerEnterTag.Length; i++)
                {
                    if (TriggerEnterTag[i] == collider.gameObject.tag)
                    {

                        if (TalkType == CTalkType.Autotalk)
                        {
                            TalkObject.SetActive(true);
                            TalkOnEvent.Invoke();
                        }
                        else if (TalkType == CTalkType.Keytalk)
                        {
                            CamObject.SetActive(false);
                            KeyObject.SetActive(true);
                        }
                        else if (TalkType == CTalkType.Camtalk)
                        {
                            CamObject.SetActive(true);
                            KeyObject.SetActive(false);
                        }
                    }
                }
            }
        }


        void OnTriggerExit(Collider collider)
        {
            if (usingTriggerExit)
            {
                for (int i = 0; i < TriggerExitTag.Length; i++)
                {
                    if (TriggerExitTag[i] == collider.gameObject.tag)
                    {

                        if (TalkType == CTalkType.Autotalk)
                        {
                            TalkObject.SetActive(false);
                            TalkOffEvent.Invoke();
                        }
                        else if (TalkType == CTalkType.Keytalk)
                        {
                            KeyObject.SetActive(false);
                            CamObject.SetActive(false);
                            KeyOffEvent.Invoke();
                        }
                        else if (TalkType == CTalkType.Camtalk)
                        {
                            KeyObject.SetActive(false);
                            CamObject.SetActive(false);
                            PlayerCamera.gameObject.SetActive(true);
                            NPCCamera.gameObject.SetActive(false);
                            CamOffEvent.Invoke();
                        }

                        TriggerExitEvent.Invoke();
                    }
                }
            }
        }
    }
}

