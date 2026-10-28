using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig ", menuName = "WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float enemySpawnVariance = 0.1f;
    [SerializeField] float minSpawnTime = 0.2f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWaypoints()
    {
        Transform[] wayPoints = new Transform[pathPrefab.childCount];
        for(int i = 0; i < pathPrefab.childCount; i++)
        {
            wayPoints[i] = pathPrefab.GetChild(i);
        }

        return wayPoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomEnemySpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - enemySpawnVariance,
        timeBetweenEnemySpawns + enemySpawnVariance);

        spawnTime = Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);

        return spawnTime;
    }
    
}
