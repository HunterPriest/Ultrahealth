using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/Enemy/MovementConfiguration")]
public class MovementConfiguration : ScriptableObject
{
    public float speed;
    public float JumpForce;
    public float MaxStamina;
}