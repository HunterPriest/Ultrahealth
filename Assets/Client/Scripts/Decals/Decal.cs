using System;
using UnityEngine;

public class Decal : MonoBehaviour
{
    [SerializeField] protected ParticleSystem decal;    

    public Action OnFinishDecal;

    public void Finish()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(!decal.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}