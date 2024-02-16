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

        /// <summary>
        /// return reflection data for a ray reflecting of an IShape
        /// </summary>
        public static ReflectData Reflect(Ray lhs, IShape rhs)
        {
            return rhs switch
            {
                Vector2 x => Reflect(lhs, x),
                Line x => Reflect(lhs, x),
                Rectangle x => Reflect(lhs, x),
                Circle x => Reflect(lhs, x),
                Triangle x => Reflect(lhs, x),
                Polygon x => Reflect(lhs, x),
                _ => new ReflectData(Vector2.Zero, Vector2.Zero)
            };
        }

        /// <summary>
        /// return reflection data for a ray reflecting of a point
        /// </summary>
        public static ReflectData Reflect(Ray lhs, Vector2 rhs)
        {            
            return null!;
        }

        /// <summary>
        /// return reflection data for a ray reflecting of a line
        /// </summary>
        public static ReflectData Reflect(Ray lhs, Line rhs)
        {
            var collision = Collision(lhs, rhs);
            if (!collision.IsHit) return null!;

            var reflection = Reflect(lhs.Direction, collision.Normal);

            return new ReflectData(collision.Intersection, reflection);
        }

        /// <summary>
        /// return reflection data for a ray reflecting of a rectangle
        /// </summary>
        public static ReflectData Reflect(Ray lhs, Rectangle rhs)
        {
            var collision = Collision(lhs, rhs);
            if (!collision.IsHit) return null!;

            var reflection = Reflect(lhs.Direction, collision.Normal);

            return new ReflectData(collision.Intersection, reflection);
        }

        /// <summary>
        /// return reflection data for a ray reflecting of a circle
        /// </summary>
        public static ReflectData Reflect(Ray lhs, Circle rhs)
        {
            var collision = Collision(lhs, rhs);
            if (!collision.IsHit) return null!;

            var reflection = Reflect(lhs.Direction, collision.Normal);

            return new ReflectData(collision.Intersection, reflection);
        }

        /// <summary>
        /// return reflection data for a ray reflecting of a triangle
        /// </summary>
        public static ReflectData Reflect(Ray lhs, Triangle rhs)
        {
            var collision = Collision(lhs, rhs);
            if (!collision.IsHit) return null!;

            var reflection = Reflect(lhs.Direction, collision.Normal);

            return new ReflectData(collision.Intersection, reflection);
        }

        /// <summary>
        /// return reflection data for a ray reflecting of a polygon
        /// </summary>
        public static ReflectData Reflect(Ray lhs, Polygon rhs)
        {
            var collision = Collision(lhs, rhs);
            if (!collision.IsHit) return null!;

            var reflection = Reflect(lhs.Direction, collision.Normal);

            return new ReflectData(collision.Intersection, reflection);
        }

        private static Vector2 ClosestIntersection(Vector2 rayOrigin, List<Vector2> intersections)
        {
            var min = float.MaxValue;
            var closest = Vector2.Zero;

            foreach (var intersection in intersections)
            {
                var dist = (rayOrigin - intersection).Magnitude();
                if (dist < min)
                {
                    min = dist;
                    closest = intersection;
                }
            }

            return closest;
        }
    }
}