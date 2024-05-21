using UnityEngine;

public class HeartCancerWeapons : IStateEnemy
{
    private ProjectileWeapon _projectileWeapon;
    private int _amountProjectileForRoundAttack;
    private float _delayBetweenAttacksPlayer;
    private ProjectileWeapon _spawnEnemyWeapon;
    private FirstPhaseHeartCancer _firstPhaseHeartCancer;
    private IPhase _currentPhase;

    public HeartCancerWeapons(Transform playerTransform, ProjectileWeapon projectileWeapon, int amountProjectileForRoundAttack,
    float delayBetweenAttacksPlayer, MonoBehaviour monoBehaviour)
    {
        _projectileWeapon = projectileWeapon;
        _amountProjectileForRoundAttack = amountProjectileForRoundAttack;
        _delayBetweenAttacksPlayer = delayBetweenAttacksPlayer;
        _projectileWeapon.Initialize();
        _firstPhaseHeartCancer = new FirstPhaseHeartCancer(_projectileWeapon, _amountProjectileForRoundAttack,
        playerTransform, _delayBetweenAttacksPlayer, monoBehaviour);
        _currentPhase = _firstPhaseHeartCancer;
    }

    public void Enter() {   }

    public void Exit() {   }

    public void Loop()
    {
        _firstPhaseHeartCancer.Loop();
    }

    public bool StateCompleted()
    {
        return false;
    }

}