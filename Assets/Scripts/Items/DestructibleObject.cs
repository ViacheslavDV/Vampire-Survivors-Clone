using UnityEngine;

public class DestructibleObject : MonoBehaviour, IDamagable
{
    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
        GetComponent<DropOnDestroy>().OnDestroy();
    }
}
