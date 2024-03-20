namespace Tools
{
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
        Shoot, 
        Idle
    }
}
