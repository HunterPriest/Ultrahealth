using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;
using Zenject;

public class MenuEnemy : MonoBehaviour 
{
    [SerializeField] private float _lifeTime;

    private float _currentTime;

    public void Initialize(Transform target)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        EnemyAnimations enemyAnimations = GetComponent<EnemyAnimations>();
        enemyAnimations.Move();
        agent.SetDestination(target.position);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}