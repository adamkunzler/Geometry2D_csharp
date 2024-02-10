using Geometry2d.Lib.Primitives;
using Geometry2d.Lib.Utils;

namespace Geometry2d.Lib.Extensions
{
    public static class CircleExtensions
    {
        public static bool Contains(this Circle lhs, Vector2 rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Circle lhs, Line rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Circle lhs, Rectangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Circle lhs, Circle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Circle lhs, Triangle rhs) => G2d.Contains(lhs, rhs);

        public static bool Contains(this Circle lhs, Polygon rhs) => G2d.Contains(lhs, rhs);

        public static List<Vector2> Intersects(this Circle lhs, Vector2 rhs) => G2d.Intersects(lhs, rhs);
        
        public static List<Vector2> Intersects(this Circle lhs, Line rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Circle lhs, Rectangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Circle lhs, Circle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Circle lhs, Triangle rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Circle lhs, Polygon rhs) => G2d.Intersects(lhs, rhs);

        public static List<Vector2> Intersects(this Circle lhs, Ray rhs) => G2d.Intersects(lhs, rhs);

        public static Vector2 Closest(this Circle lhs, Vector2 rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Circle lhs, Line rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Circle lhs, Rectangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Circle lhs, Circle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Circle lhs, Triangle rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Circle lhs, Polygon rhs) => G2d.Closest(lhs, rhs);

        public static Vector2 Closest(this Circle lhs, Ray rhs) => G2d.Closest(lhs, rhs);
    }
}
