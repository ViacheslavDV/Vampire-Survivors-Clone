using UnityEngine;

public class StatusBar : MonoBehaviour
{
    [SerializeField] Transform bar;

    public void SetState(float currentValue, float maxValue)
    {
        currentValue /= maxValue;
        if (currentValue < 0f) currentValue = 0f;
        bar.transform.localScale = new Vector2(currentValue, 0.1f); 
    }
}
