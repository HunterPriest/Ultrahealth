using UnityEngine;

public class EnemyUnit : Unit
{
    [SerializeField] private HealthConfiguration _healthConfig;

    public void Initialize(Character character)
    {
        health = _healthConfig.maxHealth;
        SetCharacter(character);
    }
}