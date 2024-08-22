using UnityEngine;

public class WeaponAnimations : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    public void Reload()
    {
        _animator.Play("Reload");
    }

    public virtual void Attack()
    {
        _animator.Play("Attack");
    }

    public void Take()
    {
        _animator.Play("Take");
    }

    public void Idle()
    {
        _animator.Play("Idle");
    }

    public void PutAway()
    {
        _animator.Play("PutAway");
    }
}