using UnityEngine;

public class BoomerangProjectile : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable enemy = collision.GetComponent<IDamagable>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
