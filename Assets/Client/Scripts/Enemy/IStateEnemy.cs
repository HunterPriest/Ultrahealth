using Tools;

public interface IStateEnemy
{
    public void Enter();
    public void Loop();
    public void Exit();
    public bool StateCompleted();
}