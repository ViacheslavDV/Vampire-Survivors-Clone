using System.Collections;
using UnityEngine;

public class DemonicBow : WeaponBase
{
    [SerializeField] GameObject arrowPrefab;
    private readonly float throwForce = 10f;
    private readonly float delayBetweenArrows = 0.1f;
    private const string arrowTag = "demonic-arrow";

    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    protected override void Start()
    {
        base.Start();
    }

    public override void Attack(int numberOfProjectiles)
    {
        StartCoroutine(PerformAttack(numberOfProjectiles));
    }

    private IEnumerator PerformAttack(int arrows)
    {
        for (int i = 0; i < arrows; i++)
        {
            GameObject arrow = ObjectPoolManager.Instance.SpawnProjectileFromPool(arrowTag, transform.position);
            if(arrow != null)
            {
                Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
                DemonicArrow arrowProjectile = arrow.GetComponent<DemonicArrow>();

                Vector2 arrowDirection = new Vector2(playerMovement.lastHorizontalVector, 0f);
                rb.velocity = arrowDirection * throwForce;

                arrowProjectile.damage = weaponData.weaponStats.damage;

                yield return new WaitForSeconds(delayBetweenArrows);
            } else
            {
                Debug.LogWarning("not enough demonic arrows");
            }
        }
    }
}
