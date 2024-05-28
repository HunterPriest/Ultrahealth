using UnityEngine;

public abstract class Boss : Enemy
{
    [SerializeField] protected BossUnit bossUnit;

    protected override void OnValidate()
    {
        base.OnValidate();
        bossUnit = GetComponent<BossUnit>();
    }
    public abstract void Acivate();

    public abstract void SetPhase(float damage);
}