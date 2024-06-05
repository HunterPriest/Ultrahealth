using UnityEngine;

public abstract class ProjectileWeapon : Weapon
{
    [SerializeField] private Transform _spawnPointProjectile;
    [SerializeField] private Projectile _projectile;
    [SerializeField] private float _forceRunProjectile;

    public Transform spawnPointProjectile => _spawnPointProjectile; 

    public override void Attack()
    {
        base.Attack();
    }
    
    public override void PerformAttack()
    {
        GameObject projectile = Instantiate(_projectile.gameObject, _spawnPointProjectile.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Run(_spawnPointProjectile.TransformDirection(Vector3.right * _forceRunProjectile));
    }

    public void SetSpawnPointProjectile(Transform point)
    {
        _spawnPointProjectile = point;
    }
}