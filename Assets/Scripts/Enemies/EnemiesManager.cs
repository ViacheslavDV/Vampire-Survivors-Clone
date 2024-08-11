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
    GameOver gameOverScript;

    private void Start()
    {
        gameOverScript = player.GetComponent<GameOver>();
    }

    public void SpawnEnemy(EnemyData enemyType, bool isBoss)
    {
        GameObject enemy = EnemiesPoolManager.Instance.SpawnEnemyFromPool(enemyType.Name);
        Enemy newEnemyComponent = enemy.GetComponent<Enemy>();
        newEnemyComponent.SetTarget(player);
        newEnemyComponent.SetStats(enemyType.enemyStats);
        if(isBoss) currentBoss = newEnemyComponent;
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
        gameOverScript.TriggerWinGame();
    }
}
