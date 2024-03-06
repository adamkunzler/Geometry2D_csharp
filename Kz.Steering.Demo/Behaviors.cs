using Kz.Engine.DataStructures;
using Kz.Engine.General;

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
            if(Utils.EpsilonEquals(distance, 0.0f)) return Vector2f.Zero; // we've arrived!
            
            // convert deceleration to float
            var decelerationConversionAmount = 20.0f;
            var speed = distance / ((float)deceleration * decelerationConversionAmount);
            speed = MathF.Min(speed, agent.MaxSpeed);

            var desiredVelocity = toTarget * speed / distance;
            var steeringForce = desiredVelocity - agent.Velocity;
            return steeringForce;
        }
    }
}