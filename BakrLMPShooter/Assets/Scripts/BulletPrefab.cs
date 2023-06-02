using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float bulletSpeed;
    [SerializeField] float damage;
    PlayerController playerController;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    void FixedUpdate()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        playerController = collision.GetComponent<PlayerController>();
        if(playerController != null)
        {
            playerController.TakeDamage(damage);
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
