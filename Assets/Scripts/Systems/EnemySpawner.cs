using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Setup")]
    [SerializeField] private GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    [SerializeField] private float spawnInterval = 3f; // Time interval between spawns
    [SerializeField] private int maxEnemies = 10; // Maximum number of enemies allowed at once

    [Header("Spawn Area")]
    [SerializeField] private Vector2 spawnAreaMin; // Minimum coordinates of the spawn area
    [SerializeField] private Vector2 spawnAreaMax; // Maximum coordinates of the spawn area

    private float lastSpawnTime; // Time when the last enemy was spawned
    private int currentEnemyCount; // Current number of spawned enemies

    private void Update()
    {
        if (Time.time >= lastSpawnTime + spawnInterval && currentEnemyCount < maxEnemies) // Check if it's time to spawn a new enemy
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }
    private void SpawnEnemy() // Method to spawn a new enemy
    {
        Vector2 spawnPosition = new Vector2( // Random position within the spawn area
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );
        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; // Select a random enemy prefab
        GameObject enemy = Instantiate(prefab, spawnPosition, Quaternion.identity); // Instantiate the enemy
        currentEnemyCount++;
        enemy.transform.SetParent(transform); // Set the spawner as the parent of the spawned enemy
    }
    public void OnEnemyDestroyed() // Method to be called when an enemy is destroyed
    {
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1); // Decrease the enemy count when an enemy is destroyed
    }
}
