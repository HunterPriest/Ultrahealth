using UnityEngine;

public class EnemyUnit : Unit
{
    [SerializeField] private HealthConfiguration _healthConfig;

    public void Initialize()
    {
        health = _healthConfig.maxHealth;
    }
}