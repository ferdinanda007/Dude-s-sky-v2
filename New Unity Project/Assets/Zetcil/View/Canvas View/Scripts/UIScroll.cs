using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Inspector fields
    [SerializeField] float startSize = 1;
    [SerializeField] float minSize = 0.5f;
    [SerializeField] float maxSize = 1;

    [SerializeField] private float zoomRate = 5;
    #endregion

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
    }

    private void SetZoom(float targetSize)
    {
        transform.localScale = new Vector3(targetSize, targetSize, 1);
    }
    #endregion
}