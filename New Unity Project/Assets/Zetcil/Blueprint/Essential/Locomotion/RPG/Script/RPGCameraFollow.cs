using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class RPGCameraFollow : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Camera Settings")]
        public Camera CameraController;

        [Header("Movement Settings")]
        public bool shouldRotate = true;
        public float distance = 10.0f;
        public float height = 5.0f;
        public float heightDamping = 2.0f;
        public float rotationDamping = 3.0f;
        float wantedRotationAngle;
        float wantedHeight;
        float currentRotationAngle;
        float currentHeight;
        Quaternion currentRotation;

        void Awake()
        {
            CameraController.transform.parent = null;
        }

        void LateUpdate()
        {
            if (transform)
            {
                wantedRotationAngle = transform.eulerAngles.y;
                wantedHeight = transform.position.y + height;
                currentRotationAngle = CameraController.transform.eulerAngles.y;
                currentHeight = CameraController.transform.position.y;
                currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
                currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
                currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
                CameraController.transform.position = transform.position;
                CameraController.transform.position -= currentRotation * Vector3.forward * distance;
                CameraController.transform.position = new Vector3(CameraController.transform.position.x, currentHeight, CameraController.transform.position.z);
                if (shouldRotate)
                    CameraController.transform.LookAt(transform);
            }

        }
    }
}
