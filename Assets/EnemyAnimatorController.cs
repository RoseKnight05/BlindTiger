using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour
{
    private Animator animator;

    // Reference to your Animator Controller asset (Assign this in the Unity Editor)
    [SerializeField] private RuntimeAnimatorController enemyAnimatorController;

    void Awake()
    {
        // Get the Animator component on the GameObject
        animator = GetComponent<Animator>();

        // Check if the animator and controller are assigned
        if (animator != null && enemyAnimatorController != null)
        {
            // Set the Animator Controller for this Animator
            animator.runtimeAnimatorController = enemyAnimatorController;
        }
        else
        {
            Debug.LogError("Animator or Animator Controller is not assigned!");
        }
    }

    // Example of controlling the animation state based on conditions
    void Update()
    {
        if (animator != null)
        {
            // Example input-based conditions to control the animation
            bool isWalking = Input.GetKey(KeyCode.W); // Check if the 'W' key is pressed
            animator.SetBool("IsWalking", isWalking); // Update the walking animation parameter
        }
    }
}
