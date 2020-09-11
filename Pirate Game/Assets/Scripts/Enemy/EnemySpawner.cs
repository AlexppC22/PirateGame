using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    public OptionsInformation Info;
    public GameObject spawner;
    public GameObject[] enemies;
    public Player_Mov player;
    [Header("Spawn Settings")]
    public float spawnerRadius = 5f;
    public float spawnerTime = 10;
    [Header("Debug")]
    public bool canSpawn = true;
    
    void Start()
    {
        spawnerTime = Info.SpawnTime;
    }
    void Update()
    {
        if(canSpawn)
        {
            Vector2 spawnPosition = spawner.transform.position;
            spawnPosition += Random.insideUnitCircle.normalized * spawnerRadius;
            Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPosition, Quaternion.identity);
            canSpawn = false;
            if(player.stopSpawns == false)
            {
                StartCoroutine(SpawnEnemy());
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnerTime);
        canSpawn = true;
    }
}
