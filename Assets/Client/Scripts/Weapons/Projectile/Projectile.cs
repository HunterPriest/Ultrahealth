using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _damage;

    public float damage => _damage;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Run(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Force);
        Destroy(gameObject, 10f);
    }

    protected virtual void Accept(IWeaponVisitor visitor) {   }

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