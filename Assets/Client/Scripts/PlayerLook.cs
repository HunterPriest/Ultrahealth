using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _sens;

    private Transform _fpsRig;
    private float _xRotate;

    public void Initialize(Transform fpsRig)
    {
        _fpsRig = fpsRig;
    }

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _sens);
        _xRotate -= mousePosition.y * Time.deltaTime * _sens;
        Quaternion fpsRigRotation = Quaternion.Euler(Mathf.Clamp(_xRotate, -80f, 80f), 0, 0);
        _fpsRig.localRotation = fpsRigRotation;
    }
}
