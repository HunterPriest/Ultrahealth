using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] private Level _level;

    private void OnTriggerEnter(Collider collider)
    {
        _level.CompleteLevel();
    }
}