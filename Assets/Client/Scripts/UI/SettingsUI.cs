using UnityEngine;
using UnityEngine.UIElements;

public class SettingsUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _settingsAsset;
    [SerializeField] private MainSettingsUI _mainSettingsUI;
    [SerializeField] private Menu _menu;
    [SerializeField] private Pause _pause;

    private VisualElement _settings;
    private VisualElement _setSettingsPanels;

    protected override void Initialize()
    {
        _settings = _settingsAsset.CloneTree();

        Button mainSettings = _settings.Q<Button>("mainSettings");
        Button back = _settings.Q<Button>("Back");
        _setSettingsPanels = _settings.Q<VisualElement>("SetSettings");
        Button save = _settings.Q<Button>("Save");

        save.clicked += () =>
        {
            _mainSettingsUI.Save();
        };

        mainSettings.clicked += () =>
        {
            _mainSettingsUI.Open(_setSettingsPanels);
        };
        back.clicked += () =>
        {
            if (_menu != null)
            {
                _menu.OpenMenu();
            }
            else if (_pause != null)
            {
                _pause.OpenPause();
            }
        };
    }

    public void Open()
    {
        ResetContainer(_settings);

        _mainSettingsUI.Open(_setSettingsPanels);
    }
}