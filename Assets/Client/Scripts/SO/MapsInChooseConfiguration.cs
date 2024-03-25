using UnityEngine;

[CreateAssetMenu(fileName = "MapChooseConfiguration", menuName = "SO/NewChooseMap")]

public class MapsInChooseConfiguration : ScriptableObject
{
    public Texture2D texture;
    public string[] bolezni;
    public string startPointText;
    public string finishPointText;
}
