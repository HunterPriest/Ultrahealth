using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameplayUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _gameplayUIAsset;

    private VisualElement _gameplayUI;

    protected override void Initialize()
    {
        _gameplayUI = _gameplayUIAsset.CloneTree();
    }

    public void Open()
    {
        ResetContainer(_gameplayUI);
    }

    public void Close()
    {
        _container.Clear();
    }
}