using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Utils
{
    public static partial class G2d
    {        
        /// <summary>
        /// Calculate perpendicular distance from a point to a line
        /// </summary>
        public static float DistanceTo(Point p, Line l)
        {
            var vLine = l.End - l.Start;
            var vPointLine = p - l.Start;

            // length of the line is 0, return distance from point to line start
            var lengthSquared = vLine.Magnitude2();
            if (lengthSquared == 0) return vPointLine.Magnitude();

            // create the perpendicular line projection point
            var t = MathF.Max(0, MathF.Min(1, (vPointLine.Dot(vLine)) / lengthSquared));
            var proj = l.Start + (t * vLine);

            // get length of perpendicular line projection point to the original point
            return (p - proj).Magnitude();
        }
    }
}