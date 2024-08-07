using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ApplyUpgradeButton : MonoBehaviour
{
    [SerializeField] Image upgradeIcon;
    [SerializeField] TextMeshProUGUI upgradeText;
    [SerializeField] TextMeshProUGUI upgradeDescription;

    public void SetData(Upgrade upgradeData)
    {
        upgradeIcon.sprite = upgradeData.upgradeIcon;
        upgradeText.text = upgradeData.upgradeName;
        upgradeDescription.text = upgradeData.upgradeDescription;
    }
}
