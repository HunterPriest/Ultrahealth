using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitConfiguration UnitConfig;
    public int Health;

    public virtual void Initialize()
    {
        Health = UnitConfig.MaxHealth;
    }
}