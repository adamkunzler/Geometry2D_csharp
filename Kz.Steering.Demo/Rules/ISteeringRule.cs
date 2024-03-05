using Kz.Engine.DataStructures;

namespace Kz.Steering.Demo.Rules
{
    /// <summary>
    /// Represents a steering rule that determines a change in acceleration of an agent
    /// </summary>
    public interface ISteeringRule
    {
        /// <summary>
        /// Get the weight of the steering rule
        /// </summary>
        float Weight { get; }

        /// <summary>
        /// Calculate the normalized acceleration force of the steering rule
        /// </summary>        
        Vector2f Calculate(Agent self, List<Agent> agents);
    }
}