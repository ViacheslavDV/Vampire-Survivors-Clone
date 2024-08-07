using System.Collections;
using UnityEngine;

public class CrystalBomb : WeaponBase
{
    private const float delayBetweenBombs = 5f;
    private const float timeToExplode = 1.8f;
    private const string bombTag = "bomb";
    private int activeBombs = 0; 

    protected override void Start()
    {
        base.Start();
    }

    public override void Attack(int numberOfProjectiles)
    {
        if (activeBombs < numberOfProjectiles)
        {
            StartCoroutine(DropBomb(numberOfProjectiles));
        }
    }

    private IEnumerator DropBomb(int numberOfProjectiles)
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            if (activeBombs >= numberOfProjectiles)
            {
                yield break;
            }

            GameObject bomb = ObjectPoolManager.Instance.SpawnProjectileFromPool(bombTag, transform.position);
            BombUnit bombProjectile = bomb.GetComponent<BombUnit>();
            bombProjectile.damage = weaponData.weaponStats.damage;
            bombProjectile.radiusOfAttack = weaponData.weaponStats.radiusOfAttack;
            bombProjectile.timeToExplode = timeToExplode;

            bombProjectile.OnExplosion = () => DecreaseActiveBombs();
            bombProjectile.ActivateBomb();

            activeBombs++;
            yield return new WaitForSeconds(delayBetweenBombs);
        }
        yield return new WaitForSeconds(weaponData.weaponStats.timeBetweenAtacks);
    }

    private void DecreaseActiveBombs()
    {
        activeBombs--;
    }
}
