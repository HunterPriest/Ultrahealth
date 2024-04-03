using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string RELOAD = "Recharge";
    

    public void Recharge()
    {
        _animator.Play(RELOAD);
    }
}
