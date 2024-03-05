using Kz.Engine.DataStructures;

namespace Kz.Steering.Demo.Rules
{
    public class Avoidance : ISteeringRule
    {
        public float Weight { get; init; }

        public Avoidance(float weight)
        {
            Weight = weight;
        }

        /// <summary>
        /// Calculate the average position of all agents (excluding self) and create a
        /// normalized vector in the opposite direction.
        /// </summary>
        public Vector2f Calculate(Agent self, List<Agent> agents)
        {
            var force = Vector2f.Zero;
            foreach (var agent in agents)
            {
                if (agent == self) continue;

                // scale the force inversly proportional to the agents distance
                var toAgent = self.Position - agent.Position;
                force += toAgent.Normal() / toAgent.Magnitude();
            }

            return force;
        }
    }
}