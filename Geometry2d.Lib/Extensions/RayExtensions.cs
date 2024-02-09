using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class RayExtensions
    {
        public static bool Contains(this Ray ray, Vector2 p) => G2d.Contains(ray, p);

        public static bool Contains(this Ray ray, Line l) => G2d.Contains(ray, l);

        public static List<Vector2> Intersects(this Ray ray, Vector2 p) => G2d.Intersects(ray, p);

        public static List<Vector2> Intersects(this Ray ray, Line l) => G2d.Intersects(ray, l);
    }
}
