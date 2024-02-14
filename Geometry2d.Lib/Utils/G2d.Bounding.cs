using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region AABB

        public static Rectangle AABB(IShape lhs)
        {
            return lhs switch
            {
                Vector2 x => AABB(x),
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
        public static Rectangle AABB(Vector2 lhs)
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
        private static Rectangle AABB(IEnumerable<Vector2> vertices)
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
                Vector2 x => BoundingCircle(x),
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
        public static Circle BoundingCircle(Vector2 lhs)
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
        /// Returns an BoundingCircle for a polygon
        /// </summary>        
        public static Circle BoundingCircle(Polygon lhs)
        {
            return BoundingCircle(lhs.Center(), lhs.Vertices);
        }

        /// <summary>
        /// Returns an BoundingCircle for the given set of vertices
        /// </summary>        
        private static Circle BoundingCircle(Vector2 middle, IEnumerable<Vector2> vertices)
        {
            var max = float.MinValue;
            
            foreach (var vertice in vertices)
            {
                var dist = (vertice - middle).Magnitude();
                if (dist > max) max = dist;                
            }                        

            return new Circle(middle, max);
        }

        #endregion Bounding Circle
    }
}
