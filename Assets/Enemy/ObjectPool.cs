using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Fields for instantiating settings
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    // Instantiating enemies at a set rate
    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
