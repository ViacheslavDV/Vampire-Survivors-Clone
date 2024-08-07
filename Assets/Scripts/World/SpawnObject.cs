using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] [Range(0f, 1f)] float spawnProbability;
    private const float spawnCheckInterval = 60f;

    private void Start()
    {
        StartCoroutine(SpawnWithProbabilityPeriodically());
    }
    private IEnumerator SpawnWithProbabilityPeriodically()
    {
        while (true)
        {
            SpawnObjectWithProbability();
            yield return new WaitForSeconds(spawnCheckInterval);
        }
    }

    public void SpawnObjectWithProbability()
    {
        if (Random.value < spawnProbability)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
