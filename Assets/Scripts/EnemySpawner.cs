using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] bool isLooping;
    [SerializeField] float timeBetweenWaves = 3f;
    [SerializeField] float waveSpawnVariance = 0.5f;
    [SerializeField] float minWaveSpawnTime = 0.3f;
    [SerializeField] WaveConfigSO[] waveConfigs;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        do {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i=0; i<currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(
                    currentWave.GetEnemyPrefab(i),
                    currentWave.GetStartingWaypoint().position,
                    Quaternion.identity, transform);

                    yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
                }

                yield return new WaitForSeconds(GetRandomWaveSpawnTime());
            }
        } while(isLooping == true);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    } 


    public float GetRandomWaveSpawnTime()
    {
        float spawnTime = UnityEngine.Random.Range(timeBetweenWaves - waveSpawnVariance,
        timeBetweenWaves + waveSpawnVariance);

        spawnTime = Mathf.Clamp(spawnTime, minWaveSpawnTime, float.MaxValue);

        return spawnTime;
    }

        public float GetRandomEnemySpawnTime()
    {
        float spawnTime = UnityEngine.Random.Range(timeBetweenWaves - waveSpawnVariance,
        timeBetweenWaves + waveSpawnVariance);

        spawnTime = Mathf.Clamp(spawnTime, minWaveSpawnTime, float.MaxValue);

        return spawnTime;
    }

}
