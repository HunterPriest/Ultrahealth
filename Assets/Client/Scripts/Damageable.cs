using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    public void TakeDamage(int damage)
    {
        _unit.TakeDamage(damage);
    }
}