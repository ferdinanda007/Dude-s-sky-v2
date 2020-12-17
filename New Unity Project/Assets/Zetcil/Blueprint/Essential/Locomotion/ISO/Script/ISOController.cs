using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{
    public class ISOController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Movement Settings")]
        public float speed;

        bool isMoving = false;
        CharacterController controller;

        Vector3 direction;
        Vector3 movement;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            transform.localScale = new Vector3(1, 1, 1);
        }

        void Update()
        {
            if (isEnabled)
            {
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 90, 0);
                    direction = Vector3.right;
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 270, 0);
                    direction = Vector3.left;
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
                if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    direction = Vector3.forward;
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
                if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    direction = Vector3.back;
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 45, 0);
                    direction = new Vector3(1, 0, 1);
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 135, 0);
                    direction = new Vector3(1, 0, -1);
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 315, 0);
                    direction = new Vector3(-1, 0, 1);
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 215, 0);
                    direction = new Vector3(-1, 0, -1);
                    movement = direction.normalized * speed * Time.deltaTime;
                    if (movement.magnitude > direction.magnitude) movement = direction;
                    controller.Move(movement);
                }
            }
        }
    }
}
