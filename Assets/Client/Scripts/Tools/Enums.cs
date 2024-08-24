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
        Pause, 
        Death
    }

    public enum WeaponState
    {
        Reload, 
        Attack, 
        Idle,
        Take,
        PutAway
    }

    public enum ClassesOfPlayer
    {
        Bacterium = 0,
        NanoRobot = 1,
        SingleCell = 2
    }

    public enum WeaponsTypes
    {
        Overlap,
        Raycast, 
        Projectile
    }

    public enum LevelGrade
    {
        S,
        A,
        B,
        C,
        D
    }
}
