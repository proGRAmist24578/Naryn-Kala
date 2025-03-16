using UnityEngine;

public class StickHighlight : MonoBehaviour
{
    private Vector3 originalScale;
    public float highlightScale = 1.1f;
    public Color highlightColor = Color.yellow;
    
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        transform.localScale = originalScale * highlightScale;
        spriteRenderer.color = highlightColor;
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
        spriteRenderer.color = Color.white;
    }
}