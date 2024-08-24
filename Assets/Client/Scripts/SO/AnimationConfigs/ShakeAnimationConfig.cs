using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Ultrahealth/AnimationConfigs/AnimationConfig")]
public class ShakeAnimationConfig : AnimationConfig
{
    public ShakeRandomnessMode randomnessMode = ShakeRandomnessMode.Full;
    public Vector3 strength;
    public float randomness = 90f;
    public float vibrato = 10f;
    public bool snapping;
}