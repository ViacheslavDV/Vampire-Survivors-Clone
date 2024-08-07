using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject levelUpMenu;
    [SerializeField] GameObject upgradeButtonPrefab;
    [SerializeField] List<ApplyUpgradeButton> applyUpgradeButtons;
    PauseManager pauseManager;

    private ExperienceManager experienceManager;

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    public void ShowUpgradeOptions(List<Upgrade> upgrades, ExperienceManager experienceManager)
    {
        this.experienceManager = experienceManager;
        for (int i = 0; i < upgrades.Count; i++)
        {
            applyUpgradeButtons[i].SetData(upgrades[i]);
        }
        if (upgrades.Count <= 2) applyUpgradeButtons[2].SetData(upgrades[0]);
        if (upgrades.Count <= 1) applyUpgradeButtons[1].SetData(upgrades[0]);
        OpenLevelUpMenu();
    }

    public void OpenLevelUpMenu() 
    {
        pauseManager.PauseGame();
        levelUpMenu.SetActive(true);
    }

    public void CloseLevelUpMenu()
    {
        levelUpMenu.SetActive(false);
        pauseManager.UnPauseGame();
    }

    public void SetUpgrade(int buttonId)
    {
        GameManager.instance.playerTransform.
            GetComponent<ExperienceManager>().ApplyUpgrade(buttonId);

        CloseLevelUpMenu();
    }
}
