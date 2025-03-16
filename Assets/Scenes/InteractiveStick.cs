using UnityEngine;

public class InteractiveStick : MonoBehaviour
{
    [TextArea]
    public string artifactDescription;

    public string GetArtifactInfo()
    {
        return artifactDescription;
    }
}