using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/HealthConfiguration")]
public class HealthConfiguration : ScriptableObject
{
    [SerializeField] private float _maxHealth;

    public float maxHealth => _maxHealth;
}