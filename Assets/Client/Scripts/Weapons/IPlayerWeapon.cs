using System;
using UnityEngine;

public interface IPlayerWeapon
{
    Action OnPutAway { get; set; }
    Weapon weapon { get; set; }

    protected void FinishPutAway();
}