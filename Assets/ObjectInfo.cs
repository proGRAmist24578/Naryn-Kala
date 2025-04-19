using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ObjectInfo : MonoBehaviour
{
    public Image objectImage;
    public TextMeshProUGUI objectDescription;
    public Sprite objectSprite;
    public string description;

    public void ShowInfo()
    {
        Debug.Log("Показ информации об объекте: " + description + ", Изображение: " + objectSprite.name);
        if (objectImage != null && objectDescription != null)
        {
            objectImage.sprite = objectSprite;
            objectDescription.text = description;

            objectImage.gameObject.SetActive(true);
            objectDescription.gameObject.SetActive(true);
        }
    }

    public void HideInfo()
    {
        if (objectImage != null && objectDescription != null)
        {
            objectImage.gameObject.SetActive(false);
            objectDescription.gameObject.SetActive(false);
        }
    }

    
}
