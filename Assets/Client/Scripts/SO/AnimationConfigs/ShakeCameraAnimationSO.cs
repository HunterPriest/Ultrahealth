using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ShakeCameraAnimationSO")]
public class ShakeCameraAnimationSO : ScriptableObject
{
    [SerializeField] private ShakeAnimationConfig _positionConfig;
    [SerializeField] private ShakeAnimationConfig _rotationConfig;

    public ShakeAnimationConfig positionConfig => _positionConfig;
    public ShakeAnimationConfig rotationConfig => _rotationConfig;
}