using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RayExtensions
    {
        public static bool Contains(this Ray ray, Vector2 p) => G2d.Contains(ray, p);

        public static bool Contains(this Ray ray, Line l) => G2d.Contains(ray, l);

        public static List<Vector2> Intersects(this Ray ray, Vector2 p) => G2d.Intersects(ray, p);

        public static List<Vector2> Intersects(this Ray ray, Line l) => G2d.Intersects(ray, l);

        public static List<Vector2> Intersects(this Ray ray, Rectangle r) => G2d.Intersects(ray, r);

        public static List<Vector2> Intersects(this Ray ray, Circle c) => G2d.Intersects(ray, c);

        public static List<Vector2> Intersects(this Ray ray, Triangle t) => G2d.Intersects(ray, t);

        public static List<Vector2> Intersects(this Ray ray, Polygon p) => G2d.Intersects(ray, p);
    }
}
