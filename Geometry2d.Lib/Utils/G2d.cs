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

        /// <summary>
        /// Returns the closest point on shape RHS to shape LHS
        /// </summary>        
        public static Vector2 Closest(IShape lhs, IShape rhs, List<Line> lhsSides, List<Line> rhsSides)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2();

            foreach (var s1 in lhsSides)
            {
                foreach (var s2 in rhsSides)
                {
                    var point = Closest(s1, s2);
                    var dist = DistanceTo(point, s1);
                    if (dist < min)
                    {
                        min = dist;
                        closestPoint = point;
                    }
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Returns the closest point on a line to a IShape lhs
        /// </summary>        
        public static Vector2 Closest(IShape lhs, List<Line> lhsSides, Line rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2();

            foreach (var s1 in lhsSides)
            {
                var point = Closest(s1, rhs);
                var dist = DistanceTo(point, s1);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Returns the closest point on a circle to a IShape lhs
        /// </summary>        
        public static Vector2 Closest(IShape lhs, List<Line> lhsSides, Circle rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2();

            foreach (var side in lhsSides)
            {
                var point = Closest(side, rhs);
                var dist = DistanceTo(point, side);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }

        /// <summary>
        /// Returns the closest point on a ray to a IShape lhs
        /// </summary>        
        public static Vector2 Closest(IShape lhs, List<Line> lhsSides, Ray rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count != 0) return intersections.First();

            var min = float.MaxValue;
            var closestPoint = new Vector2();

            foreach (var side in lhsSides)
            {
                var point = Closest(side, rhs);
                var dist = DistanceTo(point, side);
                if (dist < min)
                {
                    min = dist;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }
    }
}