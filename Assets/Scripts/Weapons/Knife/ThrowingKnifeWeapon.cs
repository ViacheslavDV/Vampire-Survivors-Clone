using UnityEngine;

public class ThrowingKnifeWeapon : WeaponBase
{
    [SerializeField] GameObject knifePrefab;
    [SerializeField] float throwForce = 7f;
    private const float knifeScale = 0.04f;
    private readonly string knifeTag = "knife";

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
        switch (numberOfProjectiles)
        {
            case 1:
                {
                    Vector2 throwingDirection = new(playerMovement.lastHorizontalVector, 0f);
                    float rotation;
                    if (playerMovement.lastHorizontalVector == -1)
                    {
                        rotation = 0f;
                    }
                    else rotation = 180f;
                    ThrowKnife(throwingDirection, rotation);
                }
                break;
            case 2:
                ThrowKnife(Vector2.right, 180f); 
                ThrowKnife(Vector2.left, 0f);  
                break;
            case 4:
                ThrowKnife(Vector2.right, 180f); 
                ThrowKnife(Vector2.left, 0f);  
                ThrowKnife(Vector2.up, -90f);  
                ThrowKnife(Vector2.down, 90f); 
                break;
        }
    }

    private void ThrowKnife(Vector2 direction, float rotation)
    {
        GameObject throwingKnife = ObjectPoolManager.Instance.SpawnProjectileFromPool(knifeTag, transform.position);
        if (throwingKnife != null)
        {
            Rigidbody2D rb = throwingKnife.GetComponent<Rigidbody2D>();
            ThrowingKnifeProjectile throwingKnifeProjectile = throwingKnife.GetComponent<ThrowingKnifeProjectile>();

            throwingKnifeProjectile.damage = weaponData.weaponStats.damage;

            rb.velocity = direction * throwForce;
            throwingKnife.transform.localScale = new Vector2(knifeScale, knifeScale);
            throwingKnife.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        }
        else
        {
            Debug.LogWarning("Not enough knives in the pool");
        }
    }
}
