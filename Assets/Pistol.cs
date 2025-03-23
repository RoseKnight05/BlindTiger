using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float range = 100f; // Max distance the shot will travel
    public float damage = 25f; // Amount of damage each shot does
    public float fireRate = 0.5f; // Time between shots (in seconds)
    private float nextTimeToFire = 0f; // Time when you can shoot next

    public void ShootAtTarget(Transform target)
    {
        // Check if it's time to fire (based on fire rate)
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate; // Apply the fire rate cooldown

            RaycastHit hit;

            // Perform a raycast from the pistol towards the player or target
            if (Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit, range))
            {
                Debug.Log("Hit " + hit.transform.name); // Debug the name of the hit object

                // Check if the hit object has a 'Target' component (e.g., enemy or player)
                if (hit.transform.CompareTag("Player")) // You can change "Player" tag to fit your setup
                {
                    Target targetScript = hit.transform.GetComponent<Target>();
                    if (targetScript != null)
                    {
                        targetScript.TakeDamage(damage); // Apply damage to the target
                        Debug.Log("Target hit and damage applied.");
                    }
                }
            }
            else
            {
                Debug.Log("No hit detected.");
            }
        }
    }
}
