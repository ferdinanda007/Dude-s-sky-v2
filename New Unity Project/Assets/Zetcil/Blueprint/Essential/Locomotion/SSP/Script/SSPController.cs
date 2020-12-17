using UnityEngine;
using UnityEngine.Events;

namespace Zetcil
{
    public class SSPController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Movement Settings")]
        public float movementSpeed = 3f;
        public float jumpSpeed = 500f;
        public bool isGrounded = true;

        Rigidbody2D rigidbody2D;
        SpriteRenderer sprite2D;

        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            sprite2D = GetComponent<SpriteRenderer>();
            transform.localScale = new Vector3(1, 1, 1);
        }

        void Update()
        {
            if (isGrounded)
            {
                rigidbody2D.gravityScale = 2.1f;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * movementSpeed * Time.deltaTime;
                if (transform.localScale.x > 0)
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * movementSpeed * Time.deltaTime;
                if (transform.localScale.x < 0)
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (!isGrounded)
                {
                    rigidbody2D.gravityScale += 2;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (isGrounded)
                {
                    isGrounded = false;
                    rigidbody2D.AddForce(Vector3.up * jumpSpeed);
                }
                Invoke("Cooldown", 1);
            }
        }

        void Cooldown()
        {
            isGrounded = true;
        }
    }
}