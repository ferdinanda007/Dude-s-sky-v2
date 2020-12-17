using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{
    public class FPSMouseLook : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Camera Settings")]
        public Camera TargetCamera;

        [Header("Mouse Settings")]
        public bool CursorLocked;
        public bool CursorVisible;
        public bool lookAutomatic = true;
        public KeyCode MouseKey = KeyCode.Mouse1;

        [Header("Rotation Settings")]
        public float speedHorizontal = 2.0f;
        public float speedVertical = 2.0f;

        private float yaw = 0.0f;
        private float pitch = 0.0f;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void SetCursorVisible(bool aValue)
        {
            CursorVisible = aValue;
        }

        public void SetCursorLocked(bool aValue)
        {
            CursorLocked = aValue;
        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    CursorVisible = true;
                    CursorLocked = false;
                }
                if (CursorLocked)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                } else
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                Cursor.visible = CursorVisible;

                if (lookAutomatic)
                {
                    yaw += speedHorizontal * Input.GetAxis("Mouse X");
                    pitch -= speedVertical * Input.GetAxis("Mouse Y");
                    TargetCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
                }
                else if (Input.GetKey(MouseKey))
                {
                    yaw += speedHorizontal * Input.GetAxis("Mouse X");
                    pitch -= speedVertical * Input.GetAxis("Mouse Y");
                    TargetCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
                }
            }
        }
    }
}
