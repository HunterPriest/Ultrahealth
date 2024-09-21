using UnityEngine;

public class PlayerAnimations : WeaponAnimations
{
    private const string RELOAD = "Recharge";   

    public void Recharge()
    {
        _animator.Play(RELOAD);
    }
}
