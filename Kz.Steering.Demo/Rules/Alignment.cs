using Kz.Engine.DataStructures;

namespace Kz.Steering.Demo.Rules
{
    public class Alignment : ISteeringRule
    {
        public float Weight { get; init; }

        public Alignment(float weight)
        {
            Weight = weight;
        }

        /// <summary>
        /// Calculate the average velocity of each agent (excluding self) and normalize the result.
        /// </summary>
        public Vector2f Calculate(Agent self, List<Agent> agents)
        {
            var force = Vector2f.Zero;
            foreach (var agent in agents)
            {
                if (agent == self) continue;

                force += agent.Velocity;
            }

            force /= (agents.Count - 1);

            return force.Normal();
        }
    }
}