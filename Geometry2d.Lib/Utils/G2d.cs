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
            var lx = l.End.X - l.Start.X;
            var ly = l.End.Y - l.Start.Y;

            var plx = p.X - l.Start.X;
            var ply = p.Y - l.Start.Y;

            // length of the line is 0, return distance from point to line start
            var lengthSquared = lx * lx + ly * ly;
            if (lengthSquared == 0) return MathF.Sqrt(plx * plx + ply * ply);

            // create the perpendicular line projection point
            var t = MathF.Max(0, MathF.Min(1, ((plx) * (lx) + (ply) * (ly)) / lengthSquared));
            var projX = l.Start.X + t * lx;
            var projY = l.Start.Y + t * ly;

            // get length of perpendicular line projection point to the original point
            return MathF.Sqrt(MathF.Pow(p.X - projX, 2.0f) + MathF.Pow(p.Y - projY, 2.0f));
        }
    }
}