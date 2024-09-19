using UnityEngine;
using Zenject;

public class MenuEnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _enemy;  

    private Transform _playerTransform;

    [Inject]  
    private void Construct(Transform transform)
    {
        _playerTransform = transform;
    }

    private void Start()
    {
        Enemy enemy = Instantiate(_enemy, _spawnPoint.position, Quaternion.identity, null).GetComponent<Enemy>();
        enemy.Initialize(_playerTransform, null, null);
    }

}