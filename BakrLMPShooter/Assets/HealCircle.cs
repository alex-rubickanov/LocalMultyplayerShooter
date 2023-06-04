using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCircle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float healPoints;
    private HealSpawner healSpawner;

    private void Start()
    {
        healSpawner = gameObject.GetComponentInParent<HealSpawner>();
    }
    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if(playerController != null) {
            collision.GetComponent<PlayerController>().Heal(healPoints);
            healSpawner.SpawnHeal();
            Destroy(gameObject);
        }
        
    }
}
