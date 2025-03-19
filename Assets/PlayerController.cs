using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float speed = 5.0f;
    private float gravity = -9.81f;
    private float jumpHeight = 2.0f;
    [HideInInspector] public new Camera camera;
    private RaycastHit[] interactionHits = new RaycastHit[1];
    [SerializeField] private float maxInteractionDistance = 20.0f;
    [SerializeField] private int interactablesLayerMask = 1 << 3;

    public GunController gunController;

    public static PlayerController instance { get; private set; }

    void Start()
    {
        instance = this;
        camera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateInteraction();
        UpdateMovement();
    }

    private void UpdateInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int d = 
                Physics.RaycastNonAlloc(new Ray(camera.transform.position, camera.transform.rotation * camera.transform.forward), interactionHits, maxInteractionDistance, interactablesLayerMask, QueryTriggerInteraction.Collide);
            
            if (d == 0 || !interactionHits[0].transform.gameObject.TryGetInterface<IInteractable>(out IInteractable interactable)) return; // no interactables found

            interactable.Interact();
        }
    }

    private void UpdateMovement()
    {
        // Ground check
        isGrounded = controller.isGrounded;

        // Reset vertical velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Small downward force to keep grounded
        }

        // Reset horizontal velocity (important for stopping drift)
        velocity.x = 0f;
        velocity.z = 0f;

        // Get raw input for horizontal and vertical movement
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxisRaw("Vertical");    // W/S or Up/Down arrow keys

        // Apply movement using raw input
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement to the controller with respect to speed and frame time
        controller.Move(move * speed * Time.deltaTime);

        // Jumping: apply jump force when pressing the jump button and when grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // Jump force calculation
        }

        // Apply gravity when not grounded
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Apply vertical movement (gravity + jumping) to the controller
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(camera.transform.position, camera.transform.rotation * camera.transform.forward * maxInteractionDistance);
    }
}
