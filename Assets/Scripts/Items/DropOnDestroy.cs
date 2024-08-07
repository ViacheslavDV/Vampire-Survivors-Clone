using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject droppableItem;
    [SerializeField][Range(0f, 1f)] float dropChance = 0f;
    bool isQuitting = false;
    private static List<GameObject> spawnedItems = new List<GameObject>();
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void OnDestroy()
    {
        if (isQuitting) return;

        if(Random.value < dropChance)
        {
            Transform transform = Instantiate(droppableItem).transform;
            transform.position = gameObject.transform.position;
        }
    }

}
