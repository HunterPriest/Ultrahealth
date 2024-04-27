using System.Collections;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private ClassConfig _playerMovementConfig;
    [SerializeField] private CharacterController _characterController;

    private Vector3 _playerVelocity;
    private Vector3 _direction;
    private float _stamina;

    public void Initialize()
    {
        _stamina = _playerMovementConfig.maxStamina;
    }

    private void Update()
    {
        _characterController.Move(transform.TransformDirection(_direction) * _playerMovementConfig.speed * Time.deltaTime);
        _playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        if (_characterController.isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void ChangeDirection(Vector2 direction)
    {
        _direction = new Vector3(direction.x, 0, direction.y);
    }

    public void Jump()
    {
        if (_characterController.isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_playerMovementConfig.jumpForce * -2f * Physics.gravity.y);
        }
    }

    public void Dash()
    {
        StartCoroutine(DashCorutine());
    }

    private IEnumerator DashCorutine()
    {
        Vector3 dashDirection;
        if(_direction == Vector3.zero)
        {
            dashDirection = Vector3.forward;
        }
        else
        {
            dashDirection = _direction;
        }

        float startTime = Time.time;
        while(Time.time < startTime + _playerMovementConfig.dashTime)
        {
            _characterController.Move(transform.TransformDirection(dashDirection) * _playerMovementConfig.dashSpeed * Time.deltaTime);
            yield return null;  
        }

    }
}