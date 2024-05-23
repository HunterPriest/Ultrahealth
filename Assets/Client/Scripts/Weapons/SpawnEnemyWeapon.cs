using UnityEngine;

public class SpawnEnemyWeapon : Weapon
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy[] _enemyies;

    public override void PerformAttack()
    {
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_enemyies[Random.Range(0, _enemyies.Length)].gameObject , _spawnPoints[i].position, Quaternion.identity);
        }
    }

    public override void Attack()
    {
        base.Attack();
        PerformAttack();
    }

}