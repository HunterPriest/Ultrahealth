using System;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    [SerializeField] private Door[] _doors;
    [SerializeField] private EnemySpawner _spawner;

    private bool _isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if(!_isActive) 
        {
            return;
        }

        _isActive = false;

        foreach(Door door in _doors)
        {
            door.Block();
        }
        _spawner.Spawn();
    }

    public void UnblockDoors()
    {
        foreach (Door door in _doors)
        {
            door.Unblock();
        }
    }
}
