using UnityEngine;
using UnityEngine.UIElements;

public class SettingsUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _settingsAsset;
    [SerializeField] private MainSettingsUI _mainSettingsUI;
    [SerializeField] private Menu _menu;
    [SerializeField] private Pause _pause;

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
        VisualElement setSettingsPanels = _container.Q<VisualElement>("SetSettings");

        mainSettings.clicked += () => _mainSettingsUI.Open(setSettingsPanels);
        back.clicked += () =>
        {
            if(_menu != null)
            {
                _menu.OpenMenu();
            }
            else if(_pause != null)
            {
                _pause.OpenPause();
            }
        };
    }
}