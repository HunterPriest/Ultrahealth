using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class MainSettingsUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _mainSettingsAsset;
    [SerializeField] private SettingsUI _settingsUI;

    private VisualElement _settings;
    private PlayerSaver _playerSaver;
    private Slider _sens;

    [Inject]
    private void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        _settings = _mainSettingsAsset.CloneTree();
    }

    public void Open()
    {
        ResetContainer(_settings);
        _sens = _container.Q<Slider>("Sens");
        Button back = _container.Q<Button>("Back");

        _sens.highValue = 1;
        _sens.value = _playerSaver.currentSave.playerSave.sens;
        _sens.lowValue = 0;

        back.clicked += _settingsUI.Open;
        back.clicked += Save;
    }

    private void Save()
    {
        _playerSaver.currentSave.playerSave.sens = _sens.value;
        _playerSaver.SaveCurrentSave();
    }
}