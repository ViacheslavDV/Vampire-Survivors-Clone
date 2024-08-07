using UnityEngine;

public class ObjectDispose : MonoBehaviour
{
    Transform playerTransform;
    const float distanceToDisposal = 40f;

    private void Start()
    {
        playerTransform = GameManager.instance.playerTransform;
    }
    private void Update()
    {
        if (playerTransform == null) return;
        float distanceFromPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if(distanceFromPlayer > distanceToDisposal) Destroy(gameObject);
    }
}
