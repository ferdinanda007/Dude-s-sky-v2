using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class TDSController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Movement Settings")]
        public float walkSpeed;
        public float curSpeed;
        public float maxSpeed;

        [Header("Mouse Settings")]
        public bool usingMouseLook;
        public float Zoffset;

        CharacterController controller;
        Rigidbody2D rigidbody2D;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            transform.localScale = new Vector3(1, 1, 1);
        }

        void FixedUpdate()
        {
            curSpeed = walkSpeed;
            maxSpeed = curSpeed;

            // Move senteces
            rigidbody2D.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                               Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));

            if (usingMouseLook)
            {
                // convert mouse position into world coordinates
                Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // get direction you want to point at
                Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

                // set vector of transform directly
                transform.up = direction;

                transform.rotation = Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + Zoffset));
            }
        }
    }
}