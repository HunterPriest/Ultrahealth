using System;
using System.Collections;
using Zenject;
using Tools;

public class PlayerUnit : Unit
{
    private GameConfigInstaller.PlayerSettings.HealthSettings _healthSettings;
    private GameConfigInstaller.PlayerSettings.MovementSettings _movementSettings;

    private float _stamina;
    private GameUI _gameUI;
    private GameMachine _gameMachine;

    public Action<float> ChangeStamina;
    public Action<float> ChangeHealth;

    public float stamina => _stamina;

    public void Initialize(GameConfigInstaller.PlayerSettings.HealthSettings healthSettings, 
    GameConfigInstaller.PlayerSettings.MovementSettings movementSettings)
    {
        _healthSettings = healthSettings;
        health = _healthSettings.maxHealth;
        _movementSettings = movementSettings;
        _stamina = _movementSettings.maxStamina;
    }

    [Inject]
    private void Construct(GameMachine gameMachine, GameUI gameUI)
    {
        _gameMachine = gameMachine;
        _gameUI = gameUI;
    }

    public void LowerStamina(float a)
    {
        _stamina -= a;

        StopCoroutine(IncreaseStamina());
        StartCoroutine(IncreaseStamina());
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        ChangeHealth.Invoke(health);
    }

    private IEnumerator IncreaseStamina()
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

    protected override void Dead()
    {
        _gameUI.deathPlayer.Open();
        _gameMachine.StopGame(GameState.Death);
    }
}