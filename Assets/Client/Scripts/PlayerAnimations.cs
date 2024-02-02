using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    

    public void Recharge()
    {
        _animator.Play("Recharge");
        
    }
}
