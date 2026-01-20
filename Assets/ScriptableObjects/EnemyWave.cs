using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "Enemy/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    public int maxEnemies = 6;
    public float spawnInterval = 2f;
    public GameObject[] enemyPrefabs;
    public float waveDuration = 10f;
    
}
