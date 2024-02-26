using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponAnimations _weaponAnimations;

    public void Reload()
    {
        _weaponAnimations.Reload();
    }
}