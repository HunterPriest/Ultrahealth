using Unity.VisualScripting;
using UnityEngine;

public abstract class OverlapWeapon : DamagingWeapon
{
    [SerializeField] private float _attackRange;
    [SerializeField] private int _hitColliders;
    [SerializeField] private Transform _overlapCirclePoint;
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_overlapCirclePoint.position, _attackRange);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(_overlapCirclePoint.position, 0.02f);
    }

    public override void PerformAttack()
    {
        Collider[] hitColliders = new Collider[_hitColliders];
        int amountColliders = Physics.OverlapSphereNonAlloc(_overlapCirclePoint.position, _attackRange, hitColliders);
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

    protected abstract void Accept(IWeaponVisitor weaponVisitor);
}