using Kz.Engine.DataStructures;

namespace Kz.Steering.Demo.Rules
{
    public class Cohesion : ISteeringRule
    {
        public float Weight { get; init; }

        public Cohesion(float weight)
        {
            Weight = weight;
        }

        /// <summary>
        /// Calculate the average position of all agents (excluding self) and create a
        /// normalized vector in that direction.
        /// </summary>
        public Vector2f Calculate(Agent self, List<Agent> agents)
        {
            var force = Vector2f.Zero;
            foreach (var agent in agents)
            {
                if (agent == self) continue;

                force += agent.Position;
            }

            force /= (agents.Count - 1);

            var direction = (force - self.Position).Normal();
            return direction;
        }
    }
}