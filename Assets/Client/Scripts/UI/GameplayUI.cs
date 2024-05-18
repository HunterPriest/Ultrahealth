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
        _staminaBar.lowValue = 0;
        _staminaBar.highValue = maxStamina;
    }
}