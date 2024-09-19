using UnityEngine;
using Zenject;
using Tools;

public class ShakeCameraOnWeaponAttack : MonoBehaviour
{
    private Transform _cameraTransform;

    [Inject]
    private void Constuct(HeadService headService)
    {
        _cameraTransform = headService.cameraTransform;
    }

    public void ReactOnAttack(ShakeCameraAnimationSO shakeAnimationConfig)
    {
        AnimationShortCuts.ShakePositionAnimation(_cameraTransform, shakeAnimationConfig.positionConfig);
        AnimationShortCuts.ShakeRotationAnimation(_cameraTransform, shakeAnimationConfig.rotationConfig);
    }
}