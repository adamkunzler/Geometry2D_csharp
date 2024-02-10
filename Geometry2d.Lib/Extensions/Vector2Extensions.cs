using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class Vector2Extensions
    {
        public static bool Contains(this Vector2 lhs, Vector2 rhs) => G2d.Contains(lhs, rhs);

        public static List<Vector2> Intersects(this Vector2 lhs, Vector2 rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Vector2 lhs, Line rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Vector2 lhs, Rectangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Vector2 lhs, Circle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Vector2 lhs, Triangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Vector2 lhs, Polygon rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Vector2 lhs, Ray rhs) => G2d.Intersects(lhs, rhs);

        public static Vector2 Closest(this Vector2 lhs, Vector2 rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Vector2 lhs, Line rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Vector2 lhs, Rectangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Vector2 lhs, Circle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Vector2 lhs, Triangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Vector2 lhs, Polygon rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Vector2 lhs, Ray rhs) => G2d.Closest(lhs, rhs);
    }
}