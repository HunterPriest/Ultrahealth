using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;

    private List<Weapon> _weapons = new List<Weapon>();

    private Automaton _automaton;

    public void Initialize()
    {
        _weapons.Add(_automaton);
    }

    public void AddWeapon(Weapon _weapon)
    {
        
    }

    public void Shoot()
    {
        
    }

    public void RechargeWeapon()
    {
        _playerAnimations.Recharge();
    }
}