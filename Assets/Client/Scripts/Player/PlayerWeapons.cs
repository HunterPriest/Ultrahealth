using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Tools;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private GameObject[] _startedWeapons;

    private List<IPlayerWeapon> _weapons = new List<IPlayerWeapon>();
    private int _indexOfCurrentWeapon;
    private int _previousIndexWeapon;

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
        _weapons.Add(Instantiate(_startedWeapons[indexInArray], fpsRig).GetComponent<IPlayerWeapon>());
        _weapons[indexInArray].weapon.Initialize();
        if(_weapons[indexInArray] is RaycastWeapon)
        {
            RaycastWeapon raycastWeapon = _weapons[indexInArray].ConvertTo<RaycastWeapon>();
            raycastWeapon.SetDirection(fpsRig);
        }
        _weapons[indexInArray].OnPutAway += TakeWeapon;
        _weapons[indexInArray].weapon.gameObject.SetActive(stateWeapon);
    }
    
    public void Shoot()
    {
        _weapons[_indexOfCurrentWeapon].weapon.Attack();
    }

    public void ReloadWeapon()
    {
        _weapons[_indexOfCurrentWeapon].weapon.Reload();
    }

    public void ChooseWeapon(int indexWeapon)
    {
        if(indexWeapon - 1 == _indexOfCurrentWeapon || indexWeapon > _weapons.Count 
        || _weapons[_indexOfCurrentWeapon].weapon.GetState() == WeaponState.Take
        || _weapons[_indexOfCurrentWeapon].weapon.GetState() == WeaponState.PutAway)
        {
            return;
        }
        _weapons[_indexOfCurrentWeapon].weapon.RemoveWeapon();
        _previousIndexWeapon = _indexOfCurrentWeapon;
        _indexOfCurrentWeapon = indexWeapon -1;
    }

    private void TakeWeapon()
    {
        _weapons[_previousIndexWeapon].weapon.gameObject.SetActive(false);
        _weapons[_indexOfCurrentWeapon].weapon.gameObject.SetActive(true);
    }
}