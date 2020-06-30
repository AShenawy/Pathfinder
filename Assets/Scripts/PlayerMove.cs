using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public delegate void PlayerAction();
    public static event PlayerAction PlayerMoved;

    public float speed;
    public bool canMove = true;
    public WallCheck triggerUp;
    public WallCheck triggerDown;
    public WallCheck triggerLeft;
    public WallCheck triggerRight;


    private Rigidbody2D rb;
    private Vector2 newPosition;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Horizontal") > 0) && canMove && triggerRight.isFree)
        {
            rb.velocity = new Vector2(speed * 1 * Time.deltaTime, 0);
            canMove = false;
            //if (PlayerMoved != null)
            //    PlayerMoved();
        }

        if ((Input.GetAxis("Horizontal") < 0) && canMove && triggerLeft.isFree)
        {
            rb.velocity = new Vector2(speed * -1 * Time.deltaTime, 0);
            canMove = false;
            //if (PlayerMoved != null)
            //    PlayerMoved();
        }

        if ((Input.GetAxis("Vertical") > 0) && canMove && triggerUp.isFree)
        {
            rb.velocity = new Vector2(0, speed * 1 * Time.deltaTime);
            canMove = false;
            //if (PlayerMoved != null)
            //    PlayerMoved();
        }

        if ((Input.GetAxis("Vertical") < 0) && canMove && triggerDown.isFree)
        {
            rb.velocity = new Vector2(0, speed * -1 * Time.deltaTime);
            canMove = false;
            //if (PlayerMoved != null)
            //    PlayerMoved();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("wall"))
        {
            canMove = true;
            rb.velocity = Vector2.zero;
            if (PlayerMoved != null)
                PlayerMoved();
        }
    }

    public void StopMotion()
    {
        rb.velocity = Vector2.zero;
    }
}
