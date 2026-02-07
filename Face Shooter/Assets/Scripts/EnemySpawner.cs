using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float spawnRate = 1.5f;
    public float spawnRadius = 8f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = (Vector2)player.position +
                           Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}