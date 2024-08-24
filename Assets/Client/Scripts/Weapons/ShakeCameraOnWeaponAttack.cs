using UnityEngine;
using Zenject;

public class ShakeCameraOnWeaponAttack : MonoBehaviour
{
    private Transform _cameraTransform;

    [Inject]
    private void Constuct(HeadService headService)
    {
        _cameraTransform = headService.cameraTransform;
    }

    public void ReactOnAttack()
    {
        
    }
}