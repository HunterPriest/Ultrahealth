using Tools;
using UnityEngine;
using WeaponsAttacks;

public class BacteriaWeapon : Weapon
{
    [SerializeField] private OverlapSettings _settings;

    private OverlapAttack _attack;

    public float Damage => _settings.Damage;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_settings.OverlapPoint.position, _settings.AttackRange);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(_settings.OverlapPoint.position, 0.02f);
    }

    public override void PerformAttack()
    {
        _attack.PerformAttack();
    }

    public override void Initialize()
    {
        base.Initialize();
        _attack = new OverlapAttack(_settings);
        _attack.AcceptVisit += Accept;
    }

    protected void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }
}