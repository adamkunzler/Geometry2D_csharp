using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class CircleExtensions
    {
        public static bool Contains(this Circle circle, Vector2 p) => G2d.Contains(circle, p);
    }
}
