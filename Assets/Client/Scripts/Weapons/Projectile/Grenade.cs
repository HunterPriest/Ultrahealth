using UnityEngine;

public class Grenade : Projectile
{
    [SerializeField] private float _attackRange;
    [SerializeField] private int _amountHitColliders;

    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor.Visit(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        Attack(other.gameObject);
    }

    protected override void Attack(GameObject gameObject)
    {
        Collider[] hitColliders = new Collider[_amountHitColliders];
        int amountColliders = Physics.OverlapSphereNonAlloc(transform.position, _attackRange, hitColliders);
        for(int i = 0; i < amountColliders; i++)
        {
            base.Attack(hitColliders[i].gameObject);
        }
    }
}