using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;  // Enemy's health
    private string lastWeapon;   // Track which weapon last hit the enemy
    public KillCounter killCounter; // Reference to the KillCounter script

    // Method to reduce health when the enemy is hit by a weapon
    public void TakeDamage(float damage, string weaponName)
    {
        // Print a debug message showing which weapon hit the enemy
        Debug.Log(gameObject.name + " took " + damage + " damage. Remaining health: " + health);

        health -= damage;

        // Clamp health to not go below 0
        if (health < 0)
        {
            health = 0;
        }

        // Check if health is less than or equal to 0 and destroy the enemy
        if (health <= 0)
        {
            Die();  // Call the Die method when the enemy's health reaches 0
        }
    }

    // Method to handle enemy death
    private void Die()
    {
        // Print a debug message when the enemy dies
        Debug.Log(gameObject.name + " has died!");

        // Increment the kill count when the enemy dies
        if (killCounter != null)
        {
            killCounter.IncrementKillCount();  // Call the IncrementKillCount method in KillCounter
        }
        else
        {
            Debug.Log("KillCounter is not assigned to the enemy!");  // Ensure killCounter is assigned
        }

        // Destroy the enemy object (or handle death differently)
        Destroy(gameObject);
    }
}
