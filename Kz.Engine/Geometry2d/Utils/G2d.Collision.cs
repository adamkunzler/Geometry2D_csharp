using Kz.Engine.Geometry2d.Primitives;
using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Utils
{
    public record CollisionData(bool IsHit, Point Intersection, Vector2f Normal, IShape Shape);

    public static partial class G2d
    {
        #region Ray COLLISION with [Shape]

        /// <summary>
        /// return reflection data for a ray reflecting of an IShape
        /// </summary>
        public static CollisionData Collision(Ray lhs, IShape rhs)
        {
            return rhs switch
            {
                Point x => Collision(lhs, x),
                Line x => Collision(lhs, x),
                Rectangle x => Collision(lhs, x),
                Circle x => Collision(lhs, x),
                Triangle x => Collision(lhs, x),
                Polygon x => Collision(lhs, x),
                _ => new CollisionData(false, Point.Zero, Vector2f.Zero, null!)
            };
        }

        /// <summary>
        /// Return collision information for a collision between a ray and a point
        /// </summary>
        public static CollisionData Collision(Ray lhs, Point rhs)
        {
            return new CollisionData(false, Point.Zero, Vector2f.Zero, null!);
        }

        /// <summary>
        /// Return collision information for a collision between a ray and a Line
        /// </summary>
        public static CollisionData Collision(Ray lhs, Line rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count == 0) return new CollisionData(false, Point.Zero, Vector2f.Zero, null!);

            var closest = ClosestIntersection(lhs.Origin, intersections);

            var normal = (rhs.End - rhs.Start).Perpendicular();

            return new CollisionData(true, closest, normal, rhs);
        }

        /// <summary>
        /// Return collision information for a collision between a ray and a rectangle
        /// </summary>
        public static CollisionData Collision(Ray lhs, Rectangle rhs)
        {
            var collision = Collision(lhs, rhs.Sides);
            return collision.IsHit
                ? new CollisionData(true, collision.Intersection, collision.Normal, rhs)
                : new CollisionData(false, Point.Zero, Vector2f.Zero, null!);
        }

        /// <summary>
        /// Return collision information for a collision between a ray and a circle
        /// </summary>
        public static CollisionData Collision(Ray lhs, Circle rhs)
        {
            var intersections = Intersects(lhs, rhs);
            if (intersections.Count == 0) return new CollisionData(false, Point.Zero, Vector2f.Zero, null!);

            var closest = ClosestIntersection(lhs.Origin, intersections);

            var normal = (closest - rhs.Origin).Normal();

            return new CollisionData(true, closest, normal, rhs);
        }

        /// <summary>
        /// Return collision information for a collision between a ray and a triangle
        /// </summary>
        public static CollisionData Collision(Ray lhs, Triangle rhs)
        {
            var collision = Collision(lhs, rhs.Sides);
            return collision.IsHit
                ? new CollisionData(true, collision.Intersection, collision.Normal, rhs)
                : new CollisionData(false, Point.Zero, Vector2f.Zero, null!);
        }

        /// <summary>
        /// Return collision information for a collision between a ray and a polygon
        /// </summary>
        public static CollisionData Collision(Ray lhs, Polygon rhs)
        {
            var collision = Collision(lhs, rhs.Sides());
            return collision.IsHit
                ? new CollisionData(true, collision.Intersection, collision.Normal, rhs)
                : new CollisionData(false, Point.Zero, Vector2f.Zero, null!);
        }

        /// <summary>
        /// Return collision information for a collision between a ray and a collection of lines
        /// </summary>
        private static CollisionData Collision(Ray lhs, List<Line> sides)
        {
            var isCollision = false;
            var min = float.MaxValue;
            var closestIntersection = Point.Zero;
            var closestNormal = Vector2f.Zero;

            foreach (var side in sides)
            {
                var intersections = Intersects(lhs, side);
                if (intersections.Count == 0) continue;

                isCollision = true;

                // ray can only have one intersection with a line segment
                var dist = (lhs.Origin - intersections[0]).Magnitude2();
                if (dist < min)
                {
                    min = dist;
                    closestIntersection = intersections[0];
                    closestNormal = side.Vector().Perpendicular().Normal();
                }
            }

            return isCollision
                ? new CollisionData(true, closestIntersection, closestNormal, null!)
                : new CollisionData(false, Point.Zero, Vector2f.Zero, null!);
        }

        private static Point ClosestIntersection(Point rayOrigin, List<Point> intersections)
        {
            var min = float.MaxValue;
            var closest = Point.Zero;

            foreach (var intersection in intersections)
            {
                var dist = (rayOrigin - intersection).Magnitude2();
                if (dist < min)
                {
                    min = dist;
                    closest = intersection;
                }
            }

            return closest;
        }

        #endregion Ray COLLISION with [Shape]
    }
}