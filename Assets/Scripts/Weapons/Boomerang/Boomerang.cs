using UnityEngine;
using System.Collections;

public class Boomerang : WeaponBase
{
    private const float circleRadius = 3.5f;
    private const int maxBoomerangs = 6;
    private const string boomerangTag = "boomerang";
    private GameObject[] allBoomerangs;
    private float[] angles;
    private int currentProjectileCount = 0;

    protected override void Start()
    {
        base.Start();
        allBoomerangs = new GameObject[maxBoomerangs];
        angles = new float[maxBoomerangs];
    }

    public override void Attack(int numberOfProjectiles)
    {
        StartCoroutine(Rotate(numberOfProjectiles));
    }

    private IEnumerator Rotate(int numberOfProjectiles)
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            if (allBoomerangs[i] == null)
            {
                allBoomerangs[i] = ObjectPoolManager.Instance.SpawnProjectileFromPool(boomerangTag, transform.position);
                Rigidbody2D rb = allBoomerangs[i].GetComponent<Rigidbody2D>();
                BoomerangProjectile projectile = allBoomerangs[i].GetComponent<BoomerangProjectile>();
                projectile.damage = weaponData.weaponStats.damage;
                angles[i] = i * (360f / numberOfProjectiles);
            }
            if(numberOfProjectiles != currentProjectileCount)
            {
                angles[i] = i * (360f / numberOfProjectiles);
            }
        }

        currentProjectileCount = numberOfProjectiles;

        for (int i = 0; i < currentProjectileCount; i++)
        {
            angles[i] += weaponData.weaponStats.radiusOfAttack;
            if (angles[i] >= 360f)
            {
                angles[i] -= 360f;
            }
            float rad = angles[i] * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * circleRadius;
            allBoomerangs[i].transform.position = transform.position + offset;
        }
        yield return new WaitForSeconds(weaponData.weaponStats.timeBetweenAtacks);
    }
}
