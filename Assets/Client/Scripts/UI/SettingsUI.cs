using UnityEngine;
using UnityEngine.UIElements;

public class SettingsUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _settingsAsset;
    [SerializeField] private MainSettingsUI _mainSettingsUI;
    [SerializeField] private Menu _menu;

    private VisualElement _settings;

    protected override void Initialize()
    {
        _settings = _settingsAsset.CloneTree();
    }

    public void Open()
    {
        ResetContainer(_settings);
        Button mainSettings = _container.Q<Button>("mainSettings");
        Button back = _container.Q<Button>("Back");

        mainSettings.clicked += _mainSettingsUI.Open;
        back.clicked += _menu.OpenMenu;
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}