﻿using Geometry2d.Lib.Primitives;

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
                _ => null!
            };
        }

        /// <summary>
        /// Calculate the reflection data for a ray bouncing around a list of shapes
        /// </summary>        
        public static List<ReflectData> Reflect(Ray lhs, List<IShape> shapes, int maxBounces)
        {
            var reflectData = new List<ReflectData>();

            var ray = lhs;
            ReflectData lastClosest = null;

            for (var i = 0; i < maxBounces; i++)
            {                
                var minDist = float.MaxValue;
                ReflectData closest = null!;

                foreach(var shape in shapes)
                {
                    var r = Reflect(ray, shape);
                    if (r == null || r.Intersection.AreEqual(lastClosest?.Intersection!)) continue;

                    var dist = (r.Intersection - ray.Origin).Magnitude2();
                    if(dist < minDist)
                    {
                        minDist = dist;
                        closest = r;                        
                    }
                }

                if (closest == null) break;

                // move "closest" a little bit away from intersection point in the direction of the incoming ray
                var dir = (ray.Origin - closest.Intersection).Normal();
                var newClosestIntersection = closest.Intersection + (dir * 0.05f);
                var closerClosest = new ReflectData(newClosestIntersection, closest.Reflection);
                
                lastClosest = closerClosest;
                ray = new Ray(closerClosest.Intersection, closerClosest.Reflection);
                reflectData.Add(closerClosest);
            }

            return reflectData;
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
    }
}