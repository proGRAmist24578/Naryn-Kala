using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtifactUIManager : MonoBehaviour
{
    public GameObject panel;
    public Image artifactImage;
    public TMP_Text artifactTitle;
    public TMP_Text artifactDescription;

    public void ShowArtifact(ArtifactData data)
    {
        panel.SetActive(true);
        artifactImage.sprite = data.image;
        artifactTitle.text = data.artifactName;
        artifactDescription.text = data.description;
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
