using System;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected float health; 

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
}