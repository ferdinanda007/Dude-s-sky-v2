using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TechnomediaLabs;

namespace Zetcil
{

    public class DraggableController : MonoBehaviour
    {
        public enum CObjectSelectionType { Everything, ByName, ByTag }
        public enum CDragDirection { None, XOnly, YOnly, ZOnly, XYDirection, XZDirection }

        public enum CCollisionType { isTrigger, isCollision }

        [Space(10)]
        public bool isEnabled;

        public CCollisionType CollisionType;

        [Header("Main Settings")]
        public CDragDirection DragDirection;
        public Camera MainCamera;

        [Header("Lock Settings")]
        public bool usingDefaultPosition;
        public GameObject DefaultPosition;

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
        Vector3 startPosition;
        bool getDestination = false;

        public void SetEnabled(bool aEnabled)
        {
            isEnabled = aEnabled;
        }

        void Start()
        {
            if (MainCamera == null)
            {
                MainCamera = Camera.main;
            }
        }
        public void SetToGameObject(GameObject targetObject)
        {
            transform.position = targetObject.transform.position;
            transform.localScale = targetObject.transform.localScale;
            getDestination = true;
        }

        public void BackToDefaultPosition()
        {
            if (usingDefaultPosition && !getDestination)
            {
                transform.position = DefaultPosition.transform.position;
                transform.localScale = DefaultPosition.transform.localScale;
            }
        }

        void OnMouseDown()
        {
            if (isEnabled)
            {
                startPosition = transform.position;
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
        }

        void OnTriggerEnter(Collider collider)
        {
            if (usingTriggerEnter && collider.tag == TriggerEnterTag)
            {
                TriggerEnterEvent.Invoke();
            }
        }

        void OnTriggerStay(Collider collider)
        {
            if (usingTriggerStay && collider.tag == TriggerStayTag)
            {
                SetToGameObject(collider.gameObject);
                TriggerStayEvent.Invoke();
            }
        }

        void OnTriggerExit(Collider collider)
        {
            if (usingTriggerExit && collider.tag == TriggerExitTag)
            {
                TriggerExitEvent.Invoke();
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (usingCollisionEnter && collision.gameObject.tag == CollisionEnterTag)
            {
                CollisionEnterEvent.Invoke();
            }
        }

        void OnCollisionStay(Collision collision)
        {
            if (usingCollisionStay && collision.gameObject.tag == CollisionEnterTag)
            {
                SetToGameObject(collision.gameObject);
                CollisionStayEvent.Invoke();
            }
        }

        void OnCollisionExit(Collision collision)
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
                if (Input.GetKeyUp(KeyCode.Mouse2))
                {
                    if (DragDirection == CDragDirection.XYDirection)
                    {
                        DragDirection = CDragDirection.XZDirection;
                    }
                    else if (DragDirection == CDragDirection.XZDirection)
                    {
                        DragDirection = CDragDirection.XYDirection;
                    }
                }

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

                        Vector3 newDist = startPosition;
                        newDist.x = startDist.x;
                        newDist.y = 0 + startPosition.y;
                        newDist.z = 0 + startPosition.z;
                        transform.position = rayPoint + newDist;
                    }
                    else if (DragDirection == CDragDirection.YOnly)
                    {
                        rayPoint.x = 0;
                        //rayPoint.y = 0;
                        rayPoint.z = 0;

                        Vector3 newDist = startPosition;
                        newDist.x = 0 + startPosition.x;
                        newDist.y = startDist.y; 
                        newDist.z = 0 + startPosition.z;
                        transform.position = rayPoint + newDist;

                        //startDist.x = 0;
                        //startDist.y = 0;
                        //startDist.z = 0;
                        //transform.position = rayPoint + startDist;
                    }
                    else if (DragDirection == CDragDirection.ZOnly)
                    {
                        rayPoint.x = 0;
                        rayPoint.y = 0;
                        //rayPoint.z = 0;

                        Vector3 newDist = startPosition;
                        newDist.x = 0 + startPosition.x;
                        newDist.y = 0 + startPosition.y;
                        newDist.z = startDist.z; 
                        transform.position = rayPoint + newDist;

                        //startDist.x = 0;
                        //startDist.y = 0;
                        //startDist.z = 0;
                        //transform.position = rayPoint + startDist;
                    }
                    else if (DragDirection == CDragDirection.XYDirection)
                    {
                        //rayPoint.x = 0;
                        //rayPoint.y = 0;
                        rayPoint.z = 0;

                        Vector3 newDist = startPosition;
                        newDist.x = startDist.x;
                        newDist.y = startDist.y;
                        newDist.z = 0 + startPosition.z;
                        transform.position = rayPoint + newDist;

                        //startDist.x = 0;
                        //startDist.y = 0;
                        //startDist.z = 0;
                        //transform.position = rayPoint + startDist;
                    }
                    else if (DragDirection == CDragDirection.XZDirection)
                    {
                        //rayPoint.x = 0;
                        rayPoint.y = 0;
                        //rayPoint.z = 0;

                        Vector3 newDist = startPosition;
                        newDist.x = startDist.x;
                        newDist.y = 0 + startPosition.y;
                        newDist.z = startDist.z;
                        transform.position = rayPoint + newDist;

                        //startDist.x = 0;
                        //startDist.y = 0;
                        //startDist.z = 0;
                        //transform.position = rayPoint + startDist;
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