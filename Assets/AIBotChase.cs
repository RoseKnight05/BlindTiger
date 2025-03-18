using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBotChase : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float chaseRange = 10f;  // The distance within which the AI starts chasing
    public float stopRange = 2f;    // The distance at which the AI stops chasing the player

    private NavMeshAgent agent;  // Reference to the NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // Get the NavMeshAgent component
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance to the player
            float distance = Vector3.Distance(transform.position, player.position);

            // Log the distance to the console to see if it's working
            Debug.Log("Distance to player: " + distance);

            if (distance <= chaseRange && distance > stopRange) // Within chase range
            {
                Debug.Log("Chasing the player."); // Debug message when chasing
                agent.SetDestination(player.position);  // Move towards player
            }
            else
            {
                Debug.Log("Stopping chase."); // Debug message when stopping
                agent.SetDestination(transform.position);  // Stop if within stop range
            }
        }
        else
        {
            Debug.LogWarning("Player is not assigned!");  // Warning if player reference is missing
        }
    }
}
