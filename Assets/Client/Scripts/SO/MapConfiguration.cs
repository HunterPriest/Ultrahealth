using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "MapConfiguration", menuName = "SO/NewMapConfiguration")]

public class MapConfiguration : ScriptableObject
{
    public VisualTreeAsset _asset;
    public string[] _pointsText;
    public string[] _moreInfo;
    public string _name;
    public int _points;
}
