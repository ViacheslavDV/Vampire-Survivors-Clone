using UnityEngine;
public class StageEventManager : MonoBehaviour
{
    [SerializeField] EnemiesManager enemiesManager;
    [SerializeField] StageData stageData;
    TimeUI timeUI;
    public float currentGameTime;
    private int stageIndex = 0;
    private readonly float timeOfBossToSpawn = 1200f; 
    private int bossesLeftToSpawn = 1;
    private readonly int bossStageId = 120;

    private void Awake()
    {
        timeUI = FindAnyObjectByType<TimeUI>();
    }

    private void Start()
    {
        Invoke(nameof(TriggerBoss), timeOfBossToSpawn);
    }

    private void Update()
    {
        currentGameTime += Time.deltaTime;
        timeUI.UpdateTime(currentGameTime);

        if (currentGameTime > stageData.stageEvents[stageIndex].triggerTime && ((stageIndex + 1) != stageData.stageEvents.Count))
        {
            //if ((stageIndex + 1) == stageData.stageEvents.Count) return;
            
            for (int i = 0; i < stageData.stageEvents[stageIndex].enemyCount; i++)
            {
                bool isBoss = false;
                if (bossStageId == stageIndex)
                {
                    isBoss = true;
                    bossesLeftToSpawn--;
                }
                enemiesManager.SpawnEnemy(stageData.stageEvents[stageIndex].enemyType, isBoss);
            }
            stageIndex++;
        }

        if (bossesLeftToSpawn == 0)
        {
            enemiesManager.UpdateBossHealth();
        }
    }

    private void TriggerBoss()
    {
        EnemyStats bossData = stageData.stageEvents[bossStageId].enemyType.enemyStats;
        enemiesManager.TriggerBossSpawn(bossData);
    }
}
