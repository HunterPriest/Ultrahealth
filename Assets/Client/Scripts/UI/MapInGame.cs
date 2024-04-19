using UnityEngine;
using UnityEngine.UIElements;

public class MapInGame : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _MapInGameAsset;
    [SerializeField] private MapConfiguration _currentMap;

    private VisualElement _mapInGame;
    private VisualElement _currentMapElement;
    protected override void Initialize()
    {
        _mapInGame = _MapInGameAsset.CloneTree();
        _currentMapElement = _currentMap._asset.CloneTree();
    }

    public void ShowMap()
    {
        ResetContainer(_mapInGame);

        VisualElement ForMap = _container.Q<VisualElement>("ForMap");
        ForMap.Add(_currentMapElement);
        Button[] points = new Button[_currentMap._points];
        Label name = _container.Q<Label>("Name");
        Label Text = _container.Q<Label>("Text");

        name.text = _currentMap._name;
        for (int i = 0; i > _currentMap._points; i++)
        {
            points[i] = _container.Q<Button>("Point" + (i + 1).ToString());
            points[i].clicked += (() =>
            {
                name.text = _currentMap._pointsText[i];
                Text.text = _currentMap._moreInfo[i];
            });
        }
    }
}
