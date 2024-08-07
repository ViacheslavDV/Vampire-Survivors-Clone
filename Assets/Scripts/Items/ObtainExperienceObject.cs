using UnityEngine;

public class ObtainExperienceObject : MonoBehaviour, IObtainable
{
    [SerializeField] private int experienceAmount = 50;
    public void ObtainItem(Character character)
    {
        character.experienceManager.AddExperience(experienceAmount);
    }
}
