using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ShakeCameraAnimationConfig")]
public class ShakeCameraAnimationConfig : ScriptableObject
{
    [SerializeField] private ShakeAnimationConfig _positionConfig;
    [SerializeField] private ShakeAnimationConfig _rotationConfig;

    public ShakeAnimationConfig positionConfig => _positionConfig;
    public ShakeAnimationConfig rotationConfig => _rotationConfig;
}