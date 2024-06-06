using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] private float _damage;

    public float damage => _damage;

    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Run(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Force);
        Destroy(gameObject, 10f);
    }

    protected virtual void Attack(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out IWeaponVisitor weaponVisitor))
        {
            Accept(weaponVisitor);
        }
    }

    protected virtual void Accept(IWeaponVisitor visitor) {   }
}