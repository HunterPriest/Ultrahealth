using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private Vector3 _playerVelocity;
    private Vector3 _direction;

    private void Update()
    {
        _characterController.Move(_direction * _speed * Time.deltaTime);
        _playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        if (_characterController.isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = -2f;
        }
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void ChangeDirection(Vector2 direction)
    {
        _direction = transform.TransformDirection(new Vector3(direction.x, 0, direction.y));
    }

    public void Jump()
    {
        if (_characterController.isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
        }
    }
}
