using UnityEngine;
using Tools;

public abstract class RaycastWeapon : DamagingWeapon
{
    [SerializeField] private float _distance;
    protected Transform direction;
    
    public override void SetDirection(Transform transform)
    {
        direction = transform;
    }


    public override void PerformAttack()
    {
        if (Physics.Raycast(direction.position, direction.forward, out RaycastHit hit, _distance))
        {
            HitScan(hit);
        }
    }

    private void HitScan(RaycastHit hit)
    {
        if(hit.transform.gameObject.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor weaponVisitor))
        {
            Accept(weaponVisitor, hit);
        }
    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit);
}