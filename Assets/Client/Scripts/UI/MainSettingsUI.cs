using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class MainSettingsUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _mainSettingsAsset;
    [SerializeField] private SettingsUI _settingsUI;

    private VisualElement _mainSettings;
    private SettingsSaver _settingsSaver;
    private Slider _sens;

    [Inject]
    private void Construct(SettingsSaver settingsSaver)
    {
        _settingsSaver = settingsSaver;
    }

    protected override void Initialize()
    {
        _mainSettings = _mainSettingsAsset.CloneTree();
    }

    public void Open(VisualElement moterObj)
    {
        moterObj.Add(_mainSettings);
        _sens = _container.Q<Slider>("Sens");

        _sens.highValue = 1;
        _sens.value = _settingsSaver.currentSave.sens;
        _sens.lowValue = 0;

    }

    private void Save()
    {
        _settingsSaver.currentSave.sens = _sens.value;
        _settingsSaver.SaveCurrentSave();
    }
}