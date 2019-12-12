namespace Assets.Scripts.Entities
{
    internal enum EShapeStatus
    {
        Empty,
        Moving,
        Stopped
    }

    internal enum EBoardStatus
    {
        Empty,
        Blank,
        Full
    }

    internal enum EBoardColumnStatus
    {
        Empty,
        Disabled,
        Available
    }

    public enum EShapeType
    {
        Empty,
        Normal,
        DangerGameOver,
    }

    public enum EShapePosition
    {
        Empty,
        Left,
        LeftCenter,
        Center,
        RightCenter,
        Right
    }

    public enum EShapeVelocity
    {
        Empty,
        Slow,
        Normal,
        Fast,
        VeryFast
    }

    public enum EConfigInterval
    {
        Empty,
        Slow,
        Normal,
        Fast,
        VeryFast
    }
}
