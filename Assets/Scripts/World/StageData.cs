using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class StageEvent 
{
    public float triggerTime;
    public EnemyData enemyType;
    public int enemyCount;
}


[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<StageEvent> stageEvents;
}
