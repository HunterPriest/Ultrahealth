using UnityEngine;

public abstract class DamagingWeapon : Weapon
{
    [SerializeField] private float _damage;

    public float damage => _damage;

    protected abstract void Accept(IWeaponVisitor weaponVisitor);
}