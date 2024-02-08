using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class LineExtensions
    {
        public static bool Contains(this Line l, Vector2 p) => G2d.Contains(l, p);
    }
}