using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil {
    public class RTSController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Camera Settings")]
        public Camera RTSCamera;

        [Header("Selection Settings")]
        public Transform Selection;
        public Transform Destination;

        [Header("Movement Settings")]
        [Tag] public string PlayerTag;
        public float speed;
        public float maxReach;

        bool isSelected = false;
        bool isMoving = false;

        CharacterController controller;


        void Start()
        {
            Selection.gameObject.SetActive(false);
            Destination.gameObject.SetActive(false);
            Destination.transform.parent = null;
            controller = GetComponent<CharacterController>();
            transform.localScale = new Vector3(1, 1, 1);
        }

        void Update()
        {
            if (isEnabled)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Ray ray = RTSCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        Debug.DrawLine(ray.origin, hit.point, Color.red);
                        print(hit.collider.tag);
                        if (hit.collider.tag == PlayerTag)
                        {
                            isSelected = true;
                            Selection.gameObject.SetActive(true);
                            Destination.gameObject.SetActive(false);
                        } else
                        {
                            isSelected = false;
                            Selection.gameObject.SetActive(false);
                            Destination.gameObject.SetActive(false);
                        }
                    }
                        
                }
                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    if (isSelected)
                    {
                        Ray ray = RTSCamera.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 100))
                        {
                            Debug.DrawLine(ray.origin, hit.point, Color.red);
                            print(hit.collider.tag);
                            Destination.gameObject.SetActive(true);
                            Vector3 temp = Destination.position;
                            temp.x = hit.point.x;
                            temp.z = hit.point.z;
                            Destination.position = temp;
                            isMoving = true;
                        }
                    }
                }
                if (isMoving)
                {
                    Vector3 playerDestination = Destination.position;
                    playerDestination.y = transform.position.y;
                    transform.LookAt(playerDestination);

                    Vector3 direction = playerDestination - transform.position;
                    Vector3 movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;

                    controller.Move(movement);
                }
            }
        }
    }
}
