/**************************************************************************************************************
 * Author : Rickman Roedavan
 * Version: 2.12
 * Desc   : Script untuk mengatur mekanisme raycast
 **************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{

    public class RaycastController : MonoBehaviour
    {
        public enum CClickType { LeftMouse, MiddleMouse, RightMouse, Touch }
        public enum CFilterSelection { Everything, ByName, ByTag }

        [Space(10)]
        public bool isEnabled;

        [Header("Object Settings")]
        public GameObject TargetObject;
        public Camera TargetCamera;

        [Header("Click Settings")]
        public CClickType ClickType;

        [Header("Object Selection Settings")]
        public CFilterSelection ObjectSelection;
        public string ObjectName;
        [Tag] public string[] ObjectTag;

        [Header("OnHit Event Settings")]
        public bool usingOnHitEvent;
        public UnityEvent OnHitEvent;

        [Header("OffHit Event Settings")]
        public bool usingOffHitEvent;
        public UnityEvent OffHitEvent;

        [Header("Selected Value Settings")]
        [ReadOnly] public int SelectedObjectType = 0;
        [ReadOnly] public string SelectedObjectTag;
        [ReadOnly] public string SelectedObjectName;

        bool IsValidSelection(string SelectedObjectTag, string SelectedObjectName)
        {
            bool result = false;
            if (ObjectSelection == CFilterSelection.Everything)
            {
                result = true;
            }
            if (ObjectSelection == CFilterSelection.ByTag)
            {
                for (int i = 0; i < ObjectTag.Length; i++)
                {
                    if (ObjectTag[i] == SelectedObjectTag)
                    {
                        result = true;
                        break;
                    }
                }
            }
            if (ObjectSelection == CFilterSelection.ByName)
            {
                if (ObjectName == SelectedObjectName)
                {
                    result = true;
                }
            }
            return result;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                CastingRay();
            }
        }

        bool ValidClick()
        {
            bool result = false;
            if (ClickType == CClickType.LeftMouse && Input.GetKeyUp(KeyCode.Mouse0) ||
                ClickType == CClickType.Touch && Input.GetKeyUp(KeyCode.Mouse0))
            {
                result = true;
            }
            if (ClickType == CClickType.MiddleMouse && Input.GetKeyUp(KeyCode.Mouse2))
            {
                result = true;
            }
            if (ClickType == CClickType.RightMouse && Input.GetKeyUp(KeyCode.Mouse1))
            {
                result = true;
            }
            return result;
        }

        public void CastingRay()
        {
            if (ValidClick())
            {
                bool ValidCollision = false;

                //-- cek tabrakan dengan objeck 2d
                Ray ray = TargetCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D raycastHit2D = Physics2D.GetRayIntersection(ray);

                if (raycastHit2D.collider != null)
                {
                    Debug.Log("Hit 2D Coliider");
                    SelectedObjectName = raycastHit2D.collider.gameObject.name;
                    SelectedObjectTag = raycastHit2D.collider.gameObject.tag;
                    if (IsValidSelection(raycastHit2D.collider.gameObject.tag, raycastHit2D.collider.gameObject.name))
                    {
                        //TargetObject.CurrentValue = raycastHit2D.collider.gameObject;
                        SelectedObjectType = 2;
                        ValidCollision = true;
                    }
                }
                else
                {
                    //-- cek tabrakan dengan objeck 3d
                    ray = TargetCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit raycastHit3D;

                    if (Physics.Raycast(ray, out raycastHit3D))
                    {
                        Debug.Log("Hit 3D Coliider");
                        SelectedObjectName = raycastHit3D.collider.gameObject.name;
                        SelectedObjectTag = raycastHit3D.collider.gameObject.tag;
                        if (IsValidSelection(raycastHit3D.collider.gameObject.tag, raycastHit3D.collider.gameObject.name))
                        {
                            //SelectedObject.CurrentValue = raycastHit3D.collider.gameObject;
                            SelectedObjectType = 3;
                            ValidCollision = true;
                        }
                    }
                }

                if (ValidCollision)
                {
                    if (usingOnHitEvent)
                    {
                        OnHitEvent.Invoke();
                    }
                }

                if (!ValidCollision)
                {
                    //SelectedObject.CurrentValue = null;
                    if (usingOffHitEvent)
                    {
                        OffHitEvent.Invoke();
                    }
                }
            }
        }
    }
}
