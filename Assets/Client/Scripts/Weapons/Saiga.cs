using UnityEngine;

public class Saiga : RaycastWeapon
{
    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }
}