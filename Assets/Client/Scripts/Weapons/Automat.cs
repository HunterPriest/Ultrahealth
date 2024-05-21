using UnityEngine;

public class Automat : RaycastWeapon
{

    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }
}