namespace Tools
{
    public enum EnemyState
    {
        Moving, 
        Idle, 
        Attacking
    }

    public enum PlayerState
    {
        Moving,
        Idle
    }

    public enum GameState
    {
        Bootstrap, 
        Initialize,
        Menu, 
        Map,
        LoadGame,
        Game, 
        Pause
    }

    public enum WeaponState
    {
        Reload, 
        Attack, 
        Idle
    }
}
