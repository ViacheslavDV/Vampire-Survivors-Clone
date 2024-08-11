using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins;
    private const int shufflePrice = 50;
    [SerializeField] TMPro.TextMeshProUGUI coinAmountText;
    public void AddCoins(int coinAmount)
    {
        totalCoins += coinAmount;
        coinAmountText.text = "Coins: " + totalCoins.ToString();
    }

    public bool CanPurchaseShuffle()
    {
        if (totalCoins >= shufflePrice)
        {
            totalCoins -= shufflePrice;
            coinAmountText.text = "Coins: " + totalCoins.ToString();
            return true;
        }
        else return false;
    }
}
