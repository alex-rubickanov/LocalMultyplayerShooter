using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] KeyCode shootKeyCode;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnerTransform;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(shootKeyCode))
        {
            if(playerController.isFacingRight)
            {
                Instantiate(bulletPrefab, bulletSpawnerTransform.position, Quaternion.Euler(0, 0, 0));
            } else
            {
                Instantiate(bulletPrefab, bulletSpawnerTransform.position, Quaternion.Euler(0, 0, 180));
            }
            
        }
    }
}
