using UnityEngine;
using Tools;
using Zenject;

public class HeartCencer : Boss
{ 
    [SerializeField] private HeartCancerWeapons _weapons;
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
        _weapons.Initialize(this);
        _currentState = _idle;
    }

    public override void Initialize(Transform playerTransform, ComboCounter comboCounter)
    {
        base.Initialize(playerTransform, comboCounter);      
        _weapons.Initialize(playerTransform);
        _currentState.Enter();
    }

    public override void Acivate()
    {
        base.Acivate();
        SetState(_weapons, EnemyState.Attacking);
        _unit.Initialize(this);
        _gameUI.gameplayUI.OpenBossHealthBar(_unit.health);
        _unit.OnTakenDamage += _gameUI.gameplayUI.UpdateBossHealthBar;
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
}