using UnityEngine;

public enum UpgradeType
{
    Health,
    HealthRegeneration,
    MoveSpeed,
    WeaponUnlock,
    WeaponUpgrade
}

[CreateAssetMenu]
public class Upgrade : ScriptableObject 
{
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeIcon;
    public UpgradeType upgradeType;
    public float newAmplification;
    public float newAtackSpeed;
    public float newAttackRadius;
    public int newNumberOfProjectiles;
    public WeaponData weaponData;
    public Upgrade prerequiredUpgrade;
}
