using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ArtifactUIManager artifactUIManager;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movementInput;
    private Rigidbody2D rb;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction exitAction;
    private bool isNearArtifact = false;
    private GameObject currentArtifact;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interactive"];
        exitAction = playerInput.actions["Exit"];
    }

    private void OnEnable()
    {
        interactAction.performed += OnInteract;
        exitAction.performed += OnExit;
    }

    private void OnDisable()
    {
        interactAction.performed -= OnInteract;
        exitAction.performed -= OnExit;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artifact"))
        {
            isNearArtifact = true;
            currentArtifact = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Artifact"))
        {
            isNearArtifact = false;
            currentArtifact = null;
        }
    }

    private void Update()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (isNearArtifact && currentArtifact != null)
        {
            var artifact = currentArtifact.GetComponent<Artifact>();
            if (artifact != null)
            {
                artifactUIManager.ShowArtifact(artifact.data);
            }
        }
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        artifactUIManager.HidePanel();
    }
}
