using Unity.VisualScripting;
using UnityEngine;

public class HeartCancerProjectile : Projectile
{
    [SerializeField] private GameObject[] _projectileModels;

    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor.Visit(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Attack(other.gameObject);
    }

    public override void Run(Vector3 force)
    {
        base.Run(force);
        SpawnModel();
    }

    [ContextMenu("Spawn Model")]
    private void SpawnModel()
    {
        Transform modelTransform = Instantiate(_projectileModels[Random.Range(0, _projectileModels.Length)],
         Vector3.zero, Quaternion.identity, transform).transform;

        modelTransform.localScale = new Vector3(0.018f, 0.018f, 0.018f);
        modelTransform.localPosition = Vector3.zero;
    }

    protected override void Attack(GameObject gameObject)
    {
        base.Attack(gameObject);
        Destroy(this.gameObject);
    }
}