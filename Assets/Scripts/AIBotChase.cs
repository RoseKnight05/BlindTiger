using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]
public class AIBotChase : MonoBehaviour
{
    private Transform player;
    public float chaseRange = 10f;  // The distance within which the AI starts chasing
    public float stopRange = 2f;    // The distance at which the AI stops chasing the player

    private NavMeshAgent agent;
    public float DistanceToPlayer { get { return Vector3.Distance(transform.position, player.position); } }


    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        player = PlayerController.instance.transform;
        Assert.IsNotNull(player, "Player reference must not be null.");

        animator = GetComponent<Animator>();
        Assert.IsNotNull(animator, "Animator must not be null.");
    }

    void Update()
    {
        float distance = DistanceToPlayer;

        if (distance <= chaseRange && distance > stopRange)
        {
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            agent.SetDestination(transform.position);
            animator.SetBool("IsWalking", false);
        }
    }
}
