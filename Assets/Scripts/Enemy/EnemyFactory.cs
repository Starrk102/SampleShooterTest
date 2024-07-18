using UnityEngine;

public class EnemyFactory : MonoBehaviour, IEnemyFactory
{
    public GameObject enemyPrefab;
    private IEnemyFactory enemyFactoryImplementation;

    public GameObject CreateEnemy(Vector3 position, int health, float speed)
    {
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        return enemy;
    }
}