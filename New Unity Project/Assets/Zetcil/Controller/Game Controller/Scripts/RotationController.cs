using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{
    public class RotationController : MonoBehaviour
    {
        public enum CClickType { LeftMouse, MiddleMouse, RightMouse, Touch }

        public enum CRotationType { Horizontal, Vertical, AllDirection }

        public enum CFilterSelection { Everything, ByName, ByTag }

        [Space(10)]
        public bool isEnabled;

        [Header("Object Settings")]
        public Camera TargetCamera;
        public VarObject SelectedObject;

        [Header("Click Settings")]
        public CClickType ClickType;

        [Header("Object Selection Settings")]
        public CFilterSelection ObjectSelection;
        public string ObjectName;
        [Tag] public string[] ObjectTag;

        [Header("Rotation Settings")]
        public CRotationType RotationType;

        [Header("Speed Settings")]
        public float RotationSpeed;

        Vector3 PrevPos = Vector3.zero;
        Vector3 PosDelta = Vector3.zero;

        [Header("Selected Value Settings")]
        [ReadOnly] public int SelectedObjectType = 0;
        [ReadOnly] public string SelectedObjectTag;
        [ReadOnly] public string SelectedObjectName;

        bool ValidCollision;

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
        // Start is called before the first frame update
        void Start()
        {

        }

        bool ValidClick()
        {
            bool result = false;
            if (ClickType == CClickType.LeftMouse && Input.GetKeyDown(KeyCode.Mouse0) ||
                ClickType == CClickType.Touch && Input.GetKeyDown(KeyCode.Mouse0))
            {
                result = true;
            }
            if (ClickType == CClickType.MiddleMouse && Input.GetKeyDown(KeyCode.Mouse2))
            {
                result = true;
            }
            if (ClickType == CClickType.RightMouse && Input.GetKeyDown(KeyCode.Mouse1))
            {
                result = true;
            }
            return result;
        }

        // Update is called once per frame
        void Update()
        {
            CastingRay();

            if (ValidCollision)
            {
                if (RotationType == CRotationType.Horizontal)
                {
                    PosDelta = Input.mousePosition - PrevPos;
                    SelectedObject.CurrentValue.transform.Rotate(SelectedObject.CurrentValue.transform.up, -Vector3.Dot(PosDelta, TargetCamera.transform.right) * (RotationSpeed * 0.1f), Space.World);
                }
                if (RotationType == CRotationType.Vertical)
                {
                    PosDelta = Input.mousePosition - PrevPos;
                    SelectedObject.CurrentValue.transform.Rotate(TargetCamera.transform.right * (RotationSpeed * 0.1f), Vector3.Dot(PosDelta, TargetCamera.transform.up), Space.World);
                }
                if (RotationType == CRotationType.AllDirection)
                {
                    PosDelta = Input.mousePosition - PrevPos;
                    SelectedObject.CurrentValue.transform.Rotate(SelectedObject.CurrentValue.transform.up, -Vector3.Dot(PosDelta, TargetCamera.transform.right) * (RotationSpeed * 0.1f), Space.World);
                    SelectedObject.CurrentValue.transform.Rotate(SelectedObject.CurrentValue.transform.right * (RotationSpeed * 0.1f), Vector3.Dot(PosDelta, TargetCamera.transform.up), Space.World);
                }
            }

            PrevPos = Input.mousePosition;
        }

        public void CastingRay()
        {
            if (ValidClick())
            {
                ValidCollision = false;

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
                        SelectedObject.CurrentValue = raycastHit2D.collider.gameObject;
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
                            SelectedObject.CurrentValue = raycastHit3D.collider.gameObject;
                            SelectedObjectType = 3;
                            ValidCollision = true;
                        }
                    }
                }

            }
        }
    }
}
