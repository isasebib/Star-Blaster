using UnityEngine;

public class PathFinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    Transform[] waypoints;
    int wayPointIndex;
    void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWave(); 
        waypoints = waveConfig.GetWaypoints();
        transform.position = waveConfig.GetStartingWaypoint().position;   
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(wayPointIndex < waypoints.Length)
        {
            Vector3 targetPos = waypoints[wayPointIndex].position;
            float moveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveDelta);
            if (transform.position == targetPos)
            {
                wayPointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }    
}
