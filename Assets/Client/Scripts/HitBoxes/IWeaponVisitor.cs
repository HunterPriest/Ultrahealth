using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(Saiga weapon);
    public void Visit(Automat weapon);
    public void Visit(BacteriaWeapon weapon);
    public void Visit(HeartCancerProjectile heartCancerProjectile);
}