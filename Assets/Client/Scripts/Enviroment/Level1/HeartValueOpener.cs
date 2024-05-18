using UnityEngine;

public class HeartValueOpener : MonoBehaviour
{
    [SerializeField] private MeshCollider _heartValueColliderRight;
    [SerializeField] private SkinnedMeshRenderer _heartValueMeshRight;
    [SerializeField] private MeshCollider _heartValueColliderLeft;
    [SerializeField] private SkinnedMeshRenderer _heartValueMeshLeft;

    public void OpenRight()
    {
        _heartValueColliderRight.sharedMesh = null;
        _heartValueColliderRight.sharedMesh = _heartValueMeshRight.sharedMesh;
    }

    public void CloseRight()
    {
        _heartValueColliderRight.sharedMesh = null;
        _heartValueColliderRight.sharedMesh = _heartValueMeshRight.sharedMesh;
    }

    public void OpenLeft()
    {
        _heartValueColliderLeft.sharedMesh = null;
        _heartValueColliderLeft.sharedMesh = _heartValueMeshLeft.sharedMesh;
    }

    public void CloseLeft()
    {
        _heartValueColliderLeft.sharedMesh = null;
        _heartValueColliderLeft.sharedMesh = _heartValueMeshLeft.sharedMesh;
    }

}