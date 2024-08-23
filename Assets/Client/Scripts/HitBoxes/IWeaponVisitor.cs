using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(BacteriaWeapon weapon);
    public void Visit(HeartCancerProjectile heartCancerProjectile);
    public void Visit(Grenade grenade);
    public void Visit(Syrnage syrnage, RaycastHit hit);
    public void Visit(Defibrillator defibrillator);
}