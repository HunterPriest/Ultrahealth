public class KillCounter
{
    public int amountKill { get; private set; }

    public void AddKill()
    {
        amountKill++;
    }
}