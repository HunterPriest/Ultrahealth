using UnityEngine;
using Zenject;

public class EndScene : MonoBehaviour
{
    [Inject] private Level _level;

    private void OnTriggerEnter(Collider collider)
    {
        _level.CompleteLevel();
    }
}