using UnityEngine;

public class HeartValueOpener : MonoBehaviour
{
    [SerializeField] private MeshCollider _heartValueColliderRight;
    [SerializeField] private SkinnedMeshRenderer _heartValueMeshRight;
    [SerializeField] private MeshCollider _heartValueColliderLeft;
    [SerializeField] private SkinnedMeshRenderer _heartValueMeshLeft;

    public void OpenRight()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.sharedMesh = null;
        _heartValueColliderRight.sharedMesh = skinnedMeshRenderer.sharedMesh;
    }

    public void CloseRight()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.sharedMesh = null;
        _heartValueColliderRight.sharedMesh = skinnedMeshRenderer.sharedMesh;
    }

    public void OpenLeft()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.sharedMesh = null;
        _heartValueColliderLeft.sharedMesh = skinnedMeshRenderer.sharedMesh;
    }

    public void CloseLeft()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.sharedMesh = null;
        _heartValueColliderLeft.sharedMesh = skinnedMeshRenderer.sharedMesh;
    }

}