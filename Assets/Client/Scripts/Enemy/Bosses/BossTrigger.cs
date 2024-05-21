using System.Reflection.Emit;
using UnityEngine;
using Zenject;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private Boss _boss;

    private Transform _transformPlayer;

    [Inject]
    private void Construct(Player player)
    {
        _transformPlayer = player.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerHitBox>(out PlayerHitBox playerHitBox))
        {
            _boss.Acivate();
        }
    }
}