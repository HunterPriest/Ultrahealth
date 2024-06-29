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

    private Vector3 _point1;
    private Vector3 _point2;

    private Vector3 _point1old;
    private Vector3 _point2old;

    private bool _isOpen = false;

    private void OnValidate()
    {
        _point1 = _part1.position;
        _point1.y += _offset;
        _point2 = _part2.position;
        _point2.y -= _offset;

        _point1old = _part1.position;
        _point2old = _part2.position;

        _trigger.OnEnter += () => _animator.Play("Open");
        _trigger.OnExit += () => _animator.Play("Close");
    }


    private void Open()
    {
        if(!_isOpen)
        {
            _isOpen = true;
            _collider.enabled = false;
            StartCoroutine(OpenCoroutine());
            print(_isOpen);
        }
    }

    private void Close()
    {
        if(_isOpen)
        {
            _isOpen = false;
            _collider.enabled = true;
            StartCoroutine(CloseCoroutine());
            print(_isOpen);
        }
    }

    private IEnumerator OpenCoroutine()
    {
        StopAllCoroutines();
        while(_part1.position.y >= _point2.y && _part2.position.y >= _point1.y)
        {
            _part1.position = Vector3.MoveTowards(_part1.position, _point1, Time.deltaTime * _speed);
            _part2.position = Vector3.MoveTowards(_part2.position, _point2, Time.deltaTime * _speed);
            yield return null;  
        }
    }

    private IEnumerator CloseCoroutine()
    {
        StopAllCoroutines();
        while(_part1.position.y >= _point1old.y && _part2.position.y >= _point2old.y)
        {
            _part1.position = Vector3.MoveTowards(_part1.position, _point1old, Time.deltaTime * _speed);
            _part2.position = Vector3.MoveTowards(_part2.position, _point2old, Time.deltaTime * _speed);
            yield return null;  
        }
    }
}
