using UnityEngine;
using UnityEngine.UI;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] GameObject player;

    [SerializeField] Slider bossHealthBar;
    private float maxBossHealth;
    private Enemy currentBoss;
    public void SpawnEnemy(EnemyData enemyType, bool isBoss)
    {
        GameObject enemy = EnemiesPoolManager.Instance.SpawnEnemyFromPool(enemyType.Name);
        Enemy newEnemyComponent = enemy.GetComponent<Enemy>();
        newEnemyComponent.SetTarget(player);
        newEnemyComponent.SetStats(enemyType.enemyStats);
        /*newEnemy.transform.parent = transform;
        if (isBoss) currentBoss = newEnemyComponent;

        GameObject enemySprite = Instantiate(enemyType.animatedPrefab);
        enemySprite.transform.parent = newEnemy.transform;
        enemySprite.transform.localPosition = Vector3.zero;*/
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.z = 0f;
        float determiner = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            spawnPosition.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            spawnPosition.y = spawnArea.y * determiner;
        } else
        {
            spawnPosition.x = spawnArea.x * determiner;
            spawnPosition.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
        }
        
        return spawnPosition;
    }

    public void UpdateBossHealth()
    {
        if (currentBoss == null) return;
        bossHealthBar.maxValue = maxBossHealth;
        bossHealthBar.value = currentBoss.enemyStats.hp;

        if (currentBoss.enemyStats.hp <= 0)
        {
            TriggerBossDeath();
            currentBoss = null;
        }
    }

    public void TriggerBossSpawn(EnemyStats bossData)
    {
        maxBossHealth = bossData.hp;
        bossHealthBar.gameObject.SetActive(true);
    }

    private void TriggerBossDeath()
    {
        bossHealthBar.gameObject.SetActive(false);
        Debug.Log("boss is dead");
    }
}
