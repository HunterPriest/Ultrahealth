using System;
using System.Collections;
using Zenject;
using Tools;

public class PlayerUnit : Unit
{
    private GameConfigInstaller.PlayerSettings.HealthSettings _healthSettings;
    private GameConfigInstaller.PlayerSettings.MovementSettings _movementSettings;

    private float _stamina;

    public Action<float> ChangeStamina;

    public float stamina => _stamina;

    public void Initialize(GameConfigInstaller.PlayerSettings.HealthSettings healthSettings, 
    GameConfigInstaller.PlayerSettings.MovementSettings movementSettings, Player player)
    {
        _healthSettings = healthSettings;
        health = _healthSettings.maxHealth;
        _movementSettings = movementSettings;
        _stamina = _movementSettings.maxStamina;
        SetCharacter(player);
    }

    public void LowerStamina(float a)
    {
        _stamina -= a;

        StopCoroutine(DecreaseStamina());
        StartCoroutine(DecreaseStamina());
    }

    private IEnumerator DecreaseStamina()
    {
        while(_stamina < _movementSettings.maxStamina)
        {   
            _stamina += _movementSettings.rateOfIncreaseStamina;
            ChangeStamina.Invoke(_stamina);
            yield return null;  
        }
        _stamina = _movementSettings.maxStamina;
        ChangeStamina.Invoke(stamina);
    }
}