using UnityEngine;

[CreateAssetMenu(fileName = "New Artifact", menuName = "Artifacts/Artifact")]
public class ArtifactData : ScriptableObject
{
    public string artifactName;
    [TextArea] public string description;
    public Sprite image;
}
