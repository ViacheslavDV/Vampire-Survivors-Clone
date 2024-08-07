using UnityEngine;
using System.Collections;
public class PowerOrb : WeaponBase
{
    protected override void Start()
    {
        base.Start();
    }

    public override void Attack(int numberOfProjectiles)
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, weaponStats.radiusOfAttack);
        ApplyDamage(colliders);
        yield return new WaitForSeconds(weaponStats.timeBetweenAtacks);
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamagable enemy = colliders[i].GetComponent<IDamagable>();
            if (enemy != null) enemy.TakeDamage(weaponStats.damage);
        }
    }
}
