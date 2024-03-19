using Kz.Engine.DataStructures;

namespace Kz.Engine.Steering2d
{
    public static class BehaviorManager
    {
        public static Vector2f CalculateSteeringForce(Agent agent, BehaviorForceConfig config)
        {
            if (agent.Behaviors == Behaviors.None) return Vector2f.Zero;

            var totalForce = Vector2f.Zero;

            if ((agent.Behaviors & Behaviors.Wander) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Wander(agent, config.WanderDistance, config.WanderRadius);
            }

            if ((agent.Behaviors & Behaviors.Seek) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Seek(agent, config.SeekTarget);
            }

            if ((agent.Behaviors & Behaviors.Flee) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Flee(agent, config.FleeTarget, config.FleeDistance);
            }

            if ((agent.Behaviors & Behaviors.Arrive) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Arrive(agent, config.ArriveTarget, config.ArriveDeceleration);
            }

            if ((agent.Behaviors & Behaviors.Pursue) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Pursue(agent, config.PursueTarget);
            }

            if ((agent.Behaviors & Behaviors.Evade) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Evade(agent, config.EvadeOther);
            }

            if ((agent.Behaviors & Behaviors.AvoidObstacle) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.AvoidObstacle(agent, config.Obstacle);
            }

            if ((agent.Behaviors & Behaviors.AvoidObstacles) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.AvoidObstacles(agent, config.Obstacles);
            }

            if ((agent.Behaviors & Behaviors.HideFrom) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.HideFrom(agent, config.HideFrom, config.Obstacles, config.HideFromDistance);
            }

            if ((agent.Behaviors & Behaviors.AvoidWalls) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.AvoidWalls(agent, config.Walls);
            }

            if ((agent.Behaviors & Behaviors.Separation) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Separation(agent, config.Neighbors);
            }

            if ((agent.Behaviors & Behaviors.Alignment) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Alignment(agent, config.Neighbors);
            }

            if ((agent.Behaviors & Behaviors.Cohesion) != Behaviors.None)
            {
                totalForce += BehaviorsForceCalculator.Cohesion(agent, config.Neighbors);
            }



            return totalForce;
        }
    }
}