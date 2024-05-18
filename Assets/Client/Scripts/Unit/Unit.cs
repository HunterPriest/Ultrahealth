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

    private void Dead()
    {
        Destroy(gameObject);
    }
}