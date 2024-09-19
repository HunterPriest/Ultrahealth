using UnityEngine;
using Zenject;

public class MenuEnemySpawner : MonoBehaviour
{
    [SerializeField] private float _maxTimeSpawn;
    [SerializeField] private float _minTimeSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private MenuEnemy _enemy;  

    private float _currentTime;
    private float _currentSpawnTime = 1f;
    private Transform _target;

    [Inject]
    private void Construct(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentSpawnTime <= _currentTime)
        {
            MenuEnemy enemy = Instantiate(_enemy.gameObject, _spawnPoint.position, Quaternion.identity, null).GetComponent<MenuEnemy>();
            enemy.Initialize(_target);
            _currentSpawnTime = Random.Range(_minTimeSpawn, _maxTimeSpawn);
            _currentTime = 0;
        }
    }
}