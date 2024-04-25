using UnityEngine;

public class HeartValueOpener : MonoBehaviour
{
    [SerializeField] private Collider[] _heartValueColliderRight;
    [SerializeField] private Collider[] _heartValueColliderLeft;

    public void OpenRight()
    {
        foreach(Collider collider in _heartValueColliderRight)
        {
            collider.enabled = false;
        }
        print("OpenRight");
    }

    public void CloseRight()
    {
        foreach(Collider collider in _heartValueColliderRight)
        {
            collider.enabled = true;
        }
        print("CloseRight");
    }

        public void OpenLeft()
    {
        foreach(Collider collider in _heartValueColliderLeft)
        {
            collider.enabled = false;
        }
        print("OpenLeft");
    }

    public void CloseLeft()
    {
        foreach(Collider collider in _heartValueColliderLeft)
        {
            collider.enabled = true;
        }
        print("CloseLeft");
    }

}