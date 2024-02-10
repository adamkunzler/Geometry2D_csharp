using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class LineExtensions
    {
        public static bool Contains(this Line lhs, Vector2 rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Line lhs, Line rhs) => G2d.Contains(lhs, rhs);

        public static List<Vector2> Intersects(this Line lhs, Vector2 rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Line lhs, Line rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Line lhs, Rectangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Line lhs, Circle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Line lhs, Triangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Line lhs, Polygon rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Line lhs, Ray rhs) => G2d.Intersects(lhs, rhs);

        public static Vector2 Closest(this Line lhs, Vector2 rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Line lhs, Line rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Line lhs, Rectangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Line lhs, Circle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Line lhs, Triangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Line lhs, Polygon rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Line lhs, Ray rhs) => G2d.Closest(lhs, rhs);
    }
}