using UnityEngine;

public class DemonicArrow : MonoBehaviour
{
    public float damage;
    private const float lifetime = 2.5f;

    private void OnEnable()
    {
        Invoke(nameof(DeactivateArrow), lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DeactivateArrow));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable enemy = collision.GetComponent<IDamagable>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            DeactivateArrow();
        }
    }

    private void DeactivateArrow()
    {
        gameObject.SetActive(false);
    }
}
