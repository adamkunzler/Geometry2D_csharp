using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class TriangleExtensions
    {
        public static bool Contains(this Triangle triangle, Vector2 p) => G2d.Contains(triangle, p);
    }
}
