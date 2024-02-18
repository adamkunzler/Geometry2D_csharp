using Geometry2d.Lib.Primitives;
using Kz.DataStructures;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region AABB

        public static Rectangle AABB(IShape lhs)
        {
            return lhs switch
            {
                Vector2f x => AABB(x),
                Line x => AABB(x),
                Rectangle x => AABB(x),
                Circle x => AABB(x),
                Triangle x => AABB(x),
                Polygon x => AABB(x),
                _ => new Rectangle()
            };
        }

        /// <summary>
        /// Returns an AABB for a point
        /// </summary>
        public static Rectangle AABB(Vector2f lhs)
        {
            return new Rectangle(lhs.X, lhs.Y, 1.0f, 1.0f);
        }

        /// <summary>
        /// Returns an AABB for a line
        /// </summary>
        public static Rectangle AABB(Line lhs)
        {
            return AABB(lhs.Endpoints());
        }

        /// <summary>
        /// Returns an AABB for a rectangle
        /// </summary>
        public static Rectangle AABB(Rectangle lhs)
        {
            return lhs;
        }

        /// <summary>
        /// Returns an AABB for a circle
        /// </summary>
        public static Rectangle AABB(Circle lhs)
        {
            return new Rectangle(lhs.Origin.X - lhs.Radius, lhs.Origin.Y - lhs.Radius, lhs.Radius * 2.0f, lhs.Radius * 2.0f);
        }

        /// <summary>
        /// Returns an AABB for a triangle
        /// </summary>
        public static Rectangle AABB(Triangle lhs)
        {
            return AABB(lhs.Vertices);
        }

        /// <summary>
        /// Returns an AABB for a polygon
        /// </summary>
        public static Rectangle AABB(Polygon lhs)
        {
            return AABB(lhs.Vertices);
        }

        /// <summary>
        /// Returns an AABB for the given set of vertices
        /// </summary>
        private static Rectangle AABB(IEnumerable<Vector2f> vertices)
        {
            var minX = float.MaxValue;
            var maxX = float.MinValue;
            var minY = float.MaxValue;
            var maxY = float.MinValue;

            foreach (var vertice in vertices)
            {
                if (vertice.X < minX) minX = vertice.X;
                if (vertice.X > maxX) maxX = vertice.X;
                if (vertice.Y < minY) minY = vertice.Y;
                if (vertice.Y > maxY) maxY = vertice.Y;
            }

            var width = maxX - minX;
            var height = maxY - minY;

            return new Rectangle(minX, minY, width, height);
        }

        #endregion AABB

        #region Bounding Circle

        public static Circle BoundingCircle(IShape lhs)
        {
            return lhs switch
            {
                Vector2f x => BoundingCircle(x),
                Line x => BoundingCircle(x),
                Rectangle x => BoundingCircle(x),
                Circle x => BoundingCircle(x),
                Triangle x => BoundingCircle(x),
                Polygon x => BoundingCircle(x),
                _ => new Circle()
            };
        }

        /// <summary>
        /// Returns an BoundingCircle for a point
        /// </summary>
        public static Circle BoundingCircle(Vector2f lhs)
        {
            return new Circle(lhs.X, lhs.Y, 1.0f);
        }

        /// <summary>
        /// Returns an BoundingCircle for a line
        /// </summary>
        public static Circle BoundingCircle(Line lhs)
        {
            var minX = MathF.Min(lhs.Start.X, lhs.End.X);
            var maxX = MathF.Max(lhs.Start.X, lhs.End.X);
            var minY = MathF.Min(lhs.Start.Y, lhs.End.Y);
            var maxY = MathF.Max(lhs.Start.Y, lhs.End.Y);

            var width = maxX - minX;
            var halfWidth = width / 2.0f;

            var height = maxY - minY;
            var halfHeight = height / 2.0f;

            var radius = MathF.Max(halfWidth, halfHeight);

            return new Circle(minX + halfWidth, minY + halfHeight, radius);
        }

        /// <summary>
        /// Returns an BoundingCircle for a rectangle
        /// </summary>
        public static Circle BoundingCircle(Rectangle lhs)
        {
            return BoundingCircle(lhs.Middle, lhs.Vertices);
        }

        /// <summary>
        /// Returns an BoundingCircle for a circle
        /// </summary>
        public static Circle BoundingCircle(Circle lhs)
        {
            return lhs;
        }

        /// <summary>
        /// Returns an BoundingCircle for a triangle
        /// </summary>
        public static Circle BoundingCircle(Triangle lhs)
        {
            return lhs.Circumcircle();
        }

        /// <summary>
        /// Returns an BoundingCircle for a polygon using Ritter's bounding circle algorithm
        /// </summary>
        public static Circle BoundingCircle(Polygon lhs)
        {
            if (lhs is RegularPolygon rp)
            {
                return new Circle(rp.Center(), rp.Radius);
            }

            // Initial points A and B (furthest point from point[0]) for the diameter of the initial circle
            var A = lhs.Vertices.First();
            var B = lhs.Vertices.Aggregate((currentFarthest, next) => (A - next).Magnitude() > (A - currentFarthest).Magnitude() ? next : currentFarthest);

            // Initial circle defined by A and B
            var center = (A + B) / 2.0f;
            var radius = (A - B).Magnitude() / 2;

            // Check and adjust the circle to include all points
            foreach (var point in lhs.Vertices)
            {
                var d = (center - point).Magnitude();
                if (d > radius)
                {
                    // Adjust the circle to include the new point
                    radius = (radius + d) / 2;
                    var direction = point - center;
                    var norm = MathF.Sqrt(direction.Dot(direction));
                    direction /= norm;
                    center += direction * (d - radius);
                }
            }

            return new Circle(center, radius);
        }

        /// <summary>
        /// Returns an BoundingCircle for the given set of vertices
        /// </summary>
        private static Circle BoundingCircle(Vector2f middle, IEnumerable<Vector2f> vertices)
        {
            var max = float.MinValue;

            foreach (var vertice in vertices)
            {
                var dist = (vertice - middle).Magnitude2();
                if (dist > max) max = dist;
            }

            return new Circle(middle, max);
        }

        #endregion Bounding Circle
    }
}