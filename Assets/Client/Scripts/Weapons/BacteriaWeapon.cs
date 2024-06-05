using Tools;
using UnityEngine;

public class BacteriaWeapon : OverlapWeapon
{
    public override void Initialize()
    {
        UpdateState(WeaponState.Idle);
    }

    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }

    

    protected override void TryAcceptWeaponVisitor(Collider collider)
    {
        if(collider.gameObject.TryGetComponent(out PlayerHitBox weaponVisitor))
        {
            Accept(weaponVisitor);
        }
    }
}