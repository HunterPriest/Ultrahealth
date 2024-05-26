using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameplayUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _gameplayUIAsset;

    private VisualElement _gameplayUI;
    private ProgressBar _healthBar;
    private ProgressBar _staminaBar;
    private ProgressBar _bossHealthBar;
    private GameConfigInstaller.PlayerSettings _playerSettings;
    private Label _combo;

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
        _bossHealthBar = _container.Q<ProgressBar>("BossHP");
        _healthBar.lowValue = 0;
        _healthBar.highValue = maxHealth;
        _healthBar.title = _healthBar.highValue.ToString() + "/" + _healthBar.highValue.ToString();
        _staminaBar.lowValue = 0;
        _staminaBar.highValue = maxStamina;
        _staminaBar.title = _staminaBar.highValue.ToString() + "/" + _staminaBar.highValue.ToString();
        _combo = _container.Q<Label>("Combo");
    }

    public void UpdateHealthBarValue(float value)
    {
        UpdateProgressBarWithTitle(value, _healthBar);
    }

    public void UpdateStaminahBarValue(float value)
    {
        UpdateProgressBarWithTitle(value, _staminaBar);
    }

    private void UpdateProgressBarWithTitle(float value, ProgressBar progressBar)
    {
        progressBar.value = value;
        progressBar.title = Math.Round((decimal)progressBar.value, 2).ToString() + "/" + progressBar.highValue.ToString();
    }

    public void OpenBossHealthBar(float maxHealth)
    {
        _bossHealthBar.visible = true;
        _bossHealthBar.highValue = maxHealth;
        _bossHealthBar.value = _bossHealthBar.highValue;
    }

    public void UpdateBossHealthBar(float value)
    {
        _bossHealthBar.value = value;
    }

    public void CloseBossHealthBar()
    {
        _bossHealthBar.visible = false;
    }

    public void SetCombo(int amountCombo, Color color)
    {
        _combo.text = "Combo: X" + amountCombo.ToString();
        _combo.style.color = color;
    }

    public void SetComboVisible(bool state)
    {
        _combo.visible = state;
    }
}