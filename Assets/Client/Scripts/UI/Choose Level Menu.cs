using UnityEngine;
using UnityEngine.UIElements;

public class ChooseLevelMenu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseLevelsAsset;

    private VisualElement _chooseLevel;
    private VisualElement _Map;

    protected override void Initialize()
    {
        _chooseLevel = _chooseLevelsAsset.CloneTree();
    }

    public void OpenChooseLevelMenu()
    {
        ResetContainer(_chooseLevel);

        _Map = _container.Q<VisualElement>("Map");
        _Map.visible = false;

        Button Organ1 = _container.Q<Button>("Organ1");

        Organ1.clicked += () => OpenOrganMap();
    }

    private void OpenOrganMap()
    {
        _Map.visible = false;
        Button start = _container.Q<Button>("Start");

        start.clicked += () => _gameMachine.LoadLevel(1);
        _Map.visible = true;
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}
