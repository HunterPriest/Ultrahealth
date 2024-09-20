using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class MapInGame : UIToolkitBasicElement
{
    [SerializeField] private VisualTreeAsset _mapInGameAsset;
    [SerializeField] private MapConfiguration _currentMap;

    private VisualElement _mapInGame;

    private VisualElement _currentMapElement;
    private VisualElement _forMap;
    private Button _back;
    private Label _name;
    private Label _text;

    private GameUI _gameUI;

    [Inject]
    private void Construct(GameUI gameUI)
    {
        _gameUI = gameUI;
    }

    protected override void Initialize()
    {
        _mapInGame = _mapInGameAsset.CloneTree();

        _currentMapElement = _currentMap.asset.CloneTree();
        _forMap = _mapInGame.Q<VisualElement>("ForMap");
        _forMap.Add(_currentMapElement);

        _back = _mapInGame.Q<Button>("Back");
        _name = _mapInGame.Q<Label>("Name");
        _text = _mapInGame.Q<Label>("Text");

        _name.text = _currentMap.nameOrganism;
        _back.clicked += () =>
        {
            _name.text = null;
            _text.text = null;
            _gameUI.CloseMap();
        };

        for (int i = 0; i < _currentMap.pointsText.Length; i++)
        {
            Button point = _mapInGame.Q<Button>((i + 1).ToString());
            BindButton(point, i);
        }
    }

    public void ShowMap()
    {
        ResetContainer(_mapInGame);
    }

    private void BindButton(Button point, int index)
    {
        point.clicked += (() =>
        {
            _name.text = _currentMap.pointsText[index];
            _text.text = _currentMap.moreInfo[index];
        });
    }
}
