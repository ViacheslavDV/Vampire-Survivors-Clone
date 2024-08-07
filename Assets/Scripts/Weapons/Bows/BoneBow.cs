using UnityEngine;

public class BoneBow : WeaponBase
{
    [SerializeField] GameObject arrowPrefab;
    private readonly float throwForce = 10f;
    private readonly string arrowTag = "bone-arrow";
    protected override void Start()
    {
        base.Start();
    }
    public override void Attack(int numberOfProjectiles)
    {
        PerformMultiAttack(numberOfProjectiles);
    }

    private void PerformMultiAttack(int numberOfProjectiles)
    {
        float angleStep = 360f / numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            //GameObject arrow = InstantiateArrow(transform);
            GameObject arrow = ObjectPoolManager.Instance.SpawnProjectileFromPool(arrowTag, transform.position);
            if (arrow != null)
            {
                Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
                BoneArrow arrowProjectile = arrow.GetComponent<BoneArrow>();

                Vector2 arrowDirection = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                rb.velocity = arrowDirection * throwForce;

                arrow.transform.rotation = Quaternion.Euler(0f, 0f, angle - 135f);
                arrowProjectile.damage = weaponData.weaponStats.damage;

                angle += angleStep;
            } else
            {
                Debug.LogWarning("not enough bone arrows");
            }
            
        }
    }
}
