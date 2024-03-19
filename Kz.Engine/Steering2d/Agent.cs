using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.Trigonometry;

namespace Kz.Engine.Steering2d
{
    public class Agent
    {
        private static Random _random = new Random();

        #region ctor

        private static uint CURRENT_ID = 0;
        public uint Id { get; init; }

        public Vector2f Acceleration;
        public Vector2f Velocity;
        public Vector2f Position;

        private Behaviors _behaviors = Behaviors.None;
        public Behaviors Behaviors => _behaviors;

        public float Size { get; private set; }
        public float HalfSize => Size / 2.0f;

        public Agent()
        {
            Id = CURRENT_ID++;
            Acceleration = Vector2f.Zero;
            Velocity = Vector2f.Zero;
            Position = Vector2f.Zero;
            Size = 1.0f;
            _behaviors = Behaviors.DEFAULT;
        }

        public Agent(Vector2f acceleration, Vector2f velocity, Vector2f position, float size)
        {
            Id = CURRENT_ID++;
            Acceleration = acceleration;
            Velocity = velocity;
            Position = position;
            Size = size;
            _behaviors = Behaviors.DEFAULT;
        }

        public Agent(Vector2f position, float size)
        {
            Id = CURRENT_ID++;
            Acceleration = Vector2f.Zero;
            Velocity = Vector2f.Zero;
            Position = position;
            Size = size;
            _behaviors = Behaviors.DEFAULT;
        }

        public override string ToString()
        {
            return $"Boid #{Id}: {Position}";
        }

        #endregion ctor

        #region Config Fields

        private float _neighborDistance = 200.0f;

        private float _mass = 1.0f;

        // maximum amount an agent can turn
        private float _maxTurningRate = TrigUtil.DegreesToRadians(5.0f);

        // maximum amount an agent can move
        private float _maxSpeed = 5.0f;

        public float MaxSpeed => _maxSpeed;

        // maximum force an agent can power itself
        private float _maxForce = 3.5f;

        #endregion Config Fields

        private Vector2f _steeringForce = Vector2f.Zero;

        public void Update
            (
            List<Agent> others,
            Rectangle aabb,
            Vector2f mousePosition,
            List<Circle> obstacles,
            List<Line> walls
        )
        {
            var neighbors = GetNeighbors(others);

            var config = new BehaviorForceConfig
            {
                Neighbors = neighbors,
                Obstacles = obstacles,
                Walls = walls,
            };

            _steeringForce = BehaviorManager.CalculateSteeringForce(this, config);

            // acceleration = force / mass
            Acceleration = (_steeringForce / _mass).LimitMagnitude(_maxForce);

            // constrain changes in velocity to maxTurningAngle and maxVelocity
            var newVelocity = Velocity + Acceleration;
            Velocity = Vector2f
                .LimitAngleDelta(Velocity, newVelocity, _maxTurningRate)
                .LimitMagnitude(_maxSpeed);
            Position += Velocity;

            // bound to aabb
            if (Position.X < aabb.Position.X + HalfSize) Position.X = aabb.Position.X + aabb.Size.X + HalfSize;
            else if (Position.X > aabb.Position.X + aabb.Size.X + HalfSize) Position.X = aabb.Position.X + HalfSize;
            if (Position.Y < aabb.Position.Y + HalfSize) Position.Y = aabb.Position.Y + aabb.Size.Y + HalfSize;
            else if (Position.Y > aabb.Position.Y + aabb.Size.Y + HalfSize) Position.Y = aabb.Position.Y + HalfSize;

            EnforceNonPenetrationConstraint(neighbors);
        }

        private Raylib_cs.Color _color = new Raylib_cs.Color(80, 148, 82, 255);

        public void Render(List<Agent> others)
        {
            // render agent
            Raylib_cs.Raylib.DrawCircle((int)Position.X, (int)Position.Y, Size, _color);

            // render direction vector
            var theta = Velocity.AngleOf();
            var xx = Position.X + MathF.Cos(theta) * Size * 2.0f;
            var yy = Position.Y + MathF.Sin(theta) * Size * 2.0f;
            Raylib_cs.Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)xx, (int)yy, Raylib_cs.Color.RayWhite);
        }

        public Line GetDetectionLine()
        {
            var angle = Velocity.AngleOf();

            var maxDetectionLength = 500.0f;
            var detectionLength = (Velocity.Magnitude2() / (MaxSpeed * MaxSpeed)) * maxDetectionLength;

            var point = new Vector2f(
                Position.X + MathF.Cos(angle) * detectionLength,
                Position.Y + MathF.Sin(angle) * detectionLength);

            return new Line(Position.X, Position.Y, point.X, point.Y);
        }

        public List<Line> GetFeelers()
        {
            var angle = Velocity.AngleOf();
            var offsetAngle = TrigUtil.DegreesToRadians(25);

            var middleDetectionLength = Size * 20.0f;
            var sideDetectionLength = Size * 10.0f;

            var middle = new Vector2f
            (
                Position.X + MathF.Cos(angle) * middleDetectionLength,
                Position.Y + MathF.Sin(angle) * middleDetectionLength
            );

            var left = new Vector2f
            (
                Position.X + MathF.Cos(angle - offsetAngle) * sideDetectionLength,
                Position.Y + MathF.Sin(angle - offsetAngle) * sideDetectionLength
            );

            var right = new Vector2f
            (
                Position.X + MathF.Cos(angle + offsetAngle) * sideDetectionLength,
                Position.Y + MathF.Sin(angle + offsetAngle) * sideDetectionLength
            );

            var feelers = new List<Line>();
            feelers.Add(new Line(Position.X, Position.Y, middle.X, middle.Y));
            feelers.Add(new Line(Position.X, Position.Y, left.X, left.Y));
            feelers.Add(new Line(Position.X, Position.Y, right.X, right.Y));

            return feelers;
        }

        public void Cleanup()
        {
        }

        #region Private Methods

        private List<Agent> GetNeighbors(List<Agent> others)
        {
            var neighbors = new List<Agent>();
            foreach (var agent in others)
            {
                if (agent == this) continue;

                var distance = (this.Position - agent.Position).Magnitude();
                if (distance > _neighborDistance) continue;

                neighbors.Add(agent);
            }
            return neighbors;
        }

        public void EnforceNonPenetrationConstraint(List<Agent> neighbors)
        {
            foreach (var neighbor in neighbors)
            {
                var toAgent = Position - neighbor.Position;
                var dist = toAgent.Magnitude();
                var overlap = Size + neighbor.Size - dist;
                if (overlap > 0)
                {
                    Position += ((toAgent / dist) * overlap);
                }
            }
        }

        #endregion Private Methods
    }
}