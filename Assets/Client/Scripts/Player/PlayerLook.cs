using UnityEngine;
using Zenject;

public class PlayerLook : MonoBehaviour
{
    private GameConfigInstaller.PlayerSettings.CameraSettings _cameraSettings;
    private Transform _fpsRig;
    private float _xRotate;

    [Inject]
    private void Construct(HeadService headService)
    {
        _fpsRig = headService.fpsRig;   
    }

    public void UpdateCameraSettings(GameConfigInstaller.PlayerSettings.CameraSettings cameraSettings)
    {
        if(_cameraSettings != cameraSettings)
        {
            _cameraSettings = cameraSettings;
        }
    }
    
    public void Initialize(GameConfigInstaller.PlayerSettings.CameraSettings cameraSettings)
    {
        _cameraSettings = cameraSettings;
    }

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _cameraSettings.sens);
        _xRotate -= mousePosition.y * Time.deltaTime * _cameraSettings.sens;
        _xRotate = Mathf.Clamp(_xRotate, -80f, 80f);
        Quaternion fpsRigRotation = Quaternion.Euler(_xRotate, 0, 0);
        _fpsRig.localRotation = fpsRigRotation;
    }
}
