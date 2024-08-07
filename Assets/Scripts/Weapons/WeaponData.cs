using UnityEngine;
using System;

[Serializable]
public class WeaponStats
{
    public float damage;
    public float defaultDamage;
    public float timeBetweenAtacks;
    public float defaultTimeBetweenAtacks;
    public int numberOfProjectiles;
    public int defaultNumberOfProjectiles;
    public float radiusOfAttack;
    public float defaultRadiusOfAttack;

    public WeaponStats(
        float damage, float defaultDamage,
        float timeBetweenAtacks, float defaultTimeBetweenAtacks,
        int numberOfProjectiles, int defaultNumberOfProjectiles,
        float radiusOfAttack, float defaultRadiusOfAttack
        )
    {
        this.damage = damage;
        this.defaultDamage = defaultDamage;
        this.timeBetweenAtacks = timeBetweenAtacks;
        this.defaultTimeBetweenAtacks = defaultTimeBetweenAtacks;
        this.numberOfProjectiles = numberOfProjectiles;
        this.defaultNumberOfProjectiles = defaultNumberOfProjectiles;
        this.radiusOfAttack = radiusOfAttack;
        this.defaultRadiusOfAttack = defaultRadiusOfAttack;
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public WeaponStats weaponStats;
    public GameObject weaponPrimaryPrefab;

    public void SetDefaultStats()
    {
        weaponStats.damage = weaponStats.defaultDamage;
        weaponStats.timeBetweenAtacks = weaponStats.defaultTimeBetweenAtacks;
        weaponStats.numberOfProjectiles = weaponStats.defaultNumberOfProjectiles;
        weaponStats.radiusOfAttack = weaponStats.defaultRadiusOfAttack;
    }
}
