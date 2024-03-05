using Kz.Engine.DataStructures;
using Kz.Engine.Trigonometry;

namespace Kz.Steering.Demo.Rules
{
    public class RandomWalk : ISteeringRule
    {
        private Random _random = new Random();

        public float Weight { get; init; }

        public RandomWalk(float weight)
        {
            Weight = weight;
        }

        public Vector2f Calculate(Agent self, List<Agent> agents)
        {
            var direction = _random.NextDouble() * TrigConsts.TWO_PI;
            var force = new Vector2f(1.0f, (float)direction);                        
            return force.ToCartesian().Normal();
        }
    }
}