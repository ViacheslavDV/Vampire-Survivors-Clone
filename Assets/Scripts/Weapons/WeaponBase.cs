using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;
    public WeaponStats weaponStats;
    private float timer;

    protected virtual void Start()
    {
        if (weaponData != null)
        {
            weaponData.SetDefaultStats();
        }
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack(weaponData.weaponStats.numberOfProjectiles);
            timer = weaponData.weaponStats.timeBetweenAtacks;
        }
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        weaponStats = new WeaponStats(
            wd.weaponStats.damage, wd.weaponStats.defaultDamage,
            wd.weaponStats.timeBetweenAtacks, wd.weaponStats.defaultTimeBetweenAtacks,
            wd.weaponStats.numberOfProjectiles, wd.weaponStats.defaultNumberOfProjectiles,
            wd.weaponStats.radiusOfAttack, wd.weaponStats.defaultRadiusOfAttack
            );
    }
    public abstract void Attack(int numberOfProjectiles);
}
