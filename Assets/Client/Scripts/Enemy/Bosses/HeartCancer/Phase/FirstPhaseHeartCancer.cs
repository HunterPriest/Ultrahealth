using System.Collections;
using UnityEngine;

public class FirstPhaseHeartCancer : IPhase
{
    private ProjectileWeapon _projectileWeapon;
    private int _amountProjectileForRoundAttack;
    private float _nextTimeShoot;
    private float _angleBetweenSpawnPointProjectile;
    private Vector3 _distanceBetween;
    private Transform _playerTansform;
    private float _delayBetweenAttacksPlayer;
    private MonoBehaviour _monoBehaviour;

    public FirstPhaseHeartCancer(ProjectileWeapon projectileWeapon, int amountProjectileForRoundAttack,
    Transform playerTransform, float delayBetweenAttacksPlayer, MonoBehaviour monoBehaviour)
    {
        _projectileWeapon = projectileWeapon;
        _playerTansform = playerTransform;
        _amountProjectileForRoundAttack = amountProjectileForRoundAttack;
        _monoBehaviour = monoBehaviour;
        _delayBetweenAttacksPlayer = delayBetweenAttacksPlayer;
        _angleBetweenSpawnPointProjectile = 360f / _amountProjectileForRoundAttack;
        _distanceBetween = new Vector3(0, Vector3.Distance(_projectileWeapon.spawnPointProjectile.position,
         _monoBehaviour.transform.position), 0);
    }

    public void Enter()
    {

    }

    public void Loop()
    {
        if (Time.time > _nextTimeShoot)
        {
            ProjectileAttackPlayer();
            _nextTimeShoot = Time.time + _delayBetweenAttacksPlayer;
        }
    }

    public void Exit()
    {
    }

    public bool StateCompleted()
    {
        return false;
    }

    private void ProjectileAttackRound()
    {
        Transform spawnPoint = _projectileWeapon.spawnPointProjectile;
        for(int i = 0; i < _amountProjectileForRoundAttack; i++)
        {
            _projectileWeapon.Attack();
            spawnPoint.RotateAround(_monoBehaviour.transform.position, _distanceBetween, _angleBetweenSpawnPointProjectile);
            _projectileWeapon.SetSpawnPointProjectile(spawnPoint);
        }
    }

    private void ProjectileAttackPlayer()
    {
        _monoBehaviour.StartCoroutine(AttackPlayer());
    }

    private IEnumerator AttackPlayer()
    {
        _monoBehaviour.transform.LookAt(_playerTansform);
        yield return new WaitForSeconds(_delayBetweenAttacksPlayer);
        _projectileWeapon.Attack();
    }
}