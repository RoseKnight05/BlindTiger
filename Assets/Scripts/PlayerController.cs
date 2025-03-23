using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }

    [HideInInspector] public Camera camera;
    public GunController gunController;

    [Header("Locomotion")]
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float sprintFactor = 1.25f;
    private bool isSprinting = false;

    [Header("Interaction")]
    private RaycastHit[] interactionHits = new RaycastHit[1];
    [SerializeField] private float maxInteractionDistance = 20.0f;
    [SerializeField] private int interactablesLayerMask = 1 << 3;

    [Header("Other")]
    [SerializeField] private AudioClip onDeathAudio;
    private AudioSource audioSource;
    private HealthComponent healthComponent;

    void Awake()
    {
        instance = this;
        camera = Camera.main;
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        healthComponent = GetComponent<HealthComponent>();
    }

    private void Start()
    {
        healthComponent.onDiedEvent += OnDied;
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
            // Perform raycast
            int hits = Physics.RaycastNonAlloc(
                new Ray(camera.transform.position, camera.transform.rotation * camera.transform.forward),
                interactionHits, maxInteractionDistance, interactablesLayerMask, QueryTriggerInteraction.Collide
            );

            // If no hits, return
            if (hits == 0 || interactionHits[0].transform == null)
                return;

            // Check if the object has an IInteractable component and interact if so
            IInteractable interactable = interactionHits[0].transform.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void UpdateMovement()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        // Reset vertical velocity if grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Small downward force to maintain grounded state
        }

        // Reset horizontal velocity to prevent unwanted drifting
        velocity.x = 0f;
        velocity.z = 0f;

        // Get player input for movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Calculate the movement direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player, adjusting for walk speed and sprinting
        controller.Move(move * walkSpeed * (isSprinting ? sprintFactor : 1) * Time.deltaTime);

        // Jump if the player presses the jump button and is grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity when not grounded
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Apply vertical velocity (gravity or jump) to the character controller
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDied()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(onDeathAudio);
        }
        StartCoroutine(load());

        IEnumerator load()
        {
            int frames = 150;
            for (int i = 0; i < frames; i++)
            {
                Time.timeScale = Mathf.Clamp(Time.timeScale - (1.0f / frames), 0, 1.0f);
                yield return new WaitForEndOfFrame();
            }
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(camera.transform.position, camera.transform.position + camera.transform.rotation * camera.transform.forward * maxInteractionDistance);
    }
}
