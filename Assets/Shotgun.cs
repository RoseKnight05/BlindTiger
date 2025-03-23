using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Camera playerCamera;  // Reference to the player's camera
    public float range = 50f;    // Max distance the pellets can travel
    public float damage = 15f;   // Damage each pellet does
    public int pelletCount = 8;  // Number of pellets fired in one shot
    public float spreadAngle = 10f; // Angle of spread for pellets
    public float fireRate = 1f;  // Time between shots (fire rate)
    private float nextTimeToFire = 0f; // Time when you can shoot next

    void Update()
    {
        // Check if Fire1 button is pressed (usually left mouse button)
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate; // Apply fire rate cooldown
            Shoot(); // Call the Shoot method
        }
    }

    void Shoot()
    {
        for (int i = 0; i < pelletCount; i++)
        {
            // Generate random direction within spread angle for each pellet
            Vector3 spreadDirection = playerCamera.transform.forward;
            spreadDirection.x += Random.Range(-spreadAngle, spreadAngle) * 0.01f;
            spreadDirection.y += Random.Range(-spreadAngle, spreadAngle) * 0.01f;
            spreadDirection.Normalize();

            RaycastHit hit;
            // Perform a raycast for each pellet
            if (Physics.Raycast(playerCamera.transform.position, spreadDirection, out hit, range))
            {
                Debug.Log("Hit " + hit.transform.name); // Log hit object

                // Check if the hit object has a 'Target' component
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage); // Apply damage to the target
                }
            }
        }
    }
}
