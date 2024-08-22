using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerSound _playerSound;

    private Vector3 _playerVelocity;
    private Vector3 _direction;
    private PlayerUnit _playerUnit;
    private GameConfigInstaller.PlayerSettings.MovementSettings _movementSettings;
    private bool _isDashing = false;

    public void Initialize(PlayerUnit playerUnit, GameConfigInstaller.PlayerSettings.MovementSettings movementSettings)
    {
        _playerUnit = playerUnit;
        _movementSettings = movementSettings;
    }

    private void Update()
    {
        _characterController.Move(transform.TransformDirection(_direction) * _movementSettings.speed * Time.deltaTime);
        _playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        if (_characterController.isGrounded)
        {
            if (_playerVelocity.y < 0 && !_isDashing)
            {
                _playerVelocity.y = -2f;
            }
            if(_direction != Vector3.zero)
            {
                _playerSound.Walk();    
            }
        }
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void ChangeDirection(Vector2 direction)
    {
        _direction = new Vector3(direction.x, 0, direction.y);
    }

    public void Jump()
    {
        if(_playerUnit.stamina <= 0 || (_playerUnit.stamina - _movementSettings.staminaConsumedWhenJumping <= 0) || !_characterController.isGrounded)
        {
            return;
        }
        _playerSound.Jump();
        _playerUnit.LowerStamina(_movementSettings.staminaConsumedWhenJumping);
        _playerVelocity.y = Mathf.Sqrt(_movementSettings.jumpForce * -2f * Physics.gravity.y);
    }

    public void Dash()
    {        
        if(_playerUnit.stamina <= 0 || (_playerUnit.stamina - _movementSettings.staminaConsumedWhenDashing <= 0) && _isDashing)
        {
            return;
        }
        _isDashing = true;
        _playerSound.Dash();
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
        _playerUnit.LowerStamina(_movementSettings.staminaConsumedWhenDashing);

        float endTime = Time.time + _movementSettings.dashTime;
        while(Time.time < endTime)
        {
            _characterController.Move(transform.TransformDirection(dashDirection) * _movementSettings.dashSpeed * Time.deltaTime);
            yield return null;  
        }

        _isDashing = false;
    }
}