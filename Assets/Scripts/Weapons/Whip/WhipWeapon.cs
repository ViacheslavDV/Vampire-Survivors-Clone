using UnityEngine;

public class WhipWeapon : WeaponBase
{
    [SerializeField] GameObject leftWhip;
    [SerializeField] GameObject rightWhip;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f, 2f);
    PlayerMovement playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMovement>();
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
                    PerformOneAttack();
                } break;
            case 2:
                {
                    PerformTwoAttacks();
                } break;
            default: PerformOneAttack(); break;
        }
    }

    private void PerformOneAttack()
    {
        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void PerformTwoAttacks()
    {
        rightWhip.SetActive(true);
        leftWhip.SetActive(true);

        Collider2D[] colliders1 = Physics2D.OverlapBoxAll(rightWhip.transform.position, whipAttackSize, 0f);
        Collider2D[] colliders2 = Physics2D.OverlapBoxAll(leftWhip.transform.position, whipAttackSize, 0f);
        
        ApplyDamage(colliders1);
        ApplyDamage(colliders2);
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            IDamagable enemy = colliders[i].GetComponent<IDamagable>();
            if (enemy != null) enemy.TakeDamage(weaponStats.damage);
        }
    }
}
