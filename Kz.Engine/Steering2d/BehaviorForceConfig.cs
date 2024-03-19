using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;

namespace Kz.Engine.Steering2d
{
    public struct BehaviorForceConfig
    {
        public float WanderDistance = 50.0f;
        public float WanderRadius = 175.0f;

        public Vector2f SeekTarget = Vector2f.Zero;

        public Vector2f FleeTarget = Vector2f.Zero;
        public float? FleeDistance = null;

        public Vector2f ArriveTarget = Vector2f.Zero;
        public Deceleration ArriveDeceleration = Deceleration.Normal;

        public Agent PursueTarget = null!;

        public Agent EvadeOther = null!;

        public Circle Obstacle = null!;
        public List<Circle> Obstacles = new List<Circle>();

        public Vector2f HideFrom = Vector2f.Zero;
        public float? HideFromDistance = null;

        public List<Line> Walls = new List<Line>();

        public List<Agent> Neighbors = new List<Agent>();

        public BehaviorForceConfig()
        {
        }
    }
}