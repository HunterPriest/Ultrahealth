using UnityEngine;

public class WeaponAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Reload()
    {
        _animator.Play("Reload");
    }

    public void Shoot()
    {
        _animator.Play("Shoot");
    }
}