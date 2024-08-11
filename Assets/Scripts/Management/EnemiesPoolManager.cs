using System.Collections.Generic;
using UnityEngine;

public class EnemiesPoolManager : MonoBehaviour
{
    public static EnemiesPoolManager Instance;

    [System.Serializable]
    public struct EnemiesPool
    {
        public string tag;
        public GameObject enemyObject;
        public EnemyData prefab;
        public int quantity;
        public Transform parent;
    }

    [SerializeField] GameObject player;
    private const int spawnDistanceFromPlayer = 15; 
    public List<EnemiesPool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            InitializePools();
        } else Destroy(gameObject);
    }

    private void InitializePools()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (EnemiesPool pool in pools) 
        {
            Queue<GameObject> enemyPool = new Queue<GameObject>();
            for(int i = 0; i < pool.quantity; i++)
            {
                GameObject enemy = Instantiate(pool.enemyObject, pool.parent);
                enemy.transform.parent = transform;
                Enemy newEnemyComponent = enemy.GetComponent<Enemy>();
                
                newEnemyComponent.SetTarget(player);
                newEnemyComponent.SetStats(pool.prefab.enemyStats);

                GameObject enemySprite = Instantiate(pool.prefab.animatedPrefab);
                enemySprite.transform.parent = enemy.transform;
                enemySprite.transform.localPosition = Vector3.zero;

                enemy.SetActive(false);
                enemyPool.Enqueue(enemy);
            }

            poolDictionary.Add(pool.tag, enemyPool);
        }
    }

    public GameObject SpawnEnemyFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag)) return null;

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        if (objectToSpawn == null) Debug.Log("no " + tag + " in pool was found");
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = player.transform.position + GenerateRandomPosition();
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.z = -1f;
        float determiner = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            spawnPosition.x = UnityEngine.Random.Range(-spawnDistanceFromPlayer, spawnDistanceFromPlayer);
            spawnPosition.y = spawnDistanceFromPlayer * determiner;
        }
        else
        {
            spawnPosition.x = spawnDistanceFromPlayer * determiner;
            spawnPosition.y = UnityEngine.Random.Range(-spawnDistanceFromPlayer, spawnDistanceFromPlayer);
        }

        return spawnPosition;
    }
}
