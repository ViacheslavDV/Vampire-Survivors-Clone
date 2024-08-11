using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class EnemyStats
{
    public float hp;
    public float damage;
    public float speed;
    public int experienceReward;
    public bool isBoss; 
}

public class Enemy : MonoBehaviour, IDamagable
{
    private static Transform targetDestination;
    private static Character targetCharacter;
    private static GameObject targetObject;
    private Rigidbody2D rb;
    public EnemyStats enemyStats;

    private const float moveUpdateInterval = 0.333f;
    private const float respawnCheckInterval = 2f;
    private const float edgeDistanceToTriggerRespawn = 32f;
    private const float respawnDistance = 16f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(MoveTowardsTargetCoroutine());
    }

    public void SetTarget(GameObject target)
    {
        targetObject = target;
        targetDestination = target.transform;
    }

    private IEnumerator MoveTowardsTargetCoroutine()
    {
        while (targetDestination != null)
        {
            Vector2 direction = (targetDestination.position - transform.position).normalized;
            rb.velocity = direction * enemyStats.speed;

            yield return new WaitForSeconds(moveUpdateInterval);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(enemyStats.damage);
    }

    public void TakeDamage(float damage)
    {
        enemyStats.hp -= damage;
        if (enemyStats.hp <= 0)
        {
            gameObject.SetActive(false);
            targetObject.GetComponent<ExperienceManager>().AddExperience(enemyStats.experienceReward);
        }
    }

    public void SetStats(EnemyStats enemyData)
    {
        enemyStats.hp = enemyData.hp;
        enemyStats.damage = enemyData.damage;
        enemyStats.speed = enemyData.speed;
        enemyStats.experienceReward = enemyData.experienceReward;
    }
}