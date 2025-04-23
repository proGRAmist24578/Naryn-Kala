using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movementInput;
    private Rigidbody2D rb;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction exitAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        interactAction = playerInput.actions["Interact"];
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
        // Тут можно делать Raycast или проверку триггера
        Debug.Log("Interact pressed!");
        // Пример: открыть UI с информацией об артефакте
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        Debug.Log("Exit pressed!");
        // Пример: закрыть UI с информацией
    }
}
