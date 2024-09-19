using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ShakeAnimationSO")]
public class ShakeAnimationSO : ScriptableObject
{
    [SerializeField] private ShakeAnimationConfig _config;
    
    public ShakeAnimationConfig config => _config;
}