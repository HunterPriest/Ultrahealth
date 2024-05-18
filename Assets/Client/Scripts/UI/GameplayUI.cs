using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class GameplayUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _gameplayUIAsset;

    private VisualElement _gameplayUI;
    private ProgressBar _healthBar;
    private ProgressBar _staminaBar;
    private GameConfigInstaller.PlayerSettings _playerSettings;

    public void InitializeValues(GameConfigInstaller.PlayerSettings playerSettings)
    {
        _playerSettings = playerSettings;
    }

    protected override void Initialize()
    {
        _gameplayUI = _gameplayUIAsset.CloneTree();
        Open();
    }

    public void Open()
    {
        ResetContainer(_gameplayUI);
        InitializeUI(_playerSettings.healthSettings.maxHealth, _playerSettings.movementSettings.maxStamina);
    }

    private void InitializeUI(float maxHealth, float maxStamina)
    {
        _healthBar = _container.Q<ProgressBar>("Health");
        _staminaBar = _container.Q<ProgressBar>("Stamina");
        _healthBar.lowValue = 0;
        _healthBar.highValue = maxHealth;
        _healthBar.title = _healthBar.highValue.ToString() + "/" + _healthBar.highValue.ToString();
        _staminaBar.lowValue = 0;
        _staminaBar.highValue = maxStamina;
        _staminaBar.title = _staminaBar.highValue.ToString() + "/" + _staminaBar.highValue.ToString();
    }

    public void UpdateHealthBarValue(float value)
    {
        _healthBar.value = value;
        _healthBar.title = _healthBar.value.ToString() + "/" + _healthBar.highValue.ToString();
    }

    public void UpdateStaminahBarValue(float value)
    {
        _staminaBar.value = value;
        _staminaBar.title = _staminaBar.value.ToString() + "/" + _staminaBar.highValue.ToString();
    }
}