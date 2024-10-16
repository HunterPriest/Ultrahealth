using UnityEngine;

public abstract class Boss : Enemy
{
    [SerializeField] protected BossUnit bossUnit;

    protected override void StartStart()
    {
        base.StartStart();
        bossUnit = GetComponent<BossUnit>();
    }
    public abstract void Acivate();

    public abstract void SetPhase(float damage);
}