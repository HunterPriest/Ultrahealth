using System.Reflection.Emit;
using UnityEngine;
using Zenject;

public class BossTrigger : MonoBehaviour
{
    private Boss _boss;
    private Transform _transformPlayer;

    [Inject]
    private void Construct(Player player, Level level)
    {
        _transformPlayer = player.transform;
        _boss = level.boss;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerHitBox>(out PlayerHitBox playerHitBox))
        {
            _boss.Acivate();
            Destroy(gameObject);
        }
    }
}