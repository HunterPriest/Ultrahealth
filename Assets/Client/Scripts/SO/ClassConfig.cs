using System;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Ultrahealth/ClassConfig")]
public class ClassConfig : ScriptableObject
{
    [Range(1, 3)] public int indexClassPlayer;

    [Header("Health")]
    public int maxHealth;

    [Header("Movement")]
    public int maxStamina;
    public int jumpForce;
    public float dashTime;
    public float dashSpeed;
    public float speed;
    public float rateOfIncreaseStamina;
    public float staminaConsumedWhenDashing;
    public float staminaConsumedWhenJumping;
}