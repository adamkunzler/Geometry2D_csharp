namespace Kz.Engine.Trigonometry
{
    public static class TrigUtil
    {
        /// <summary>
        /// Normalize the angle between 0 and 2π
        /// </summary>
        public static float NormalizeAngle(float angle)
        {
            var normalized = angle % (2 * MathF.PI);
            if (normalized < 0) normalized += 2 * MathF.PI;

            return normalized;
        }

        /// <summary>
        /// Reflect an angle across the Y-axis
        /// </summary>
        public static float MirrorAngle(float angle)
        {
            var normalized = NormalizeAngle(angle);

            if (normalized <= MathF.PI) return MathF.PI - normalized;
            else return 3 * MathF.PI - normalized; // Adjust if beyond π radians
        }

        /// <summary>
        /// Convert an angle in degrees to radians
        /// </summary>        
        public static float DegreesToRadians(float theta)
        {
            return theta * MathF.PI / 180.0f;
        }

        /// <summary>
        /// Convert an angle in radians to degrees
        /// </summary>        
        public static float RadiansToDegrees(float theta)
        {
            return theta * 180.0f / MathF.PI;
        }
    }
}