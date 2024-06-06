using UnityEngine;

public class Explosion : Decal
{

    public void SetRadius(float radius)
    {
        ParticleSystem.ShapeModule shape = decal.shape;
        shape.radius = radius;
    }
}