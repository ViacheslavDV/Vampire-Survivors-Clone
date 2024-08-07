using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponContainer;
    [SerializeField] WeaponData startingWeapon;

    private void Start()
    {
        AddWeaponToContainer(startingWeapon);
    }

    public void AddWeaponToContainer(WeaponData weaponData)
    {
        GameObject weaponInstance = Instantiate(weaponData.weaponPrimaryPrefab, weaponContainer);
        weaponInstance.GetComponent<WeaponBase>().SetData(weaponData);
    }
}
