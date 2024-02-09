using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class TriangleExtensions
    {
        public static bool Contains(this Triangle triangle, Vector2 p) => G2d.Contains(triangle, p);

        public static bool Contains(this Triangle triangle, Line l) => G2d.Contains(triangle, l);

        public static bool Contains(this Triangle triangle, Rectangle r) => G2d.Contains(triangle, r);

        public static bool Contains(this Triangle triangle, Circle c) => G2d.Contains(triangle, c);

        public static bool Contains(this Triangle triangle, Triangle t) => G2d.Contains(triangle, t);

        public static bool Contains(this Triangle triangle, Polygon p) => G2d.Contains(triangle, p);

        public static List<Vector2> Intersects(this Triangle triangle, Vector2 p) => G2d.Intersects(triangle, p);

        public static List<Vector2> Intersects(this Triangle triangle, Line l) => G2d.Intersects(triangle, l);

        public static List<Vector2> Intersects(this Triangle triangle, Rectangle r) => G2d.Intersects(triangle, r);

        public static List<Vector2> Intersects(this Triangle triangle, Circle c) => G2d.Intersects(triangle, c);
    }
}
