using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public float maxHp = 480f;
    public float currentHp = 480f;
    public float healthRegenerationAmount = 0f;
    [SerializeField] StatusBar hpBar;
    [HideInInspector] public ExperienceManager experienceManager;
    [HideInInspector] public CoinManager coinManager;
    private bool isDead = false;

    private void Awake()
    {
        experienceManager = GetComponent<ExperienceManager>();
        coinManager = GetComponent<CoinManager>();
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
        InvokeRepeating(nameof(RegenerateHealth), 1f, 1f);
    }

    public void TakeDamage(float damage)
    {
        if (isDead == true) return;
        currentHp -= damage;
        if (currentHp <= 0) {
            GetComponent<GameOver>().FinishGameUponPlayersDeath();
            isDead = true;
            CancelInvoke(nameof(RegenerateHealth));
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void Heal(float healAmount) 
    {
        if (currentHp <= 0) return;
        currentHp += healAmount;
        if(currentHp > maxHp) currentHp = maxHp;
        hpBar.SetState(currentHp, maxHp);
    }

    public void IncreaseMaxHp(float hpAmount)
    {
        maxHp += hpAmount;
        currentHp += hpAmount;
        hpBar.SetState(currentHp, maxHp);
    }

    private void StopHealthRegen()
    {
        CancelInvoke(nameof(RegenerateHealth)); 
        healthRegenerationAmount = 0f;
    }

    private void RegenerateHealth()
    {
        if (!isDead) Heal(healthRegenerationAmount);
    }
}
