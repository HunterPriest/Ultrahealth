using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class MainSettingsUI : UIToolkitElement
{
    [SerializeField] private SettingsUI _settingsUI;

    private SettingsSaver _settingsSaver;
    private GameConfigInstaller.StandartSettings _standartSettings;
    private Slider _sens;

    [Inject]
    private void Construct(SettingsSaver settingsSaver, GameConfigInstaller.StandartSettings standartSettings)
    {
        _settingsSaver = settingsSaver;
        _standartSettings = standartSettings;
    }

    public void Open(VisualElement settings)
    {
        settings.Add(UIElement);
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