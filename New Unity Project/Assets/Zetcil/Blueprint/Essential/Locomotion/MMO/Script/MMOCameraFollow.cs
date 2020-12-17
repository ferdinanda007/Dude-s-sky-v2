using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class MMOCameraFollow : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Camera Settings")]
        public Camera CameraController;

        [Header("Movement Settings")]
        // The distance in the x-z plane to the target
        public float distance = 10.0f;
        // the height we want the camera to be above the target
        public float height = 5.0f;
        // How much we want to dampen the height
        public float heightDamping = 2.0f;

        float wantedHeight;
        float currentHeight;

        void Awake()
        {
            CameraController.transform.parent = null;
        }

        void LateUpdate()
        {
            // Early out if we don't have a camera
            if (!CameraController)
                return;

            wantedHeight = transform.position.y + height;
            currentHeight = CameraController.transform.position.y;

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            CameraController.transform.position = transform.position;
            CameraController.transform.position -= Vector3.forward * distance;
            CameraController.transform.eulerAngles = Vector3.Lerp(CameraController.transform.eulerAngles, transform.eulerAngles, 1);

            // Set the height of the camera
            Vector3 temp = CameraController.transform.position;
            temp.y = currentHeight;
            CameraController.transform.position = temp;

            // Always look at the target
            CameraController.transform.LookAt(transform);
        }
    }
}
