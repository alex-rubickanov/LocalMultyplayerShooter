using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    [SerializeField] GameObject healCircle;


    private void Start()
    {
        Instantiate(healCircle, gameObject.transform);
    }
    private IEnumerator SpawnHealWithDelay()
    {
        Debug.Log("Spawning new heal in 5 sec");
        yield return new WaitForSeconds(5f);
        Instantiate(healCircle, gameObject.transform);
        Debug.Log("Heal has been spawned");
        yield return null;
    }

    public void SpawnHeal()
    {
        StartCoroutine(SpawnHealWithDelay());
    }
}
