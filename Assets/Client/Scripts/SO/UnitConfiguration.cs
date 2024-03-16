using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfiguration", menuName = "SO/UnitConfiguration")]
public class UnitConfiguration : ScriptableObject
{
    public int MaxHealth;
    public float RunSpeed;
    public float Speed;
}