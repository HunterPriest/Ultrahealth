using UnityEngine;
using Tools;
using Zenject;

public class HeartCencer : Boss
{
    [SerializeField] private ProjectileWeapon _projectileWeapon;
    [SerializeField] private int _amountProjectileForRoundAttack;
    [SerializeField] private float _delayBetweenAttacksPlayer;
    [SerializeField] private ProjectileWeapon _spawnEnemyWeapon;
    
    private HeartCancerWeapons _weapons;
    private HeartCancerIdle _idle;
    private GameUI _gameUI;

    [Inject]
    private void Construct(GameUI gameUI)
    {
        _gameUI = gameUI;
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        _idle = new HeartCancerIdle();
        _currentState = _idle;
    }

    public override void Initialize(Transform playerTransform)
    {
        base.Initialize(playerTransform);      
        _weapons = new HeartCancerWeapons(playerTransform, _projectileWeapon, _amountProjectileForRoundAttack,
        _delayBetweenAttacksPlayer, this);
        _currentState.Enter();
    }

    public override void Acivate()
    {
        base.Acivate();
        SetState(_weapons, EnemyState.Attacking);
        _unit.Initialize(this);
        _gameUI.gameplayUI.OpenBossHealthBar(_unit.health);
        _unit.ChangeHealth += _gameUI.gameplayUI.UpdateBossHealthBar;
    }

    public override void Dead()
    {
        _gameUI.gameplayUI.CloseBossHealthBar();
        base.Dead();
    }
}