using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RectangleExtensions
    {
        public static bool Contains(this Rectangle rectangle, Vector2 p) => G2d.Contains(rectangle, p);
    }
}
