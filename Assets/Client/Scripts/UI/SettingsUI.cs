using UnityEngine;
using UnityEngine.UIElements;

public class SettingsUI : UIToolkitElementWithExitOnButton
{
    [SerializeField] private MainSettingsUI _mainSettingsUI;
    [SerializeField] private Pause _pause;

    private VisualElement _setSettingsPanels;

    protected override void Initialize()
    {
        base.Initialize();

        Button mainSettings = UIElement.Q<Button>("mainSettings");
        Button back = UIElement.Q<Button>("Back");
        _setSettingsPanels = UIElement.Q<VisualElement>("SetSettings");
        Button save = UIElement.Q<Button>("Save");

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
            if (_pause != null)
            {
                _pause.Open();
            }
            else
            {
                Exit();
            }
        };
    }

    public override void Open()
    {
        base.Open();

        _mainSettingsUI.Open(_setSettingsPanels);
    }
}