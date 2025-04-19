using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ObjectInfo[] objectInfos; // массив всех объектов, которые могут отображать информацию

    public void HideAllUIElements()
    {
        foreach (ObjectInfo info in objectInfos)
        {
            info.HideInfo();
        }
    }

}
