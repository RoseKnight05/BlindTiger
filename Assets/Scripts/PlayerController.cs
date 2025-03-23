using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }

    [HideInInspector] public new Camera camera;
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
            int d = 
                Physics.RaycastNonAlloc(new Ray(camera.transform.position, camera.transform.forward), interactionHits, maxInteractionDistance, interactablesLayerMask, QueryTriggerInteraction.Collide);
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

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * walkSpeed * (isSprinting ? sprintFactor : 1) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity when not grounded
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Apply vertical movement (gravity + jumping) to the controller
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
