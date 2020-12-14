using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TechnomediaLabs;

namespace Zetcil
{
    public class UIDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        public bool isEnabled;

        [Header("Draggable Settings")]
        public string dragID;
        public Vector2 dragOffset;

        [Header("BeginDrag Settings")]
        public bool usingBeginDrag;
        public UnityEvent BeginDragEvent;

        [Header("Drag Settings")]
        public bool usingDrag;
        public UnityEvent DragEvent;

        [Header("EndDrag Settings")]
        public bool usingEndDrag;
        public UnityEvent EndDragEvent;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isEnabled && usingBeginDrag)
            {
                BeginDragEvent.Invoke();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isEnabled)
            {
                this.transform.position = eventData.position - dragOffset;

                if (usingDrag)
                {
                    DragEvent.Invoke();
                }
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (isEnabled && usingEndDrag)
            {
                EndDragEvent.Invoke();
            }
        }
    }
}
