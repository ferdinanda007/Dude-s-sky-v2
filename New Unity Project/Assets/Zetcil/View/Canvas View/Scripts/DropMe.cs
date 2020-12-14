using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Zetcil
{

    public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public bool isEnabled;

        [Header("Drop Settings")]
        public Image receivingImage;
        public Image containerImage;
        public Color highlightColor = Color.yellow;
        private Color normalColor;

        [Header("Compare Settings")]
        public bool usingNameCompare;
        public string DragName;

        [Header("Drop Enter Event")]
        public bool usingEnterEvent;
        public UnityEvent EnterEvent;

        [Header("Drop Exit Event")]
        public bool usingExitEvent;
        public UnityEvent ExitEvent;

        [Header("Destroy Settings")]
        public bool DestroySender;
        public float DestroyDelay = 0.3f;
        GameObject lastObject;

        public void OnEnable()
        {
            if (containerImage != null)
                normalColor = containerImage.color;
        }

        public void OnDrop(PointerEventData data)
        {
            containerImage.color = normalColor;

            if (receivingImage == null)
                return;

            Sprite dropSprite = GetDropSprite(data);
            if (dropSprite != null)
                receivingImage.overrideSprite = dropSprite;

        }

        public void OnPointerEnter(PointerEventData data)
        {
            if (containerImage == null)
                return;

            Sprite dropSprite = GetDropSprite(data);
            if (dropSprite != null)
            {
                containerImage.color = highlightColor;
                if (usingNameCompare)
                {
                    if (usingEnterEvent)
                    {
                        EnterEvent.Invoke();
                    }
                }
            }

            if (DestroySender)
            {
                var originalObj = data.pointerDrag;
                if (originalObj != null)
                {
                    lastObject = originalObj;
                }
            }

            Destroy(lastObject, DestroyDelay);
        }

        public void OnPointerExit(PointerEventData data)
        {
            if (containerImage == null)
                return;

            containerImage.color = normalColor;

            if (usingNameCompare)
            {
               if (usingExitEvent)
               {
                   ExitEvent.Invoke();
               }
            }
        }

        private Sprite GetDropSprite(PointerEventData data)
        {
            Sprite result = null;

            var originalObj = data.pointerDrag;
            if (originalObj == null)
                return null;

            var dragMe = originalObj.GetComponent<DragMe>();
            if (dragMe == null)
                return null;

            var srcImage = originalObj.GetComponent<Image>();
            if (srcImage == null)
                return null;

            if (usingNameCompare)
            {
                var nameCompare = originalObj.GetComponent<DragMe>();
                if (nameCompare.DragName == DragName)
                {
                    result = srcImage.sprite;
                    if (usingEnterEvent)
                    {
                        EnterEvent.Invoke();
                    }
                    if (usingExitEvent)
                    {
                        EnterEvent.Invoke();
                    }
                }
            }

            return result;
        }
    }
}

