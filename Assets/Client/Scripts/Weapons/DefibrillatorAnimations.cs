using UnityEngine;

public class DefibrillatorAnimations : WeaponAnimations
{
    public override void Attack()
    {
        int animationIndex = Random.Range(1, 3);
        Debug.Log(animationIndex);
        _animator.Play("Attack" + animationIndex.ToString());
    }
}