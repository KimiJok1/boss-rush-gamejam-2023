using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bossPrefabs;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        SpawnBoss();
    }

    void SpawnBoss()
    {
        int randomIndex = Random.Range(0, bossPrefabs.Length);
        var boss = Instantiate(bossPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        boss.GetComponent<BossController>().healthManager = GetComponent<BossHealthManager>();
        
    }
}
