using UnityEngine;
using Zenject;

public class DeathBox : MonoBehaviour
{
    private Trigger _trigger;
    private PlayerHitBox _hitBox;

    [Inject]
    private void Construct(Player player)
    {
        _hitBox = player.HitBox;
    }

    private void Start()
    {
        _trigger = GetComponent<Trigger>();
        _trigger.OnEnter += () => _hitBox.Visit(10000);
    }
}
