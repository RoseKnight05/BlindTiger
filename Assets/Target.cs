using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f; // Starting health of the enemy

    // Method to apply damage
    public void TakeDamage(float damage)
    {
        health -= damage; // Reduce health by damage amount
        Debug.Log(gameObject.name + " took " + damage + " damage. Remaining health: " + health);

        // If health is zero or less, call Die
        if (health <= 0)
        {
            Die();
        }
    }

    // Handle death behavior (destroy the object when health reaches zero)
    void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject); // Destroy the target
    }
}
