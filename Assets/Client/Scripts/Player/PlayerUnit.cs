using UnityEngine;
using Zenject;

public class PlayerUnit : Unit
{
    private GameConfigInstaller.PlayerSettings.HealthSettings _healthSettings;

    public void Initialize(GameConfigInstaller.PlayerSettings.HealthSettings healthSettings)
    {
        _healthSettings = healthSettings;
        health = _healthSettings.maxHealth;
    }
}