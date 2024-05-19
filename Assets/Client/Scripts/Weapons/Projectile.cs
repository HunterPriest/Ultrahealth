using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    private ProjectileWeapon _projectileWeapon;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Run(Vector3 force, ProjectileWeapon projectileWeapon)
    {
        _projectileWeapon = projectileWeapon;
        _rigidbody.AddForce(force, ForceMode.Force);
    }
    protected virtual void Accept(IWeaponVisitor visitor)
    {
        visitor.Visit(_projectileWeapon);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IWeaponVisitor>(out IWeaponVisitor visitor))
        {
            Accept(visitor);
            return;
        }
        Destroy(gameObject);
    }
}