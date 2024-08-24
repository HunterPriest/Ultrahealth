using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Ultrahealth/AnimationConfigs/AnimationConfig")]
public class AnimationConfig : ScriptableObject
{
    public bool isOn = true;
    public float duration = 1f;
    public Ease ease = DOTween.defaultEaseType;
}