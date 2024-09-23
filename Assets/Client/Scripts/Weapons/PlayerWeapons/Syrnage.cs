using UnityEngine;
using WeaponsAttacks;
using Tools;
using Zenject;

public class Syrnage : PlayerWeapon
{
    [SerializeField] private PlayerRaycastSettings _settings;

    private RaycastAttack _attack;

    public float Damage => _settings.Damage;

    public override void Initialize()
    {
        base.Initialize();
        _attack = new RaycastAttack(_settings);
        _attack.AcceptVisit += Accept;   
        _settings.SetDirection(transform.parent.parent);       
    }

    public override void PerformAttack()
    {
        _attack.PerformAttack();
    }

    public void Reload()
    {
        if(currentState != WeaponState.Attack)
        {
            return;
        }

        UpdateState(WeaponState.Reload);
        weaponAnimations.Reload();
    }
    public override void FinishAttack()
    {
        Reload();
    }

    public void FinishReload()
    {
        UpdateState(WeaponState.Idle);
    }

    public override void Attack()
    {
        if(currentState == WeaponState.Reload)
            return;
        base.Attack();
    }

    private void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
    {
        weaponVisitor?.Visit(this, hit);
    }
}