using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("----------PROPERTIES----------")]
    [SerializeField] public float health;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Color playerColor;

    [Header("----------CONTROLS----------")]
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode jump;

    [Header("----------OTHER----------")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Slider healthBar;
    [HideInInspector] public bool isFacingRight;
    [SerializeField] private SpriteRenderer playerSprite;
    private Rigidbody2D rb;
    private float horizontal;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 
        healthBar.maxValue = health;
        healthBar.value = health;
        playerSprite.color = playerColor;
        healthBar.image.color = playerColor;
    }

    private void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            horizontal = -1;
        } else if (Input.GetKey(moveRight))
        {
            horizontal = 1;
        } else if(Input.GetKeyUp(moveRight) || Input.GetKeyUp(moveLeft))
        {
            horizontal = 0;
        }

        
        if(Input.GetKeyDown(jump) && IsGrounded()) 
        {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
      

        Flip();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
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


    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;
    }
}
