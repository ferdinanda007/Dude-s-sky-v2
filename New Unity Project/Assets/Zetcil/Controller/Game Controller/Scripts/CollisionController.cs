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

    public class CollisionController : MonoBehaviour
    {

        public enum CCollisionDestroy { ThisGameObject, ThatGameObject, BothGameObject }
        public enum CCollisionType { isTrigger, isCollision }

        [Space(10)]
        public bool isEnabled;

        public CCollisionType CollisionType;

        [Header("Rigidbody3D Settings")]
        public bool usingRigidbody3D;
        public Rigidbody TargetRigidbody;

        [Header("Trigger Enter Settings")]
        public bool usingTriggerEnter;
        [Tag] public string[] TriggerEnterTag;
        [Header("Event Enter Settings")]
        public UnityEvent TriggerEnterEvent;
        [Space(10)]
        public bool usingDestroyTriggerEnter;
        public CCollisionDestroy DestroyTriggerEnter;
        public float DestroyTriggerEnterDelay;

        [Header("Trigger Exit Settings")]
        public bool usingTriggerExit;
        [Tag] public string[] TriggerExitTag;
        [Header("Event Exit Settings")]
        public UnityEvent TriggerExitEvent;

        [Header("Collision Enter Settings")]
        public bool usingCollisionEnter;
        [Tag] public string[] CollisionEnterTag;
        [Header("Event Enter Settings")]
        public UnityEvent CollisionEnterEvent;
        [Space(10)]
        public bool usingDestroyCollisionEnter;
        public CCollisionDestroy DestroyCollisionEnter;
        public float DestroyCollisionEnterDelay;

        [Header("Collision Exit Settings")]
        public bool usingCollisionExit;
        [Tag] public string[] CollisionExitTag;
        [Header("Event Exit Settings")]
        public UnityEvent CollisionExitEvent;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter(Collision collision)
        {
            if (usingCollisionEnter)
            {
                for (int i = 0; i < CollisionEnterTag.Length; i++)
                {
                    if (CollisionEnterTag[i] == collision.gameObject.tag)
                    {
                        CollisionEnterEvent.Invoke();

                        if (usingDestroyCollisionEnter)
                        {
                            switch (DestroyCollisionEnter)
                            {
                                case CCollisionDestroy.ThisGameObject:
                                    Destroy(this.gameObject, DestroyCollisionEnterDelay);
                                    break;
                                case CCollisionDestroy.ThatGameObject:
                                    Destroy(collision.gameObject, DestroyCollisionEnterDelay);
                                    break;
                                case CCollisionDestroy.BothGameObject:
                                    Destroy(this.gameObject, DestroyCollisionEnterDelay);
                                    Destroy(collision.gameObject, DestroyCollisionEnterDelay);
                                    break;
                            }
                        }

                    }
                }
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (usingCollisionExit)
            {
                for (int i = 0; i < CollisionExitTag.Length; i++)
                {
                    if (CollisionExitTag[i] == collision.gameObject.tag)
                    {
                        CollisionExitEvent.Invoke();
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
                        TriggerEnterEvent.Invoke();

                        if (usingDestroyTriggerEnter)
                        {
                            switch (DestroyTriggerEnter)
                            {
                                case CCollisionDestroy.ThisGameObject:
                                    Destroy(this.gameObject, DestroyTriggerEnterDelay);
                                    break;
                                case CCollisionDestroy.ThatGameObject:
                                    Destroy(collider.gameObject, DestroyTriggerEnterDelay);
                                    break;
                                case CCollisionDestroy.BothGameObject:
                                    Destroy(this.gameObject, DestroyTriggerEnterDelay);
                                    Destroy(collider.gameObject, DestroyTriggerEnterDelay);
                                    break;
                            }
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
                        TriggerExitEvent.Invoke();
                    }
                }
            }
        }
    }
}

