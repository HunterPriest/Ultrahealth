using UnityEngine;

public class Automaton : RaycastWeapon
{
    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }
}