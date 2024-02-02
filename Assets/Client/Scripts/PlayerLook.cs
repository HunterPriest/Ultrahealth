using UnityEngine;
using Tools;
using Unity.VisualScripting.ReorderableList;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _sens;
    [SerializeField] private GameObject FPSRig;
    
    private float _xRotate;

    public void RotateCamera(Vector2 mousePosition)
    {
        transform.Rotate(Vector3.up * mousePosition.x * Time.deltaTime * _sens);
        _xRotate -= mousePosition.y * Time.deltaTime * _sens;
        Quaternion FPSRigRotation = Quaternion.Euler(Mathf.Clamp(_xRotate, -80f, 80f), 0, 0);
        FPSRig.transform.localRotation = FPSRigRotation;
    }
}
