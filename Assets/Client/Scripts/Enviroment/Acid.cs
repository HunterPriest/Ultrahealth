using UnityEngine;
using Zenject;
using Tools;

public class Acid : MonoBehaviour
{
    [SerializeField] private float _damagePerSec;

    private float _currentTime = 0;
    private PlayerHitBox _hitBox;   
    private bool _playerInTrigger;

    [Inject]
    private void Construct(Player player)
    {   
        print(player.HitBox);
        _hitBox = player.HitBox;
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

    private void OnTriggerEnter(Collider other) 
    {
        _playerInTrigger = true;
    }

    private void OnTriggerStay(Collider other) 
    {
        _playerInTrigger = false;
    }
}
