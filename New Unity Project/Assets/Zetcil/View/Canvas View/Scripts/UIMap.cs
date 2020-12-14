using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TechnomediaLabs;

namespace Zetcil
{
    public class UIMap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool isEnabled;

        [Header("Zoom Settings")]
        #region Inspector fields
        [SerializeField] float startSize = 1;
        [SerializeField] float minSize = 1f;
        [SerializeField] float maxSize = 5;
        #endregion

        [Header("Status Settings")]
        public float ZoomStatus;
        [SerializeField] private float zoomRate = 5;

        [Header("Map 1x1 Settings")]
        public float Zoom1x1;
        public GameObject Map1x1;

        [Header("Map 2x2 Settings")]
        public float Zoom2x2;
        public GameObject Map2x2;

        [Header("Map 3x3 Settings")]
        public float Zoom3x3;
        public GameObject Map3x3;

        [Header("Map 4x4 Settings")]
        public float Zoom4x4;
        public GameObject Map4x4;

        #region Private Variables
        private bool onObj = false;
        #endregion

        #region Unity Methods
        private void Update()
        {
            float scrollWheel = -Input.GetAxis("Mouse ScrollWheel");

            if (onObj && scrollWheel != 0)
            {
                ChangeZoom(scrollWheel);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onObj = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onObj = false;
        }

        public void OnDisable()
        {
            onObj = false;
        }
        #endregion

        #region Private Methods
        private void ChangeZoom(float scrollWheel)
        {
            float rate = 1 + zoomRate * Time.unscaledDeltaTime;
            if (scrollWheel > 0)
            {
                SetZoom(Mathf.Clamp(transform.localScale.y / rate, minSize, maxSize));
            }
            else
            {
                SetZoom(Mathf.Clamp(transform.localScale.y * rate, minSize, maxSize));
            }

            ZoomStatus = Mathf.Round(transform.localScale.y);
            if (ZoomStatus <= Zoom1x1)
            {
                Map1x1.SetActive(true);
                Map2x2.SetActive(false);
                Map3x3.SetActive(false);
                Map4x4.SetActive(false);
            }
            if (ZoomStatus > Zoom1x1 && ZoomStatus <= Zoom2x2)
            {
                Map1x1.SetActive(false);
                Map2x2.SetActive(true);
                Map3x3.SetActive(false);
                Map4x4.SetActive(false);
            }
            if (ZoomStatus > Zoom2x2 && ZoomStatus <= Zoom3x3)
            {
                Map1x1.SetActive(false);
                Map2x2.SetActive(false);
                Map3x3.SetActive(true);
                Map4x4.SetActive(false);
            }
            if (ZoomStatus > Zoom3x3 && ZoomStatus <= Zoom4x4)
            {
                Map1x1.SetActive(false);
                Map2x2.SetActive(false);
                Map3x3.SetActive(false);
                Map4x4.SetActive(true);
            }
        }

        private void SetZoom(float targetSize)
        {
            transform.localScale = new Vector3(targetSize, targetSize, 1);
        }
        #endregion

    }
}