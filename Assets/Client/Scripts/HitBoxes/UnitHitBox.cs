using Unity.Properties;
using UnityEngine;

public class UnitHitBox : HitBox, IWeaponVisitor
{

    public void Visit(Saiga saiga)
    {
        RaycastVisit(saiga);
    }
    
    public void Visit(Automaton automaton)
    {
        RaycastVisit(automaton);
    }

    private void RaycastVisit(RaycastWeapon weapon)
    {
        _unit.TakeDamage(weapon.Damage);
    }
}