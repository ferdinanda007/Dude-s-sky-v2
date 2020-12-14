using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TechnomediaLabs;

namespace Zetcil
{

    public class SpriteDraggableController : MonoBehaviour
    {
        public enum CObjectSelectionType { Everything, ByName, ByTag }
        public enum CDragDirection { None, XOnly, YOnly, XYDirection }

        public enum CCollisionType { isTrigger, isCollision }

        [Space(10)]
        public bool isEnabled;
        public CCollisionType CollisionType;

        [Header("Main Settings")]
        public CDragDirection DragDirection;
        public Camera MainCamera;

        [Header("Lock Settings")]
        public bool usingLockPosition;
        public GameObject BeginPosition;
        public bool SnapEndPosition;

        [Header("BeginDrag Settings")]
        [Separator]
        public bool usingBeginDrag;
        public UnityEvent BeginDragEvent;

        [Header("Drag Settings")]
        public bool usingDrag;
        public UnityEvent DragEvent;

        [Header("EndDrag Settings")]
        public bool usingEndDrag;
        public UnityEvent EndDragEvent;

        [Header("TriggerEnter Settings")]
        [Separator]
        public bool usingTriggerEnter;
        [Tag] public string TriggerEnterTag;
        public UnityEvent TriggerEnterEvent;

        [Header("TriggerStay Settings")]
        public bool usingTriggerStay;
        [Tag] public string TriggerStayTag;
        public UnityEvent TriggerStayEvent;

        [Header("TriggerExit Settings")]
        public bool usingTriggerExit;
        [Tag] public string TriggerExitTag;
        public UnityEvent TriggerExitEvent;

        [Header("CollisionEnter Settings")]
        [Separator]
        public bool usingCollisionEnter;
        [Tag] public string CollisionEnterTag;
        public UnityEvent CollisionEnterEvent;

        [Header("CollisionStay Settings")]
        public bool usingCollisionStay;
        [Tag] public string CollisionStayTag;
        public UnityEvent CollisionStayEvent;

        [Header("CollisionExit Settings")]
        public bool usingCollisionExit;
        [Tag] public string CollisionExitTag;
        public UnityEvent CollisionsExitEvent;

        float distance;
        bool dragging;
        Vector3 startDist;
        bool getDestination = false;

        public void SetEnabled(bool aEnabled)
        {
            isEnabled = aEnabled;
        }

        public void SetToGameObject(GameObject targetObject)
        {
            transform.position = targetObject.transform.position;
            transform.localScale = targetObject.transform.localScale;
            getDestination = true;
        }

        public void BackToDefaultPosition()
        {
            if (usingLockPosition && !getDestination)
            {
                transform.position = BeginPosition.transform.position;
                transform.localScale = BeginPosition.transform.localScale;
            }
        }

        void Start()
        {

        }

        void OnMouseDown()
        {
            if (isEnabled)
            {
                getDestination = false;
                distance = Vector3.Distance(transform.position, MainCamera.transform.position);
                dragging = true;
                Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                Vector3 rayPoint = ray.GetPoint(distance);
                startDist = transform.position - rayPoint;

                if (usingBeginDrag)
                {
                    BeginDragEvent.Invoke();
                }
            }
        }

        void OnMouseUp()
        {
            dragging = false;

            if (usingEndDrag)
            {
                EndDragEvent.Invoke();
            }

            BackToDefaultPosition();
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (usingTriggerEnter && collider.tag == TriggerEnterTag)
            {
                TriggerEnterEvent.Invoke();
            }
        }

        void OnTriggerStay2D(Collider2D collider)
        {
            if (usingLockPosition && collider.tag == TriggerStayTag)
            {
                if (SnapEndPosition)
                {
                    SetToGameObject(collider.gameObject);
                }
            }
            if (usingTriggerStay && collider.tag == TriggerStayTag)
            {
                TriggerStayEvent.Invoke();
            }
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if (usingTriggerExit && collider.tag == TriggerExitTag)
            {
                TriggerExitEvent.Invoke();
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (usingCollisionEnter && collision.gameObject.tag == CollisionEnterTag)
            {
                CollisionEnterEvent.Invoke();
            }
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (usingCollisionStay && collision.gameObject.tag == CollisionEnterTag)
            {
                SetToGameObject(collision.gameObject);
                CollisionStayEvent.Invoke();
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (usingCollisionExit && collision.gameObject.tag == CollisionExitTag)
            {
                CollisionsExitEvent.Invoke();
            }
        }

        void Update()
        {
            if (isEnabled)
            {
                if (dragging)
                {
                    Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                    Vector3 rayPoint = ray.GetPoint(distance);

                    if (DragDirection == CDragDirection.XOnly)
                    {
                        //rayPoint.x = 0;
                        rayPoint.y = 0;
                        rayPoint.z = 0;
                        //startDist.x = 0;
                        startDist.y = 0;
                        startDist.z = 0;
                        transform.position = rayPoint + startDist;
                    }
                    else if (DragDirection == CDragDirection.YOnly)
                    {
                        rayPoint.x = 0;
                        //rayPoint.y = 0;
                        rayPoint.z = 0;
                        startDist.x = 0;
                        //startDist.y = 0;
                        startDist.z = 0;
                        transform.position = rayPoint + startDist;
                    }
                    else if (DragDirection == CDragDirection.XYDirection)
                    {
                        //rayPoint.x = 0;
                        //rayPoint.y = 0;
                        rayPoint.z = 0;
                        //startDist.x = 0;
                        //startDist.y = 0;
                        startDist.z = 0;
                        transform.position = rayPoint + startDist;
                    }

                    if (usingDrag)
                    {
                        if (Input.GetKey(KeyCode.Mouse0))
                        {
                            DragEvent.Invoke();
                        }
                    }

                }
            }
        }
    }
}