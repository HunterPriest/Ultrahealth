using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpCoefficient;

    private Vector3 _playerVelocity;
    private Vector3 _direction;

    private void OnValidate()
    {
        if (_jumpCoefficient > 0)
        {
            _jumpCoefficient = -2f;
        }
    }

    private void Update()
    {
        _playerVelocity += Physics.gravity * Time.deltaTime;
        _characterController.Move(_playerVelocity);
        if (_characterController.isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _characterController.Move(_direction * _speed * Time.deltaTime);
    }

    public void ChangeDirection(Vector2 direction)
    {
        _direction = transform.TransformDirection(new Vector3(direction.x, 0, direction.y));
    }

    public void Jump()
    {
        if (!_characterController.isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
        }
    }
}
