using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class GrabbableController : MonoBehaviour
    {
        public enum CRotationType { Horizontal, Vertical, AllDirection }

        [Space(10)]
        public bool isEnabled;

        [Header("Rotation Settings")]
        public CRotationType RotationType;
        public GameObject TargetObject;
        public Camera TargetCamera;

        [Header("Speed Settings")]
        public float RotationSpeed;

        Vector3 PrevPos = Vector3.zero;
        Vector3 PosDelta = Vector3.zero;

        bool isValid = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = TargetCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit3D;

                if (Physics.Raycast(ray, out raycastHit3D))
                {
                    if (TargetObject.name == raycastHit3D.collider.gameObject.name)
                    {
                        isValid = true;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                isValid = false;
            }

            if (Input.GetMouseButton(0))
            {
                if (isValid)
                {
                   if (RotationType == CRotationType.Horizontal)
                   {
                       PosDelta = Input.mousePosition - PrevPos;
                       TargetObject.transform.Rotate(TargetObject.transform.up, -Vector3.Dot(PosDelta, TargetCamera.transform.right) * (RotationSpeed * 0.1f), Space.World);
                   }
                   if (RotationType == CRotationType.Vertical)
                   {
                       PosDelta = Input.mousePosition - PrevPos;
                       TargetObject.transform.Rotate(TargetCamera.transform.right * (RotationSpeed * 0.1f), Vector3.Dot(PosDelta, TargetCamera.transform.up), Space.World);
                   }
                   if (RotationType == CRotationType.AllDirection)
                   {
                       PosDelta = Input.mousePosition - PrevPos;
                       TargetObject.transform.Rotate(TargetObject.transform.up, -Vector3.Dot(PosDelta, TargetCamera.transform.right) * (RotationSpeed * 0.1f), Space.World);
                       TargetObject.transform.Rotate(TargetCamera.transform.right * (RotationSpeed * 0.1f), Vector3.Dot(PosDelta, TargetCamera.transform.up), Space.World);
                   }
                }
            }
            PrevPos = Input.mousePosition;
        }
    }
}
