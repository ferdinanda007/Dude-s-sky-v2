using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class UIDropable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public bool isEnabled;
        
        [Header("Drag Settings")]
        public List<string> AcceptDragID;

        [Header("Pointer Enter Settings")]
        public bool usingPointerEnterEvent;
        public UnityEvent PointerEnterEvent;

        [Header("Pointer Exit Settings")]
        public bool usingPointerExitEvent;
        public UnityEvent PointerExitEvent;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool isValid(string dragID)
        {
            bool result = false;
            for (int i = 0; i < AcceptDragID.Count; i++)
            {
                if (AcceptDragID[i] == dragID)
                {
                    result = true;
                }
            }
            return result;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
            {
                return;
            }

            UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
            if (d != null)
            {
                if (isValid(d.dragID))
                {
                    if (usingPointerEnterEvent)
                    {
                        PointerEnterEvent.Invoke();
                    }
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("OnPointerExit");
            if (eventData.pointerDrag == null)
            {
                return;
            }

            UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
            if (d != null)
            {
                if (isValid(d.dragID))
                {
                    if (usingPointerExitEvent)
                    {
                        PointerExitEvent.Invoke();
                    }
                }
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);

            UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
            if (d != null) {
            	d.transform.position = this.transform.position;
            }
        }
    }
}
