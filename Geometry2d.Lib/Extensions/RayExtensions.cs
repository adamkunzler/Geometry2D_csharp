using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RayExtensions
    {
        public static bool Contains(this Ray ray, Vector2 p) => G2d.Contains(ray, p);
    }
}
