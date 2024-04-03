using UnityEngine;

public class BacteriaWeapon : OverlapWeapon
{
    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        
    }

    protected override void TryAcceptWeaponVisitor(Collider collider)
    {
        if(collider.gameObject.TryGetComponent(out PlayerHitBox weaponVisitor))
        {
            Accept(weaponVisitor);
            print('t');
        }
    }
}