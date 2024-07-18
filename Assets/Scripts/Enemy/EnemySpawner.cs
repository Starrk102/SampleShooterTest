using UnityEngine;
using VContainer;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2f;
    private float nextSpawnTime = 0f;
    private IEnemyFactory enemyFactory;
    public Transform[] spawnPoints;
    private GameSettings gameSettings;
        
    [Inject]
    public void Construct(Transform[] spawnPointsEnemy, GameSettings gameSettings)
    {
        spawnPoints = spawnPointsEnemy;
        this.gameSettings = gameSettings;
    }
    
    void Start()
    {
        enemyFactory = GetComponent<IEnemyFactory>();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[spawnIndex].position;
        enemyFactory.CreateEnemy(spawnPosition, gameSettings.healthEnemy, gameSettings.speedEnemy);
    }
}