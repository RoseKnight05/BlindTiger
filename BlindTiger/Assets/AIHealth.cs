using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public float health = 100f;  // AI's starting health

    // This function is called to apply damage to the AI
    public void TakeDamage(float damage)
    {
        health -= damage;  // Subtract the damage from health

        if (health <= 0f)
        {
            Die();  // If health is less than or equal to 0, call Die()
        }
    }

    // This function handles AI death
    void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        
        // Here you can add more logic for what happens when the AI dies, 
        // such as playing an animation, destroying the object, etc.
        Destroy(gameObject);  // Example: Destroy the AI GameObject
    }
}
