using System;
using System.Collections;
using TMPro.SpriteAssetUtilities;
using UnityEngine;

[Serializable]
public class FirstPhaseHeartCancerWeapons : IPhase
{
    [SerializeField] private int _amountProjectileForRoundAttack;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _delayBetweenAttacksPlayer;
    [SerializeField] private int _maxAmountShots;
    [SerializeField] private int _minAmountShots;
    [SerializeField] private int _maxAmountRoundShoot;
    [SerializeField] private int _minAmountRoundShoot;
    [SerializeField] private ProjectileWeapon _projectileWeapon;

    private float _nextTimeShoot;
    private float _angleBetweenSpawnPointProjectile;
    private Vector3 _distanceBetween;
    private Transform _playerTansform;
    private MonoBehaviour _monoBehaviour;
    private int _amountShotsAttack = 0;
    private int _amountShotsRoundAttack = 0;
    private bool _attackIsRound;

    public void Initialize(Transform playerTransform)
    {
        _playerTansform = playerTransform;
    }

    public void Initialize(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
        _projectileWeapon.Initialize();
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
            if(_amountShotsAttack == 0 && _amountShotsRoundAttack == 0)
            {
                if(_amountShotsAttack == 0 && _attackIsRound)
                {
                    _amountShotsAttack = UnityEngine.Random.Range(_minAmountShots, _maxAmountShots);
                    _attackIsRound = false;
                }
                else if(_amountShotsRoundAttack == 0 && !_attackIsRound)
                {
                    _amountShotsRoundAttack = UnityEngine.Random.Range(_minAmountRoundShoot, _maxAmountRoundShoot);
                    _attackIsRound = true;
                }
            }

            if(_amountShotsAttack != 0)
            {
                Attack();
                _amountShotsAttack--;
            }
            else if(_amountShotsRoundAttack != 0)
            {
                RoundAttack();
                _amountShotsRoundAttack--;
            }
            
            _nextTimeShoot = Time.time + _fireRate;
        }
    }

    public void Exit()
    {
    }

    public bool StateCompleted()
    {
        return true;
    }

    private void RoundAttack()
    {
        Transform spawnPoint = _projectileWeapon.spawnPointProjectile;
        for(int i = 0; i < _amountProjectileForRoundAttack; i++)
        {
            _projectileWeapon.Attack();
            spawnPoint.RotateAround(_monoBehaviour.transform.position, _distanceBetween, _angleBetweenSpawnPointProjectile);
            _projectileWeapon.SetSpawnPointProjectile(spawnPoint);
        }
    }

    private void Attack()
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