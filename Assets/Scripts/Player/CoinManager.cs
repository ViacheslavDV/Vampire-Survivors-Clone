using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins;
    [SerializeField] TMPro.TextMeshProUGUI coinAmountText;
    public void AddCoins(int coinAmount)
    {
        totalCoins += coinAmount;
        coinAmountText.text = "Coins: " + totalCoins.ToString();
    }
}
