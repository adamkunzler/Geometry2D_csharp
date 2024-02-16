using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public record ReflectData(Vector2 Intersection, Vector2 Reflection);

    public static partial class G2d
    {
        /// <summary>
        /// Law of Reflection
        /// </summary>        
        public static Vector2 Reflect(Vector2 incident, Vector2 normal)
        {
            // reflection vector
            //      r = i - 2(i dot n)n
            //      i = incident vector
            //      n = normal vector

            return incident - (2.0f * Vector2.Dot(incident, normal) * normal);
        }

        public static ReflectData Reflect(Ray lhs, Rectangle rhs)
        {
            var min = float.MaxValue;
            var closest = Vector2.Zero;

            var intersections = Intersects(lhs, rhs);
            if (intersections.Count == 0) return new ReflectData(Vector2.Zero, Vector2.Zero);

            foreach ( var intersection in intersections )
            {
                var dist = (lhs.Origin - intersection).Magnitude();
                if( dist < min )
                {
                    min = dist;
                    closest = intersection;
                }
            }

            var normal = Vector2.Zero;
            if (Contains(rhs.Left, closest)) normal = new Vector2(-1.0f, 0.0f);
            if (Contains(rhs.Right, closest)) normal = new Vector2(1.0f, 0.0f);
            if (Contains(rhs.Top, closest)) normal = new Vector2(0.0f, -1.0f);
            if (Contains(rhs.Bottom, closest)) normal = new Vector2(0.0f, 1.0f);

            var reflection = Reflect(lhs.Direction, normal);

            return new ReflectData(closest, reflection);
        }        
    }
}
