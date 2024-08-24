using UnityEngine;

public class HeadService
{
    public Transform cameraTransform { get; }
    public Transform weaponTransform { get; }
    public Transform fpsRig { get; }

    public HeadService(Transform cameraTransform, Transform weaponTransform, Transform fpsRig)
    {
        this.cameraTransform = cameraTransform;
        this.fpsRig = fpsRig;
        this.weaponTransform = weaponTransform;
    }
}