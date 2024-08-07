using UnityEngine;
using System.Collections;
public class BombUnit : MonoBehaviour
{
    public float damage;
    public float radiusOfAttack;
    public float timeToExplode;
    public System.Action OnExplosion;
    private Coroutine explosionCoroutine;

    [SerializeField] private GameObject explosionPrefab;
    public const float explosionDuration = 1f;

    private void OnDisable()
    {
        StopExplosionCoroutine();
    }

    public void ActivateBomb()
    {
        StartExplosionCoroutine();
    }

    private void StartExplosionCoroutine()
    {
        StopExplosionCoroutine();
        explosionCoroutine = StartCoroutine(ExplodeWithDelay());
    }

    private void StopExplosionCoroutine()
    {
        if (explosionCoroutine != null)
        {
            StopCoroutine(explosionCoroutine);
            explosionCoroutine = null;
        }
    }

    private IEnumerator ExplodeWithDelay()
    {
        yield return new WaitForSeconds(timeToExplode);
        Explode();
    }

    private void Explode()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, explosionDuration);
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radiusOfAttack);
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamagable enemy = colliders[i].GetComponent<IDamagable>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        OnExplosion?.Invoke();
        gameObject.SetActive(false);
    }
}
