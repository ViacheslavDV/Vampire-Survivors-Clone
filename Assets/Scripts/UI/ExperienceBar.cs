using UnityEngine;
using UnityEngine.UI;


public class ExperienceBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void UpdateExpirienceSlider(int currentExp, int targetExp)
    {
        slider.maxValue = targetExp;
        slider.value = currentExp;
    }

    public void SetLevelText(int currentLevel)
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }
}
