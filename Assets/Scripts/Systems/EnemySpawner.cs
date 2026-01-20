using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Setup")]
    public EnemyWave wave { get; private set; }

    [Header("Spawn Area")]
    [SerializeField] private Vector2 spawnAreaMin; // Minimum coordinates of the spawn area
    [SerializeField] private Vector2 spawnAreaMax; // Maximum coordinates of the spawn area

    private float lastSpawnTime; // Time when the last enemy was spawned
    public int currentEnemyCount { get; private set; } // Current number of spawned enemies
    public int spawnedEnemyCount { get; private set; } 

    private void Update()
    {
        if (Time.time >= lastSpawnTime + wave.spawnInterval && currentEnemyCount < wave.maxEnemies) // Check if it's time to spawn a new enemy
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
        int randomenemy = Random.Range(0, wave.enemyPrefabs.Length);
        Debug.Log(wave.enemyPrefabs.Length);
        
        GameObject prefab = wave.enemyPrefabs[randomenemy]; // Select a random enemy prefab
        GameObject enemy = Instantiate(prefab, spawnPosition, Quaternion.identity); // Instantiate the enemy
        currentEnemyCount++;

        spawnedEnemyCount++; 
        enemy.transform.SetParent(transform); // Set the spawner as the parent of the spawned enemy
    }
    public void OnEnemyDestroyed() // Method to be called when an enemy is destroyed
    {
        currentEnemyCount = Mathf.Max(0, currentEnemyCount - 1); // Decrease the enemy count when an enemy is destroyed
    }
    public void setWave(EnemyWave newWave)
    {
        
        wave = newWave;
        
        
    }
}
