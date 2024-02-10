using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RectangleExtensions
    {
        public static bool Contains(this Rectangle lhs, Vector2 rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Rectangle lhs, Line rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Rectangle lhs, Rectangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Rectangle lhs, Circle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Rectangle lhs, Triangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Rectangle lhs, Polygon rhs) => G2d.Contains(lhs, rhs);

        public static List<Vector2> Intersects(this Rectangle lhs, Vector2 rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Rectangle lhs, Line rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Rectangle lhs, Rectangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Rectangle lhs, Circle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Rectangle lhs, Triangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Rectangle lhs, Polygon rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Rectangle lhs, Ray rhs) => G2d.Intersects(lhs, rhs);

        public static Vector2 Closest(this Rectangle lhs, Vector2 rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Rectangle lhs, Line rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Rectangle lhs, Rectangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Rectangle lhs, Circle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Rectangle lhs, Triangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Rectangle lhs, Polygon rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Rectangle lhs, Ray rhs) => G2d.Closest(lhs, rhs);
    }
}
