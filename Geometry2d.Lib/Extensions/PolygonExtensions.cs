using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class PolygonExtensions
    {
        public static bool Contains(this Polygon polygon, Vector2 p) => G2d.Contains(polygon, p);

        public static bool Contains(this Polygon polygon, Line l) => G2d.Contains(polygon, l);

        public static bool Contains(this Polygon polygon, Rectangle r) => G2d.Contains(polygon, r);

        public static bool Contains(this Polygon polygon, Circle c) => G2d.Contains(polygon, c);

        public static bool Contains(this Polygon polygon, Triangle t) => G2d.Contains(polygon, t);

        public static bool Contains(this Polygon polygon, Polygon p) => G2d.Contains(polygon, p);

        public static List<Vector2> Intersects(this Polygon polygon, Vector2 p) => G2d.Intersects(polygon, p);

        public static List<Vector2> Intersects(this Polygon polygon, Line l) => G2d.Intersects(polygon, l);

        public static List<Vector2> Intersects(this Polygon polygon, Rectangle r) => G2d.Intersects(polygon, r);

        public static List<Vector2> Intersects(this Polygon polygon, Circle c) => G2d.Intersects(polygon, c);

        public static List<Vector2> Intersects(this Polygon polygon, Triangle t) => G2d.Intersects(polygon, t);

        public static List<Vector2> Intersects(this Polygon polygon, Polygon p) => G2d.Intersects(polygon, p);

        public static List<Vector2> Intersects(this Polygon polygon, Ray r) => G2d.Intersects(polygon, r);
    }
}
