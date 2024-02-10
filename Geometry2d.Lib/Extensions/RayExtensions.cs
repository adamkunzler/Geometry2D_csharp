using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RayExtensions
    {
        public static bool Contains(this Ray lhs, Vector2 rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Ray lhs, Line rhs) => G2d.Contains(lhs, rhs);

        public static List<Vector2> Intersects(this Ray lhs, Vector2 rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Ray lhs, Line rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Ray lhs, Rectangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Ray lhs, Circle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Ray lhs, Triangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Ray lhs, Polygon rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Ray lhs, Ray rhs) => G2d.Intersects(lhs, rhs);

        public static Vector2 Closest(this Ray lhs, Vector2 rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Ray lhs, Line rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Ray lhs, Rectangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Ray lhs, Circle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Ray lhs, Triangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Ray lhs, Polygon rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Ray lhs, Ray rhs) => G2d.Closest(lhs, rhs);
    }
}
