using UnityEngine;

public class HeartCancerWeapons : MonoBehaviour, IStateEnemy
{
    private EnemyAnimations _animations;
    private Weapon _spawnEnemyWeapon;
    [SerializeField] private Weapon _projectileWeapon;
    private float _nextTimeShoot;

    public void Initialize()
    {
        _projectileWeapon.Initialize();
    }

    public void Enter()
    {
        _projectileWeapon.Attack();
    }

    public void Exit()
    {
    }

    public void Loop()
    {
        if (Time.time > _nextTimeShoot)
        {
            _projectileWeapon.Attack();
            _nextTimeShoot = Time.time + 1f;
        }
    }

    public bool StateCompleted()
    {
        return false;
    }
}