using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private Weapon[] _startedWeapons;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _indexOfCurrentWeapon;

    public void Initialize(Transform fpsRig)
    {
        _weapons.Add(Instantiate(_startedWeapons[_indexOfCurrentWeapon], fpsRig.position, Quaternion.identity, fpsRig).GetComponent<Weapon>());
        _weapons[_indexOfCurrentWeapon].gameObject.SetActive(true);

        for(int i = 1; i < _startedWeapons.Length; i++)
        {
            _weapons.Add(Instantiate(_startedWeapons[i], fpsRig.position, Quaternion.identity, fpsRig).GetComponent<Weapon>());
            _weapons[i].gameObject.SetActive(false);
        }
    }

    public void AddWeapon(Weapon _weapon)
    {
        
    }

    public void Shoot()
    {
        
    }

    public void ReloadWeapon()
    {
        _weapons[_indexOfCurrentWeapon].Reload();
    }

    public void ChooseWeapon(int indexWeapon)
    {
        _weapons[_indexOfCurrentWeapon].gameObject.SetActive(false);
        _indexOfCurrentWeapon = indexWeapon - 1;
        _weapons[_indexOfCurrentWeapon].gameObject.SetActive(true);
    }
}