using Kz.Engine.DataStructures;
using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.Raylib;
using Kz.Engine.Trigonometry;
using Raylib_cs;

namespace Kz.Steering.Demo
{
    public class Agent
    {
        private static Random _random = new Random();

        #region ctor

        private static uint CURRENT_ID = 0;
        public uint Id { get; init; }

        public Vector2f Acceleration { get; private set; }
        public Vector2f Velocity { get; private set; }
        public Vector2f Position { get; private set; }

        public float Size { get; private set; }
        public float HalfSize => Size / 2.0f;

        public Agent()
        {
            Id = CURRENT_ID++;
            Acceleration = Vector2f.Zero;
            Velocity = Vector2f.Zero;
            Position = Vector2f.Zero;
            Size = 1.0f;
        }

        public Agent(Vector2f acceleration, Vector2f velocity, Vector2f position, float size)
        {
            Id = CURRENT_ID++;
            Acceleration = acceleration;
            Velocity = velocity;
            Position = position;
            Size = size;
        }

        public Agent(Vector2f position, float size)
        {
            Id = CURRENT_ID++;
            Acceleration = Vector2f.Zero;
            Velocity = Vector2f.Zero;
            Position = position;
            Size = size;
        }

        public override string ToString()
        {
            return $"Boid #{Id}: {Position}";
        }

        #endregion ctor

        #region Fields

        private float _neighbordDistance = 200.0f;

        private float _mass = 1.0f;

        // maximum amount an agent can turn
        private float _maxTurningRate = TrigUtil.DegreesToRadians(5.0f);

        // maximum amount an agent can move
        private float _maxSpeed = 5.0f;

        public float MaxSpeed => _maxSpeed;

        // maximum force an agent can power itself
        private float _maxForce = 3.5f;

        #endregion Fields

        private Vector2f _steeringForce = Vector2f.Zero;
        private List<Circle> _obstacles = new List<Circle>();

        public void Update
            (
            List<Agent> others,
            Kz.Engine.Geometry2d.Primitives.Rectangle aabb,
            Vector2f mousePosition,
            List<Circle> obstacles,
            List<Line> walls
        )
        {
            _obstacles = obstacles;
            // Get Neighbors
            var neighbors = GetNeighbors(others);

            // calculate individual rules            
            var seekForce = Id == 0 ?  Behaviors.Seek(this, mousePosition) : Vector2f.Zero;
            var fleeForce = Vector2f.Zero;// Behaviors.Flee(this, mousePosition, 500.0f);
            var arriveForce = Vector2f.Zero;// Behaviors.Arrive(this, mousePosition, Deceleration.Slow);
            var pursueForce = Vector2f.Zero;
            var evadeForce = Vector2f.Zero;
            var wanderForce = Id == 0 ? Vector2f.Zero : Behaviors.Wander(this);
            var avoidObstacleForce = Behaviors.AvoidObstacles(this, obstacles);
            var hidingForce = Vector2f.Zero;// Behaviors.HideFrom(this, mousePosition, obstacles);
            var avoidWallForce = Vector2f.Zero;// Behaviors.AvoidWalls(this, walls);

            // calculate group rules
            var separationForce = Id == 0 ? Vector2f.Zero : Behaviors.Separation(this, neighbors);
            var alignmentForce = Id == 0 ? Vector2f.Zero : Behaviors.Alignment(this, neighbors);
            var cohesionForce = Id == 0 ? Vector2f.Zero : Behaviors.Cohesion(this, neighbors);


            //if(Id == 0)
            //{
            //    pursueForce = Behaviors.Pursue(this, others[1]);
            //}
            //else if (Id == 1)
            //{
            //    evadeForce = Behaviors.Evade(this, others[0]);
            //}

            // combined force of all steering behaviours
            var totalSteeringForce =
                seekForce + (fleeForce * 3.0f) + arriveForce +
                pursueForce + evadeForce + wanderForce +
                avoidObstacleForce + hidingForce + avoidWallForce;

            totalSteeringForce += separationForce + alignmentForce + cohesionForce;

            _steeringForce = totalSteeringForce; // for debugging/rendering

            // acceleration = force / mass
            Acceleration = (totalSteeringForce / _mass).LimitMagnitude(_maxForce);

            var newVelocity = Velocity + Acceleration;

            // constrain changes in velocity to maxTurningAngle and maxVelocity
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

        public void Render(List<Agent> others)
        {
            // render agent
            Raylib.DrawCircle((int)Position.X, (int)Position.Y, Size, Color.DarkGreen);

            // render direction vector
            var theta = Velocity.AngleOf();
            var xx = Position.X + MathF.Cos(theta) * Size * 2.0f;
            var yy = Position.Y + MathF.Sin(theta) * Size * 2.0f;
            Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)xx, (int)yy, Color.RayWhite);
            
            // special case: agent #0
            if (Id == 0 && true)
            {
                // render neighborDistance
                Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, _neighbordDistance, Color.RayWhite);

                // render neighbors
                foreach (var neighbor in GetNeighbors(others))
                {
                    Raylib.DrawCircleLines((int)neighbor.Position.X, (int)neighbor.Position.Y, Size * 1.2f, Color.RayWhite);
                }

                // steering force
                var steeringForce = _steeringForce * Size;
                Raylib.DrawLine(
                    (int)Position.X, (int)Position.Y,
                    (int)Position.X + (int)steeringForce.X,
                    (int)Position.Y + (int)steeringForce.Y,
                    Color.Red);

                // detection line
                var detectionLine = GetDetectionLine();
                Gfx.DrawLine(detectionLine, Color.RayWhite);

                var feelers = GetFeelers();
                foreach(var feeler in feelers) 
                {
                    Gfx.DrawLine(feeler, Color.Purple);
                }
            }
        }

        public Line GetDetectionLine()
        {
            var angle = Velocity.AngleOf();

            var maxDetectionLength = 500.0f;
            var detectionLength = (Velocity.Magnitude2() / (MaxSpeed * MaxSpeed)) * maxDetectionLength;

            var point = new Point(
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
            
            var middle = new Point
            (
                Position.X + MathF.Cos(angle) * middleDetectionLength,
                Position.Y + MathF.Sin(angle) * middleDetectionLength
            );

            var left = new Point
            (
                Position.X + MathF.Cos(angle - offsetAngle) * sideDetectionLength,
                Position.Y + MathF.Sin(angle - offsetAngle) * sideDetectionLength
            );

            var right = new Point
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
                if (distance > _neighbordDistance) continue;

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