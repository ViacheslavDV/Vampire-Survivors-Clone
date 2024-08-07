using UnityEngine;

public class ObtainCoinObject : MonoBehaviour, IObtainable
{
    [SerializeField] private int coinAmount = 5;
    public void ObtainItem(Character character)
    {
        character.coinManager.AddCoins(coinAmount);
    }
}
