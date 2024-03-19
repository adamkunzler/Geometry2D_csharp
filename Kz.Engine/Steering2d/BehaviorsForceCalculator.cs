using Kz.Engine.DataStructures;
using Kz.Engine.General;
using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.Geometry2d.Utils;

namespace Kz.Engine.Steering2d
{
    public enum Deceleration
    {
        Fast = 1,
        Normal = 2,
        Slow = 3,
    }

    public static class BehaviorsForceCalculator
    {
        private static Random _random = new Random();

        #region Individual Behaviors

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
            if (target == null) return Vector2f.Zero;
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
            if (other == null) return Vector2f.Zero;

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
            if (obstacle == null) return Vector2f.Zero;

            var force = Vector2f.Zero;

            var minIntersection = GetClosestIntersectionPoint(agent, obstacle);
            if (minIntersection == null) return force;

            var avoidanceDirection = (minIntersection.Value - obstacle.Origin);
            var avoidanceStrength = 1.0f;

            return avoidanceDirection * avoidanceStrength;
        }

        /// <summary>
        /// Calculate a steering force to a position that puts an obstacle in between the agent and the position to hide from
        /// </summary>
        public static Vector2f HideFrom(Agent agent, Vector2f hideFrom, List<Circle> obstacles, float? distance = null)
        {
            var targetToPosition = agent.Position - hideFrom;
            if (distance.HasValue && targetToPosition.Magnitude2() > (distance.Value * distance.Value))
                return Vector2f.Zero;

            var hidingSpots = GetHidingSpots(hideFrom, obstacles);
            if (hidingSpots.Count == 0) return Vector2f.Zero;

            // ??? how to choose which spot...current is choose closest
            var minDist = float.MaxValue;
            Vector2f bestSpot = Vector2f.Zero; // maybe a better default
            var foundSpot = false;
            foreach (var spot in hidingSpots)
            {
                var dist = (spot - agent.Position).Magnitude2();
                if (dist < minDist)
                {
                    minDist = dist;
                    bestSpot = spot;
                    foundSpot = true;
                }
            }

            if (!foundSpot) return Vector2f.Zero;

            var force = Arrive(agent, bestSpot, Deceleration.Fast);
            return force;
        }

        /// <summary>
        /// Calculate a steering force away from a wall(s)
        /// </summary>
        public static Vector2f AvoidWalls(Agent agent, List<Line> walls)
        {
            var force = Vector2f.Zero;

            var feelers = agent.GetFeelers();

            var closestDistance = float.MaxValue;
            Vector2f closestIntersectionPoint = Vector2f.Zero;
            var foundClosestIntersectionPoint = false;
            Line? closestWall = null;
            Line? intersectedFeeler = null;

            // find the closest intersection point and wall to the agent
            foreach (var feeler in feelers)
            {
                foreach (var wall in walls)
                {
                    var intersection = G2d.Intersects(feeler, wall);
                    if (intersection.Count > 0)
                    {
                        var dist = (intersection[0] - agent.Position).Magnitude();
                        if (dist < closestDistance)
                        {
                            closestDistance = dist;
                            closestIntersectionPoint = intersection[0];
                            closestWall = wall;
                            intersectedFeeler = feeler;
                            foundClosestIntersectionPoint = true;
                        }
                    }
                }
            }

            // not close to a wall, return
            if (!foundClosestIntersectionPoint || closestWall == null || intersectedFeeler == null) return force;

            // calculate the steering force away from the wall
            var overshoot = intersectedFeeler.End - closestIntersectionPoint;
            force = closestWall.Normal(agent.Position) * overshoot.Magnitude();

            return force;
        }

        #endregion Individual Behaviors

        #region Group Behaviors

        public static Vector2f Separation(Agent agent, List<Agent> neighbors)
        {
            var force = Vector2f.Zero;

            if (neighbors.Count == 0) return force;

            foreach (var neighbor in neighbors)
            {
                var toAgent = agent.Position - neighbor.Position;
                var separationForce = (toAgent.Normal() * 20.5f) / toAgent.Magnitude();
                force += separationForce;
            }

            return force;
        }

        public static Vector2f Alignment(Agent agent, List<Agent> neighbors)
        {
            var force = Vector2f.Zero;

            if (neighbors.Count == 0) return force;

            foreach (var neighbor in neighbors)
            {
                force += neighbor.Velocity.Normal();
            }

            force /= neighbors.Count;
            force -= agent.Velocity.Normal();

            return force;
        }

        public static Vector2f Cohesion(Agent agent, List<Agent> neighbors)
        {
            var force = Vector2f.Zero;

            if (neighbors.Count == 0) return force;

            var centerOfMass = Vector2f.Zero;
            foreach (var neighbor in neighbors)
            {
                centerOfMass += neighbor.Position;
            }

            centerOfMass /= neighbors.Count;
            force = Seek(agent, centerOfMass);

            return force;
        }

        #endregion Group Behaviors

        #region Private Helper Methods

        public static List<Vector2f> GetHidingSpots(Vector2f hideFrom, List<Circle> obstacles)
        {
            var hidingSpots = obstacles.Select(x => GetHidingSpot(hideFrom, x)).ToList();
            return hidingSpots;
        }

        private static Vector2f GetHidingSpot(Vector2f hideFrom, Circle obstacle)
        {
            var toObstacle = obstacle.Origin - hideFrom;
            var distFromObstacle = 100.0f + obstacle.Radius + toObstacle.Magnitude();
            var hidingSpot = hideFrom + (toObstacle.Normal() * distFromObstacle);
            return hidingSpot;
        }

        /// <summary>
        /// Get the closest intersection point with an obstacle to an agent
        /// </summary>
        private static Vector2f? GetClosestIntersectionPoint(Agent agent, Circle obstacle)
        {
            // make obstacle "bigger" temporarily
            var bigObstacle = new Circle(obstacle.Origin, obstacle.Radius * 1.3f);

            // check for intersections
            var detectionLine = agent.GetDetectionLine();
            var intersections = G2d.Intersects(detectionLine, bigObstacle);
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