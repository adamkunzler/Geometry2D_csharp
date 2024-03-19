namespace Kz.Engine.Steering2d
{
    [Flags]
    public enum Behaviors
    {
        None = 0,
        Wander = 1 << 1,
        Seek = 1 << 2,
        Flee = 1 << 3,
        Arrive = 1 << 4,
        Pursue = 1 << 5,
        Evade = 1 << 6,
        AvoidObstacle = 1 << 7,
        AvoidObstacles = 1 << 8,
        HideFrom = 1 << 9,
        AvoidWalls = 1 << 10,
        Separation = 1 << 11,
        Alignment = 1 << 12,
        Cohesion = 1 << 13,
        
        DEFAULT = Wander | Separation | Cohesion | Alignment |
                  AvoidWalls | AvoidObstacles
    }
}