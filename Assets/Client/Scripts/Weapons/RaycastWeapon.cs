using UnityEngine;
using Tools;

public abstract class RaycastWeapon : Weapon
{
    [SerializeField] private float _distance;

    public override void PerformShot()
    {
        base.Shoot();
        if (Physics.Raycast(RigCamera.transform.position, RigCamera.transform.forward, out RaycastHit hit, _distance))
        {
            HitScan(hit);
        }
    }

    private void HitScan(RaycastHit hit)
    {
        if(hit.transform.gameObject.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor weaponVisitor))
        {
            Accept(weaponVisitor);
        }
    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor);
}