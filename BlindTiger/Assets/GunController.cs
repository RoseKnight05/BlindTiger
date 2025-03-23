using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera fpsCam;  // Camera that shoots the raycast
    public float damage = 10f;  // Damage dealt by the gun
    public float range = 100f;  // Range of the raycast (how far the bullet travels)
    public ParticleSystem gunfireEffect;  // Optional: Visual effect when firing
    public AudioClip fireSound;  // Optional: Sound effect when firing

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Detects left mouse button (Mouse0)
        {
            Shoot();  // Calls the Shoot function when the player clicks the mouse
        }
    }

    void Shoot()
    {
        if (gunfireEffect != null)
        {
            gunfireEffect.Play();  // Plays the shooting effect (optional)
        }

        if (fireSound != null)
        {
            AudioSource.PlayClipAtPoint(fireSound, transform.position);  // Plays the firing sound (optional)
        }

        // Raycast logic for shooting
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // If we hit something, check if it's an AI
            AIHealth aiHealth = hit.transform.GetComponent<AIHealth>();
            if (aiHealth != null)
            {
                aiHealth.TakeDamage(damage);  // Apply damage to the AI

                // After taking damage, you can check if the AI is dead
                if (aiHealth.health <= 0f)
                {
                    Debug.Log("AI has died!");
                    // You can handle any post-death behavior here if necessary
                }
            }
        }
    }
}
