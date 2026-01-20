using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    
    public EnemySpawner spawner { get; private set; }
    [SerializeField] private EnemyWave[] waves;
    private EnemyWave currentWave;
    private int waveIndex = 0;

    private void Awake()
    {
        spawner = GameObject.FindAnyObjectByType<EnemySpawner>();
        currentWave = waves[waveIndex];

    }
    private void Start()
    {
        StartCoroutine(ManageWaves());
    }
    private void Update()
    {
        
        
    }
    public IEnumerator ManageWaves()
    {
        while (true)
        {
            if (spawner.spawnedEnemyCount >= currentWave.maxEnemies || waveIndex == 0)
            {
                currentWave = waves[waveIndex];
                spawner.setWave(currentWave);
                Debug.Log(currentWave.name);
            }
            yield return new WaitForSeconds(currentWave.waveDuration);

            if (waveIndex < waves.Length - 1 && spawner.spawnedEnemyCount > currentWave.maxEnemies)
            {
                waveIndex++;
                
            }
           
        }
    }
}
