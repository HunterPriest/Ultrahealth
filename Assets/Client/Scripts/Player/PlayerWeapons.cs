using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Tools;
using UnityEngine.Rendering;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private GameObject[] _startedWeapons;
    [SerializeField] private Transform _parentWeapons;
    [SerializeField] private ShakeCameraOnWeaponAttack shakeCameraOnWeaponAttack;
    
    private List<PlayerWeapon> _weapons = new List<PlayerWeapon>();
    private int _indexOfCurrentWeapon;
    private int _previousIndexWeapon;

    public void Initialize()
    {
        SpawnWeapon(_indexOfCurrentWeapon, _parentWeapons, true);

        for(int i = 1; i < _startedWeapons.Length; i++)
        {
            SpawnWeapon(i, _parentWeapons, false);
        }
    }

    private void SpawnWeapon(int indexInArray, Transform fpsRig, bool stateWeapon)
    {
        _weapons.Add(Instantiate(_startedWeapons[indexInArray], fpsRig).GetComponent<PlayerWeapon>());
        _weapons[indexInArray].Initialize();
        _weapons[indexInArray].onPutAway += TakeWeapon;
        _weapons[indexInArray].onShoot += shakeCameraOnWeaponAttack.ReactOnAttack;
        _weapons[indexInArray].gameObject.SetActive(stateWeapon);
    }
    
    public void Shoot()
    {
        _weapons[_indexOfCurrentWeapon].Attack();
    }

    private void OnDisable()
    { 
        for(int i = 0; i < _startedWeapons.Length; i++)
        {
            _weapons[i].onPutAway -= TakeWeapon;
            _weapons[i].onShoot -= shakeCameraOnWeaponAttack.ReactOnAttack;
        }
    }

    public void ChooseWeapon(int indexWeapon)
    {
        if(indexWeapon - 1 == _indexOfCurrentWeapon || indexWeapon > _weapons.Count 
        || _weapons[_indexOfCurrentWeapon].GetState() == WeaponState.Take
        || _weapons[_indexOfCurrentWeapon].GetState() == WeaponState.PutAway)
        {
            return;
        }
        _weapons[_indexOfCurrentWeapon].RemoveWeapon();
        _previousIndexWeapon = _indexOfCurrentWeapon;
        _indexOfCurrentWeapon = indexWeapon -1;
    }

    private void TakeWeapon()
    {
        _weapons[_previousIndexWeapon].gameObject.SetActive(false);
        _weapons[_indexOfCurrentWeapon].gameObject.SetActive(true);
    }
}