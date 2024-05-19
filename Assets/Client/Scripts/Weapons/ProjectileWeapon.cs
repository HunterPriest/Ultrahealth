using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] private Transform _spawnPointProjectile;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _forceRunProjectile;

    public override void Attack()
    {
        base.Attack();
        PerformAttack();
    }

    public override void PerformAttack()
    {
        GameObject projectile = Instantiate(_projectile.gameObject, _spawnPointProjectile.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Run(Vector3.up * _forceRunProjectile, this);
    }
}