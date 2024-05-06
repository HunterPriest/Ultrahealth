using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class MapInGame : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _MapInGameAsset;
    [SerializeField] private MapConfiguration _currentMap;

    private VisualElement _mapInGame;
    private VisualElement _currentMapElement;

    private GameUI _gameUI;

    [Inject]
    private void Construct(GameUI gameUI)
    {
        _gameUI = gameUI;
    }

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

        Button back = _container.Q<Button>("Back");

        Label name = _container.Q<Label>("Name");
        Label Text = _container.Q<Label>("Text");

        Button[] point = new Button[_currentMap.pointsText.Length];

        name.text = _currentMap.nameOrganism;
        back.clicked += () => _gameUI.CloseMap();

        for (int i = 0; i < _currentMap.pointsText.Length; i++)
        {
            point[i] = _container.Q<Button>((i + 1).ToString());
            BindButton(point[i], name, Text, i);
        }
    }

    private void BindButton(Button point, Label name, Label Text, int index)
    {
        point.clicked += (() =>
        {
            name.text = _currentMap.pointsText[index];
            Text.text = _currentMap.moreInfo[index];
        });
    }
}
