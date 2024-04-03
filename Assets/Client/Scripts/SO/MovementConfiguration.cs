using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/Enemy/MovementConfiguration")]
public class MovementConfiguration : ScriptableObject
{
    public float Speed;
    public float JumpForce;
    public float MaxStamina;
}