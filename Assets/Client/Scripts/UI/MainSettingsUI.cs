using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class MainSettingsUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _mainSettingsAsset;
    [SerializeField] private SettingsUI _settingsUI;

    private VisualElement _mainSettings;
    private SettingsSaver _settingsSaver;
    private GameConfigInstaller.StandartSettings _standartSettings;
    private Slider _sens;

    [Inject]
    private void Construct(SettingsSaver settingsSaver, GameConfigInstaller.StandartSettings standartSettings)
    {
        _settingsSaver = settingsSaver;
        _standartSettings = standartSettings;
    }

    protected override void Initialize()
    {
        _mainSettings = _mainSettingsAsset.CloneTree();
    }

    public void Open(VisualElement settings)
    {
        settings.Add(_mainSettings);
        _sens = _container.Q<Slider>("Sens");

        _sens.highValue = _standartSettings.maxSens;
        _sens.lowValue = 0;
        _sens.value = _settingsSaver.currentSave.sens;
    }

    public void Save()
    {
        _settingsSaver.currentSave.sens = _sens.value;
        _settingsSaver.SaveCurrentSave();
    }
}