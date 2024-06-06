using UnityEngine;
using Zenject.SpaceFighter;

public class Grenade : Projectile
{
    [SerializeField] private float _attackRange;
    [SerializeField] private int _amountHitColliders;
    [SerializeField] private Explosion _decal;
    [SerializeField] private Rigidbody _rbOfPart;
    [SerializeField] private Collider _colOfPart;
    [SerializeField] private float _forceOfOpen;

    private bool _isAlredyTouched = false; 


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
        if(_isAlredyTouched == true)
        {
            return;
        }
        _isAlredyTouched = true;
        Collider[] hitColliders = new Collider[_amountHitColliders];
        int amountColliders = Physics.OverlapSphereNonAlloc(transform.position, _attackRange, hitColliders);
        Explosion explosion = Instantiate(_decal.gameObject, transform.position,
        Quaternion.identity).GetComponent<Explosion>();
        Destroy(explosion.gameObject, 10f);
        explosion.SetRadius(_attackRange);
        rb.mass = 0;
        _rbOfPart.isKinematic = false;
        _colOfPart.enabled = true;
        _rbOfPart.AddForce(transform.TransformDirection(Vector3.up) * _forceOfOpen, ForceMode.Force);
        for(int i = 0; i < amountColliders; i++)
        {
            base.Attack(hitColliders[i].gameObject);
        }
    }
}