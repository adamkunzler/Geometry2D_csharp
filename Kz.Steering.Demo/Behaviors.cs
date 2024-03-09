using Kz.Engine.DataStructures;
using Kz.Engine.General;
using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.Geometry2d.Utils;

namespace Kz.Steering.Demo
{
    public enum Deceleration
    {
        Fast = 1,
        Normal = 2,
        Slow = 3,
    }

    public static class Behaviors
    {
        private static Random _random = new Random();

        /// <summary>
        /// Calculate a steering force for an agent to move towards. The point is calculated by
        /// choosing a random point on a circle that's ahead of the agent.
        /// </summary>
        /// <param name="distance">distance of the circle in front of the agent</param>
        /// <param name="radius">radius of the circle</param>
        public static Vector2f Wander(Agent agent, float distance = 50.0f, float radius = 175.0f)
        {
            // choose random point on a circle
            var target = new Vector2f
            (
                Utils.RandomNegOnetoPosOne(_random),
                Utils.RandomNegOnetoPosOne(_random)
            ).Normal() * radius;

            // move target ahead of agent
            var wanderTarget = agent.Position + target + (agent.Velocity * distance);

            var force = (wanderTarget - agent.Position).Normal() * agent.MaxSpeed;
            return force;
        }

        /// <summary>
        /// Create a steering force from an agent to a target
        /// </summary>
        public static Vector2f Seek(Agent agent, Vector2f target)
        {
            var desiredVelocity = (target - agent.Position).Normal() * agent.MaxSpeed;
            var steeringForce = desiredVelocity - agent.Velocity;
            return steeringForce;
        }

        /// <summary>
        /// Create a steering force to move an agent away from a target.
        ///
        /// Optionally allows setting a distance value so that the agent only
        /// flees if they are within a certain distance.
        /// </summary>
        public static Vector2f Flee(Agent agent, Vector2f target, float? distance = null)
        {
            var targetToPosition = agent.Position - target;
            if (distance.HasValue && targetToPosition.Magnitude2() > (distance.Value * distance.Value))
                return Vector2f.Zero;

            var desiredVelocity = targetToPosition.Normal() * agent.MaxSpeed;
            var steeringForce = desiredVelocity - agent.Velocity;
            return steeringForce;
        }

        /// <summary>
        /// Create a steering force that approaches a target and then stops at a specified deceleration
        /// </summary>
        public static Vector2f Arrive(Agent agent, Vector2f target, Deceleration deceleration)
        {
            var toTarget = target - agent.Position;
            var distance = toTarget.Magnitude();
            if (Utils.EpsilonEquals(distance, 0.0f)) return Vector2f.Zero; // we've arrived!

            // convert deceleration to float
            var decelerationConversionAmount = 20.0f;
            var speed = distance / ((float)deceleration * decelerationConversionAmount);
            speed = MathF.Min(speed, agent.MaxSpeed);

            var desiredVelocity = toTarget * speed / distance;
            var steeringForce = desiredVelocity - agent.Velocity;
            return steeringForce;
        }

        /// <summary>
        /// Create a steering force towards an interception point with a moving target
        /// </summary>
        public static Vector2f Pursue(Agent agent, Agent target)
        {
            //
            // if agent is ahead and facing the target, seek to the target position
            //

            var toTarget = target.Position - agent.Position;

            // figure out if agent is facing target and in front of the target
            var relativeHeading = Vector2f.Dot(agent.Velocity.Normal(), target.Velocity.Normal());
            var acos0point95 = -0.95; // acos(0.95) = 18deg
            var isFacing = relativeHeading < -acos0point95;
            var isInFront = toTarget.Dot(agent.Velocity.Normal()) > 0;

            if (isInFront && isFacing)
            {
                return Seek(agent, target.Position);
            }

            //
            // not directly ahead of target, seek to an interception offset
            //
            var lookAheadTime = toTarget.Magnitude() / (agent.MaxSpeed + target.Velocity.Magnitude());
            var interceptPoint = target.Position + target.Velocity * lookAheadTime;
            return Seek(agent, interceptPoint);
        }

        /// <summary>
        /// Calculate a steering force away from another agent
        /// </summary>
        public static Vector2f Evade(Agent agent, Agent other)
        {
            var toOther = other.Position - agent.Position;

            var lookAheadTime = toOther.Magnitude() / (agent.MaxSpeed + other.Velocity.Magnitude());
            var predictedFuturePoint = other.Position + other.Velocity * lookAheadTime;
            return Flee(agent, predictedFuturePoint);
        }
        
        /// <summary>
        /// Calculate a steering force away from a group of obstacles
        /// </summary>        
        public static Vector2f AvoidObstacles(Agent agent, List<Circle> obstacles)
        {
            var force = Vector2f.Zero;

            foreach (var obstacle in obstacles)
            {
                force += AvoidObstacle(agent, obstacle);
            }

            return force;
        }

        /// <summary>
        /// Calculate a steering force away from an obstacle
        /// </summary>
        public static Vector2f AvoidObstacle(Agent agent, Circle obstacle)
        {
            var force = Vector2f.Zero;
            
            var minIntersection = GetClosestIntersectionPoint(agent, obstacle);
            if (minIntersection == null) return force;
            
            var avoidanceDirection = (minIntersection - obstacle.Origin);
            var avoidanceStrength = 1.0f;

            return avoidanceDirection * avoidanceStrength;
        }

        public static Vector2f HideFrom(Agent agent, Vector2f hideFrom, List<Circle> obstacles)
        {
            var hidingSpots = GetHidingSpots(hideFrom, obstacles);
            if (hidingSpots.Count == 0) return Vector2f.Zero;

            // ??? how to choose which spot...current is choose closest
            var minDist = float.MaxValue;
            Point bestSpot = null!;
            foreach(var spot in hidingSpots)
            {
                var dist = (spot - agent.Position).Magnitude2();
                if (dist < minDist)
                {
                    minDist = dist;
                    bestSpot = spot;
                }
            }
                        
            var force = Arrive(agent, bestSpot, Deceleration.Fast);
            return force;
        }

        #region Private Helper Methods

        public static List<Point> GetHidingSpots(Vector2f hideFrom, List<Circle> obstacles)
        {
            var hidingSpots = obstacles.Select(x => GetHidingSpot(hideFrom, x)).ToList();
            return hidingSpots;
        }

        private static Point GetHidingSpot(Vector2f hideFrom, Circle obstacle)
        {
            var toObstacle = obstacle.Origin - hideFrom;
            var distFromObstacle = 100.0f + obstacle.Radius + toObstacle.Magnitude();            
            var hidingSpot = hideFrom + (toObstacle.Normal() * distFromObstacle);
            return new Point(hidingSpot);
        }

        /// <summary>
        /// Get the closest intersection point with an obstacle to an agent
        /// </summary>        
        private static Point? GetClosestIntersectionPoint(Agent agent, Circle obstacle)
        {
            // check for intersections
            var detectionLine = agent.GetDetectionLine();
            var intersections = G2d.Intersects(detectionLine, obstacle);
            if (intersections.Count == 0) return null;

            // closest intersection point
            var minDist = float.MaxValue;
            var minIntersection = intersections[0];
            foreach (var intersection in intersections)
            {
                var dist = (agent.Position - intersection).Magnitude();
                if (dist < minDist)
                {
                    minDist = dist;
                    minIntersection = intersection;
                }
            }

            return minIntersection;
        }

        #endregion Private Helper Methods
    }
}