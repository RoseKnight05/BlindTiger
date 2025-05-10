using UnityEngine;

[RequireComponent(typeof(AIBotChase))]
public class AIAttack : MonoBehaviour
{
    private AIBotChase bot; // Reference to the AI bot chasing script
    private Pistol pistol;  // Reference to the Pistol component
    public Transform playerTarget; // Reference to the player (or player transform)

    private void Start()
    {
        bot = GetComponent<AIBotChase>();
        playerTarget = PlayerController.instance.transform;

        // Dynamically create the pistol GameObject and add the Pistol component
        GameObject pistolObject = new GameObject("Pistol"); // Create a new GameObject for the pistol
        pistol = pistolObject.AddComponent<Pistol>(); // Add the Pistol script to the new GameObject

        // Optionally set pistol values (you can adjust these to your needs)
        pistol.range = 100f;
        pistol.damage = 25f;
        pistol.fireRate = 0.5f;
    }

    private void Update()
    {
        // Calculate the distance to the player (or target)
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        // If the bot is within range of the player, it will shoot at them
        if (distanceToPlayer <= pistol.range)
        {
            // Make the bot look at the player
            Vector3 direction = (playerTarget.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction); // Rotate the bot towards the player

            // Shoot at the player
            pistol.ShootAtTarget(playerTarget);
        }
    }
}
