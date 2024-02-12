using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        /// <summary>
        /// Calculate perpendicular distance from a point to a line
        /// </summary>
        public static float DistanceTo(Vector2 p, Line l)
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

        /// <summary>
        /// Return the closest point on a line and closest line to a point (lhs) from a list of lines (rhs)
        /// </summary>        
        public static (Vector2 Point, Line Line) Closest(Vector2 lhs, List<Line> rhs)
        {
            var minDistance = float.MaxValue;
            Line? closestLine = null;
            Vector2? closestPoint = null;

            foreach (var line in rhs)
            {
                var closestPointOnLine = Closest(lhs, line);
                var distance = (closestPointOnLine - lhs).Magnitude();
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestLine = line;
                    closestPoint = closestPointOnLine;
                }
            }

            return (closestPoint!, closestLine!);
        }
    }
}