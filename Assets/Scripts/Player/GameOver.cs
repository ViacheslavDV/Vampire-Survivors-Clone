using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winGameScreen;
    [SerializeField] GameObject playerWeapons;
    [SerializeField] List<WeaponData> weaponDataList;
    public void FinishGameUponPlayersDeath()
    {
        GetComponent<PlayerMovement>().enabled = false;
        ResetStats();
        playerWeapons.SetActive(false);
        if(AudioManager.Instance != null) AudioManager.Instance.StopAudio(0);
        gameOverScreen.SetActive(true);
    }

    public void TriggerWinGame()
    {
        GetComponent<PlayerMovement>().enabled = false;
        ResetStats();
        playerWeapons.SetActive(false);
        if (AudioManager.Instance != null) AudioManager.Instance.StopAudio(0);
        winGameScreen.SetActive(true);
    }

    private void ResetStats()
    {
        foreach (var weapon in weaponDataList)
        {
            weapon.SetDefaultStats();
        }
    }
}
