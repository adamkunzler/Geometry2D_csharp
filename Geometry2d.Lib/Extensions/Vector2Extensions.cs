using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class Vector2Extensions
    {
        public static bool Contains(this Vector2 p, Vector2 other) => G2d.Contains(p, other);
    }
}