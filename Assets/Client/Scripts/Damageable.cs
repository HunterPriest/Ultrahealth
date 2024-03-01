using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    public void TakeDamage(int damage)
    {
        _unit.Health -= damage;
        if(_unit.Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}