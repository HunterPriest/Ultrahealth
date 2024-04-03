using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private HealthConfiguration _healthConfig;
    public int Health;

    public void Initialize()
    {
        Health = _healthConfig.MaxHealth;
    }
}