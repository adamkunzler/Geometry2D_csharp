using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class TriangleExtensions
    {
        public static bool Contains(this Triangle lhs, Vector2 rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Triangle lhs, Line rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Triangle lhs, Rectangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Triangle lhs, Circle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Triangle lhs, Triangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Triangle lhs, Polygon rhs) => G2d.Contains(lhs, rhs);

        public static List<Vector2> Intersects(this Triangle lhs, Vector2 rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Triangle lhs, Line rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Triangle lhs, Rectangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Triangle lhs, Circle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Triangle lhs, Triangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Triangle lhs, Polygon rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Triangle lhs, Ray rhs) => G2d.Intersects(lhs, rhs);

        public static Vector2 Closest(this Triangle lhs, Vector2 rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Triangle lhs, Line rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Triangle lhs, Rectangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Triangle lhs, Circle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Triangle lhs, Triangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Triangle lhs, Polygon rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Triangle lhs, Ray rhs) => G2d.Closest(lhs, rhs);
    }
}
