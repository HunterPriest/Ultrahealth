using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "MapConfiguration", menuName = "SO/NewMapConfiguration")]

public class MapConfiguration : ScriptableObject
{
    public VisualTreeAsset asset;
    public string[] pointsText;
    public string[] moreInfo;
    public string nameOrganism;
    public int points;
}
