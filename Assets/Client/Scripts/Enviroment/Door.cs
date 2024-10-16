using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Transform _part1;
    [SerializeField] private Transform _part2;
    [SerializeField] private float _offset;
    [SerializeField] private float _speed;
    [SerializeField] private Trigger _trigger;
    [SerializeField] private Animator _animator;
    [SerializeField] private MeshRenderer _spriteRenderer;

    private Vector3 _point1;
    private Vector3 _point2;

    private Vector3 _point1old;
    private Vector3 _point2old;

    private bool _isBlocked = false;
    private bool _isOpen = false;

    private void OnEnable()
    {
        _point1 = _part1.position;
        _point1.y += _offset;
        _point2 = _part2.position;
        _point2.y -= _offset;

        _point1old = _part1.position;
        _point2old = _part2.position;

        _trigger.OnEnter += Open;
        _trigger.OnExit += Close;
    }


    private void Open()
    {
        if(!_isOpen && !_isBlocked)
        {
            _isOpen = true;
            _collider.enabled = false;
            _animator.Play("Open");
        }
    }

    private void Close()
    {
        if(_isOpen)
        {
            _isOpen = false;
            _collider.enabled = true;
            _animator.Play("Close");
        }
    }

    public void Block()
    {
        _isBlocked = true;
        _spriteRenderer.enabled = true;
    }

    public void Unblock()
    {
        _isBlocked = false;
        _spriteRenderer.enabled = false;
    }
}
