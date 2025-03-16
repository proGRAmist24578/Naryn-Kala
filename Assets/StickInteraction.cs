using UnityEngine;
using UnityEngine.InputSystem;

public class StickInteraction : MonoBehaviour
{
    public delegate void StickEvent(InteractiveStick stick);
    public static event StickEvent OnStickClicked;
    
    private void OnMouseDown() // Для ПК
    {
        OnStickClicked?.Invoke(GetComponent<InteractiveStick>());
    }

    private void OnPointerClick(InputAction.CallbackContext context) // Для новой системы ввода
    {
        if (Pointer.current == null) return;

        Vector2 screenPosition = Pointer.current.position.ReadValue();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            OnStickClicked?.Invoke(GetComponent<InteractiveStick>());
        }
    }
}