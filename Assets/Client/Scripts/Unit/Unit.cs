using System;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float health { get; protected set; }

    public Action<float> OnTakenDamage; 

    private Character _character;

    public void SetCharacter(Character character)
    {
        _character = character;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        OnTakenDamage?.Invoke(health);
        if(health <= 0)
        {
            _character.Dead();
        }
    }
    
}