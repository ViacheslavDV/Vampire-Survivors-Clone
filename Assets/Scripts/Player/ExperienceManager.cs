using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    private int characterLevel = 1;
    private int experience;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanelManager;
    [SerializeField] List<Upgrade> upgradeList;
    public List<Upgrade> currentUpgrades = new();
    private List<Upgrade> availableUpgrades = new();

    WeaponManager weaponManager;
    PlayerMovement playerMovement;
    Character character;

    private int requiredExperienceToLevelUp 
    {
        get { return 120 * characterLevel; }
    }

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        playerMovement = GetComponent<PlayerMovement>();
        character = GetComponent<Character>();
    }

    private void Start()
    {
        experienceBar.UpdateExpirienceSlider(experience, requiredExperienceToLevelUp);
        experienceBar.SetLevelText(characterLevel);
    }

    public void AddExperience(int experienceAmount)
    {
        experience += experienceAmount;
        IncreaseLevel();
        experienceBar.UpdateExpirienceSlider(experience, requiredExperienceToLevelUp);
    }

    private void IncreaseLevel()
    {
        if (experience >= requiredExperienceToLevelUp)
        {
            experience -= requiredExperienceToLevelUp;
            characterLevel += 1;
            experienceBar.SetLevelText(characterLevel);
 
            OpenLevelUpMenu();
        }
    }

    private void OpenLevelUpMenu()
    {
        availableUpgrades.Clear();

        System.Random random = new System.Random();
        availableUpgrades = upgradeList
            .Where(upgrade => CanApplyUpgrade(upgrade) && !currentUpgrades.Contains(upgrade))
            .OrderBy(upgrade => random.Next())
            .Take(3)
            .ToList();

        if (availableUpgrades.Count == 0) return;
        upgradePanelManager.ShowUpgradeOptions(availableUpgrades, this);
    }

    public void ApplyUpgrade(int upgradeId) 
    {
        if(upgradeId >= availableUpgrades.Count) upgradeId = 0;
        Upgrade upgradeToBeApplied = availableUpgrades[upgradeId];
        upgradeList.Remove(upgradeToBeApplied);
        availableUpgrades.Clear();

        switch (upgradeToBeApplied.upgradeType)
        {
            case UpgradeType.Health:
                {
                    character.IncreaseMaxHp(upgradeToBeApplied.newAmplification);
                } break;
            case UpgradeType.HealthRegeneration:
                {
                    character.healthRegenerationAmount = upgradeToBeApplied.newAmplification;
                } break;
            case UpgradeType.MoveSpeed:
                {
                    playerMovement.IncreaseMoveSpeed(upgradeToBeApplied.newAmplification);
                } break;
            case UpgradeType.WeaponUnlock:
                {
                    weaponManager.AddWeaponToContainer(upgradeToBeApplied.weaponData);
                } break;
            case UpgradeType.WeaponUpgrade:
                {
                    upgradeToBeApplied.weaponData.weaponStats.damage = upgradeToBeApplied.newAmplification;
                    upgradeToBeApplied.weaponData.weaponStats.timeBetweenAtacks = upgradeToBeApplied.newAtackSpeed;
                    upgradeToBeApplied.weaponData.weaponStats.numberOfProjectiles = upgradeToBeApplied.newNumberOfProjectiles;
                    upgradeToBeApplied.weaponData.weaponStats.radiusOfAttack = upgradeToBeApplied.newAttackRadius;
                }
                break;
        }    
        currentUpgrades.Add(upgradeToBeApplied);
    }

    private bool CanApplyUpgrade(Upgrade upgrade)
    {
        if (upgrade.prerequiredUpgrade == null) return true;

        return currentUpgrades.Contains(upgrade.prerequiredUpgrade);
    }
}
