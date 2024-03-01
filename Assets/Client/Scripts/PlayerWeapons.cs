using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private Weapon[] _startedWeapons;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _indexOfCurrentWeapon;

    public void Initialize(Transform fpsRig)
    {
        SpawnWeapon(_indexOfCurrentWeapon, fpsRig, true);

        for(int i = 1; i < _startedWeapons.Length; i++)
        {
            SpawnWeapon(i, fpsRig, false);
        }
    }

    private void SpawnWeapon(int indexInArray, Transform fpsRig, bool stateWeapon)
    {
        _weapons.Add(Instantiate(_startedWeapons[indexInArray], fpsRig.position, Quaternion.identity, fpsRig).GetComponent<Weapon>());
        _weapons[indexInArray].Initialize();
        _weapons[indexInArray].gameObject.SetActive(stateWeapon);
    }

    public void AddWeapon(Weapon _weapon)
    {
        
    }

    public void Shoot()
    {
        _weapons[_indexOfCurrentWeapon].Shoot();
    }

    public void ReloadWeapon()
    {
        _weapons[_indexOfCurrentWeapon].Reload();
    }

    public void ChooseWeapon(int indexWeapon)
    {
        _weapons[_indexOfCurrentWeapon].gameObject.SetActive(false);
        _weapons[_indexOfCurrentWeapon].RemoveWeapon();
        _indexOfCurrentWeapon = indexWeapon - 1;
        _weapons[_indexOfCurrentWeapon].gameObject.SetActive(true);
    }
}