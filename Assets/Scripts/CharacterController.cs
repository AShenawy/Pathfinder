using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;
    public float walkAcceleration;
    public float groundDeceleration;
    public float jumpHeight;
    private BoxCollider2D boxCollider;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            velocity.y = 0;

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
            }
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;

        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
            velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, walkAcceleration * Time.deltaTime);
        else
            velocity.x = Mathf.MoveTowards(velocity.x, 0, groundDeceleration * Time.deltaTime);

        transform.Translate(velocity * Time.deltaTime);

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);

        isGrounded = false;

        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);

            if (colliderDistance.isOverlapped)
            {
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);

                if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
                    isGrounded = true;
            }
        }
    }
}
