using UnityEngine;
using Tools;

public abstract class RaycastWeapon : FirearmWeapon
{
    [SerializeField] private float _distance;

    public override void PerformAttack()
    {
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
}