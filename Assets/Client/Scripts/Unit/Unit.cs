using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitConfiguration UnitConfig;

    internal int Health;

    public void Initialize()
    {
        Health = UnitConfig.maxHealth;
    }
}