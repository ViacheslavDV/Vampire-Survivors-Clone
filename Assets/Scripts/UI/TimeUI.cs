using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    TextMeshProUGUI timer;

    private void Awake()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTime(float currentTime)
    {
        int minutes = (int)(currentTime / 60f);
        int seconds = (int)(currentTime % 60f);

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
