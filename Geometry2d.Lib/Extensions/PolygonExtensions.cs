using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class PolygonExtensions
    {
        public static bool Contains(this Polygon polygon, Vector2 p) => G2d.Contains(polygon, p);
    }
}
