using UnityEngine;

public interface IWeaponVisitor
{
    public void Visit(Saiga saiga);
    public void Visit(Automaton automaton);
}