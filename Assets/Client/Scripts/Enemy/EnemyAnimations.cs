using UnityEngine;
using Tools;

public class EnemyAnimations : MonoBehaviour
{
    private const string MOVE = "Move";
    private const string IDLE = "Idle";
    private const string ATTACK = "Attack";

    [SerializeField] private Animator _animator;

    public void Move()
    {
        _animator.Play(MOVE);
    }

    public void Attack()
    {
        _animator.Play(ATTACK);
    }

    public void Idle()
    {
        _animator.Play(IDLE);
    }
}