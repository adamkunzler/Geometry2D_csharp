using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class PolygonExtensions
    {
        public static bool Contains(this Polygon lhs, Vector2 rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Polygon lhs, Line rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Polygon lhs, Rectangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Polygon lhs, Circle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Polygon lhs, Triangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Polygon lhs, Polygon rhs) => G2d.Contains(lhs, rhs);

        public static List<Vector2> Intersects(this Polygon lhs, Vector2 rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Polygon lhs, Line rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Polygon lhs, Rectangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Polygon lhs, Circle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Polygon lhs, Triangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Polygon lhs, Polygon rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Polygon lhs, Ray rhs) => G2d.Intersects(lhs, rhs);

        public static Vector2 Closest(this Polygon lhs, Vector2 rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Polygon lhs, Line rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Polygon lhs, Rectangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Polygon lhs, Circle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Polygon lhs, Triangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Polygon lhs, Polygon rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Polygon lhs, Ray rhs) => G2d.Closest(lhs, rhs);
    }
}
