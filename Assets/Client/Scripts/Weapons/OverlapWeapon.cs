using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public abstract class OverlapWeapon : DamagingWeapon
{
    [SerializeField] private float _attackRange;
    [SerializeField] private int _hitColliders;
    
    public override void PerformAttack()
    {
        Collider[] hitColliders = new Collider[_hitColliders];
        int amountColliders = Physics.OverlapSphereNonAlloc(transform.position, _attackRange, hitColliders);
        TryPerformAttack(hitColliders, amountColliders);
    }

    private void TryPerformAttack(Collider[] colliders, int amountColliders)
    {
        for(int i = 0; i < amountColliders; i++)
        {
            TryAcceptWeaponVisitor(colliders[i]);
        }
    }

    protected virtual void TryAcceptWeaponVisitor(Collider collider)
    {
        if(collider.gameObject.TryGetComponent(out IWeaponVisitor weaponVisitor))
        {
            Accept(weaponVisitor);
        }
    }

}