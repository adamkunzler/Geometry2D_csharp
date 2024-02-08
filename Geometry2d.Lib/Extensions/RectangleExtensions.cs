using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RectangleExtensions
    {
        public static bool Contains(this Rectangle rectangle, Vector2 p) => G2d.Contains(rectangle, p);

        public static bool Contains(this Rectangle rectangle, Line l) => G2d.Contains(rectangle, l);

        public static bool Contains(this Rectangle rectangle, Rectangle r) => G2d.Contains(rectangle, r);

        public static bool Contains(this Rectangle rectangle, Circle c) => G2d.Contains(rectangle, c);

        public static bool Contains(this Rectangle rectangle, Triangle t) => G2d.Contains(rectangle, t);

        public static bool Contains(this Rectangle rectangle, Polygon p) => G2d.Contains(rectangle, p);
    }
}
