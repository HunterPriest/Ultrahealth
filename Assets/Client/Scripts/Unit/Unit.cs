using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private ClassConfig _healthConfig;
    public int Health;

    public void Initialize()
    {
        Health = _healthConfig.maxHealth;
    }
}