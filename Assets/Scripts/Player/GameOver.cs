using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    [SerializeField] GameObject playerWeapons;
    [SerializeField] List<WeaponData> weaponDataList;
    public void FinishGameUponPlayersDeath()
    {
        GetComponent<PlayerMovement>().enabled = false;
        ResetStats();
        playerWeapons.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
    }

    private void ResetStats()
    {
        foreach (var weapon in weaponDataList)
        {
            weapon.SetDefaultStats();
        }
    }
}
