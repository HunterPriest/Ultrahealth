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
        _currentMapElement = _currentMap.asset.CloneTree();
    }

    public void ShowMap()
    {
        ResetContainer(_mapInGame);

        VisualElement ForMap = _container.Q<VisualElement>("ForMap");
        ForMap.Add(_currentMapElement);
        Label name = _container.Q<Label>("Name");
        Label Text = _container.Q<Label>("Text");

        name.text = _currentMap.nameOrganism;
        for (int i = 0; i > _currentMap.points; i++)
        {
            Button point = _container.Q<Button>((i + 1).ToString());
            point.clicked += (() =>
            {
                name.text = _currentMap.pointsText[i];
                Text.text = _currentMap.moreInfo[i];
            });
        }
    }

    public void Close()
    {
        _container.Clear();
    }
}
