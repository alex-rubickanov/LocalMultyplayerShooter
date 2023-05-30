using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private LayerMask groundLayer;
    
    private bool isFacingRight;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;


    [Header("----------PROPERTIES----------")]
    [SerializeField] private float player;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        if(player == 1) {
            isFacingRight = true;
        } else {
            isFacingRight = false;
        }
    }

    private void Update()
    {
        if(player == 1) {
            horizontal = Input.GetAxisRaw("Horizontal1");
        } else if(player == 2) {
            horizontal = Input.GetAxisRaw("Horizontal2");
        }

        if (player == 1) {
            if(Input.GetKeyDown(KeyCode.W) && IsGrounded()) {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        } else if (player == 2) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()) {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        }

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        Debug.Log(Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer));
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
