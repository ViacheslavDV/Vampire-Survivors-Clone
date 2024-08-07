using UnityEngine;

public class ObtainHealObject : MonoBehaviour, IObtainable
{
    [SerializeField] private float healAmount = 150f;
    public void ObtainItem(Character character)
    {
        character.Heal(healAmount);
    }
}
