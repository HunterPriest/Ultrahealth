using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class MapManager : UIToolkitManager
{
    [Inject] private GameMachine _gameMachine;

    [SerializeField] private VisualTreeAsset _firstMapAsset;

    private VisualElement _firstMap;
    private VisualElement _Map;

    protected override void Initialize()
    {
        _firstMap = _firstMapAsset.CloneTree();
    }

    private void OpenMap()
    {
        ResetContainer(_firstMap);

        _Map = _container.Q<VisualElement>("Map");
        _Map.visible = false;

        Button Organ1 = _container.Q<Button>("Organ1");

        Organ1.clicked += () => OpenOrganMap();
    }

    private void OpenOrganMap()
    {
        _Map.visible = false;
        Button start = _container.Q<Button>("Start");

        start.clicked += () => _gameMachine.LoadGame();
        _Map.visible = true;
    }
    private void CloseOrganMap()
    {
        _Map.visible = false;
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}
