using UnityEngine;
using Tools;
using Zenject;
using System;
using Unity.VisualScripting;

public class HeartCencer : Boss
{ 
    [SerializeField] private HeartCancerWeapons _weapons;
    [SerializeField] private BossBehaviourConfig _bossBehaviourConfig;

    private HeartCancerIdle _idle;
    private GameUI _gameUI;
    private int _currentIndexPhase;

    public Action onSetPhase;

    [Inject]
    private void Construct(GameUI gameUI)
    {
        _gameUI = gameUI;
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        _idle = new HeartCancerIdle();
        currentState = _idle;
        bossUnit.SetDamageable(false);
        _currentIndexPhase = 1;
        _weapons.Initialize(this);
    }

    public override void Initialize(Transform playerTransform, ComboCounter comboCounter, KillCounter killCounter)
    {
        base.Initialize(playerTransform, comboCounter, killCounter);      
        bossUnit.OnTakenDamage += comboCounter.AddCombo;
        bossUnit.OnTakenDamage += SetPhase;
        _weapons.Initialize(playerTransform, comboCounter, killCounter);
        currentState.Enter();
    }

    public override void Acivate()
    {
        SetState(_weapons, EnemyState.Attacking);
        bossUnit.Initialize(this);
        _gameUI.gameplayUI.OpenBossHealthBar(bossUnit.health);
        bossUnit.SetDamageable(true);
        bossUnit.OnTakenDamage += _gameUI.gameplayUI.UpdateBossHealthBar;
    }

    public override void Dead()
    {
        _gameUI.gameplayUI.CloseBossHealthBar();
        base.Dead();
    }

    public void LookAt(Transform target)
    {
        transform.LookAt(target);
        Quaternion quaternion = Quaternion.Euler(new Vector3(90f, -90f, 0));
        transform.rotation *= quaternion;
    }

    public override void SetPhase(float damage)
    {
        if(_bossBehaviourConfig.phases.TryGetValue(_currentIndexPhase + 1, out int health))
        {
            if(bossUnit.health <= health)
            {
                _currentIndexPhase++;
                if(_currentIndexPhase == 2)
                {
                    _weapons.SetPhaseToSecond();
                }
            }
        }
    }
}