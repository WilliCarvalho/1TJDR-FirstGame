using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (true)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}
