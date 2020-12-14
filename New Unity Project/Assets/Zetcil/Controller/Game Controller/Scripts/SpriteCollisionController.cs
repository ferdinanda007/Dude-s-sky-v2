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

    public class SpriteCollisionController : MonoBehaviour
    {

        public enum CCollisionDestroy { ThisGameObject, ThatGameObject, BothGameObject }
        public enum CCollisionType { isTrigger, isCollision }

        [Space(10)]
        public bool isEnabled;

        public CCollisionType CollisionType;

        [Header("Rigidbody2D Settings")]
        public bool usingRigidbody2D;
        public Rigidbody2D TargetRigidbody2D;

        [Header("Trigger Enter Settings")]
        public bool usingTriggerEnter2D;
        [Tag] public string[] TriggerEnter2DTag;
        [Header("Event Enter Settings")]
        public UnityEvent TriggerEnter2DEvent;
        [Space(10)]
        public bool usingDestroyTriggerEnter2D;
        public CCollisionDestroy DestroyTriggerEnter2D;
        public float DestroyTriggerEnter2DDelay;

        [Header("Trigger Exit Settings")]
        public bool usingTriggerExit2D;
        [Tag] public string[] TriggerExit2DTag;
        [Header("Event Exit Settings")]
        public UnityEvent TriggerExit2DEvent;

        [Header("Collision Enter Settings")]
        public bool usingCollisionEnter2D;
        [Tag] public string[] CollisionEnter2DTag;
        [Header("Event Enter Settings")]
        public UnityEvent CollisionEnter2DEvent;
        [Space(10)]
        public bool usingDestroyCollisionEnter2D;
        public CCollisionDestroy DestroyCollisionEnter2D;
        public float DestroyCollisionEnter2DDelay;

        [Header("Collision Exit Settings")]
        public bool usingCollisionExit2D;
        [Tag] public string[] CollisionExit2DTag;
        [Header("Event Exit Settings")]
        public UnityEvent CollisionExit2DEvent;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (usingCollisionEnter2D)
            {
                for (int i = 0; i < CollisionEnter2DTag.Length; i++)
                {
                    if (CollisionEnter2DTag[i] == collision.gameObject.tag)
                    {
                        CollisionEnter2DEvent.Invoke();

                        if (usingDestroyCollisionEnter2D)
                        {
                            switch (DestroyCollisionEnter2D)
                            {
                                case CCollisionDestroy.ThisGameObject:
                                    Destroy(this.gameObject, DestroyCollisionEnter2DDelay);
                                    break;
                                case CCollisionDestroy.ThatGameObject:
                                    Destroy(collision.gameObject, DestroyCollisionEnter2DDelay);
                                    break;
                                case CCollisionDestroy.BothGameObject:
                                    Destroy(this.gameObject, DestroyCollisionEnter2DDelay);
                                    Destroy(collision.gameObject, DestroyCollisionEnter2DDelay);
                                    break;
                            }
                        }

                    }
                }
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (usingCollisionExit2D)
            {
                for (int i = 0; i < CollisionExit2DTag.Length; i++)
                {
                    if (CollisionExit2DTag[i] == collision.gameObject.tag)
                    {
                        CollisionExit2DEvent.Invoke();
                    }
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (usingTriggerEnter2D)
            {
                for (int i = 0; i < TriggerEnter2DTag.Length; i++)
                {
                    if (TriggerEnter2DTag[i] == collider.gameObject.tag)
                    {
                        TriggerEnter2DEvent.Invoke();

                        if (usingDestroyTriggerEnter2D)
                        {
                            switch (DestroyTriggerEnter2D)
                            {
                                case CCollisionDestroy.ThisGameObject:
                                    Destroy(this.gameObject, DestroyTriggerEnter2DDelay);
                                    break;
                                case CCollisionDestroy.ThatGameObject:
                                    Destroy(collider.gameObject, DestroyTriggerEnter2DDelay);
                                    break;
                                case CCollisionDestroy.BothGameObject:
                                    Destroy(this.gameObject, DestroyTriggerEnter2DDelay);
                                    Destroy(collider.gameObject, DestroyTriggerEnter2DDelay);
                                    break;
                            }
                        }
                    }
                }
            }
        }


        void OnTriggerExit2D(Collider2D collider)
        {
            if (usingTriggerExit2D)
            {
                for (int i = 0; i < TriggerExit2DTag.Length; i++)
                {
                    if (TriggerExit2DTag[i] == collider.gameObject.tag)
                    {
                        TriggerExit2DEvent.Invoke();
                    }
                }
            }
        }
    }
}

