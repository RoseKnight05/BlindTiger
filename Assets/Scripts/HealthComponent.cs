using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float health = 100f;  // AI's starting health
    public event Action onDiedEvent;
    public bool destroyOnDeath = true;

    public void TakeDamage(float damage)
    {
        health -= damage;  // Subtract the damage from health

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died.");

        onDiedEvent?.Invoke();
        
        if (destroyOnDeath)
            Destroy(gameObject);
    }
}
