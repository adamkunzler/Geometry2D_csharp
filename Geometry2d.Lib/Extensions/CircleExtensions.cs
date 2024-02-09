using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class CircleExtensions
    {
        public static bool Contains(this Circle circle, Vector2 p) => G2d.Contains(circle, p);

        public static bool Contains(this Circle circle, Line l) => G2d.Contains(circle, l);

        public static bool Contains(this Circle circle, Rectangle r) => G2d.Contains(circle, r);

        public static bool Contains(this Circle circle, Circle c) => G2d.Contains(circle, c);

        public static bool Contains(this Circle circle, Triangle t) => G2d.Contains(circle, t);

        public static bool Contains(this Circle circle, Polygon p) => G2d.Contains(circle, p);

        public static List<Vector2> Intersects(this Circle circle, Vector2 p) => G2d.Intersects(circle, p);
        
        public static List<Vector2> Intersects(this Circle circle, Line l) => G2d.Intersects(circle, l);

        public static List<Vector2> Intersects(this Circle circle, Rectangle r) => G2d.Intersects(circle, r);

        public static List<Vector2> Intersects(this Circle circle, Circle c) => G2d.Intersects(circle, c);

        public static List<Vector2> Intersects(this Circle circle, Triangle t) => G2d.Intersects(circle, t);
    }
}
