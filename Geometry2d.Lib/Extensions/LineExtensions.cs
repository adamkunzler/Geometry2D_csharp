using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class LineExtensions
    {
        public static bool Contains(this Line line, Vector2 p) => G2d.Contains(line, p);

        public static bool Contains(this Line line, Line l) => G2d.Contains(line, l);

        public static List<Vector2> Intersects(this Line line, Vector2 p) => G2d.Intersects(line, p);

        public static List<Vector2> Intersects(this Line line, Line l) => G2d.Intersects(line, l);

        public static List<Vector2> Intersects(this Line line, Rectangle r) => G2d.Intersects(line, r);

        public static List<Vector2> Intersects(this Line line, Circle c) => G2d.Intersects(line, c);

        public static List<Vector2> Intersects(this Line line, Triangle t) => G2d.Intersects(line, t);
    }
}