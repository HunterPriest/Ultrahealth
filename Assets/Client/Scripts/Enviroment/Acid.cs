using UnityEngine;
using Zenject;
using Tools;

public class Acid : MonoBehaviour
{
    [SerializeField] private float _damagePerSec;

    private float _currentTime = 0;
    private PlayerHitBox _hitBox;   
    private bool _playerInTrigger = false;
    private Trigger _trigger;

    private void Start()
    {
        _trigger = GetComponent<Trigger>();
        _trigger.OnEnter += playerEnter;
        _trigger.OnExit += playerExit;
    }

    [Inject]
    private void Construct(Player player)
    {   
        print(player.HitBox);
        _hitBox = player.HitBox;
    }

    private void playerEnter()
    {
        _playerInTrigger = true;
    }

    private void playerExit()
    {
        _playerInTrigger = false;
    }

    private void Update() 
    {

        if(_playerInTrigger == true)   
        {
            _currentTime += Time.deltaTime;

            if(_currentTime >= 1.0f)
            {
                _currentTime = 0;
                _hitBox.Visit(_damagePerSec);
            }
        }
    }
}
