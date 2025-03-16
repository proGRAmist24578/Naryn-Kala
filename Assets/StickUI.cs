using UnityEngine;
using TMPro;

public class StickUI : MonoBehaviour
{
    public GameObject artifactInfoPanel;
    public TextMeshProUGUI artifactText;
    

    private void Start()
    {
        StickInteraction.OnStickClicked += ShowInfo;
        artifactInfoPanel.SetActive(false);
    }

    private void ShowInfo(InteractiveStick stick)
    {
        artifactInfoPanel.SetActive(true);

        if (stick != null) // Проверяем, что артефакт передан
        {
            string info = stick.GetArtifactInfo();
        
            if (!string.IsNullOrEmpty(info)) // Проверяем, что текст не пустой
            {
                artifactText.text = info;
            }
            else
            {
                artifactText.text = "Информация об артефакте отсутствует.";
            }
        }
        else
        {
            artifactText.text = "Ошибка: объект не найден.";
        }
    }
    
    public void HideInfo()
    {
        artifactInfoPanel.SetActive(false);
    }
}