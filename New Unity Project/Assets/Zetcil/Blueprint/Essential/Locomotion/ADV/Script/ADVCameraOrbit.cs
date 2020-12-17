using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class ADVCameraOrbit : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Camera Settings")]
        public Camera CameraController;

        [Header("Movement Settings")]
        public float turnSpeed = 4.0f;
        public Vector3 offset;

        void Start()
        {
            CameraController.transform.parent = null;
        }

        void LateUpdate()
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            CameraController.transform.position = transform.position + offset;
            CameraController.transform.LookAt(transform.position);
        }
    }
}
