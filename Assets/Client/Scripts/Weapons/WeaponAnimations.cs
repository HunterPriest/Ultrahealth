using UnityEngine;

public class WeaponAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Reload()
    {
        _animator.Play("Reload");
    }

    public void Attack()
    {
        _animator.Play("Attack");
    }

    public void Take()
    {
        _animator.Play("Take");
    }

    public void PutAway()
    {
        _animator.Play("PutAway");
    }
}