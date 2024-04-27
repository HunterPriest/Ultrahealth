using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ClassConfig")]
public class ClassConfig : ScriptableObject
{
    [Range(0, 2)] public int indexClassPlayer;

    [Header("Health")]
    public int maxHealth;

    [Header("Movement")]
    public int maxStamina;
    public int jumpForce;
    public float dashTime;
    public float dashSpeed;
    public float speed;

    
}