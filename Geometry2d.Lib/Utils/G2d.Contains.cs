
using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region [Shape] CONTAINS Point

        /// <summary>
        /// determine if a point contains a point
        /// </summary>        
        public static bool Contains(Vector2 p, Vector2 other)
        {
            // get the magnitude squared of the vector p pointing to other
            var mag2 = (p - other).Magnitude2();            
            return mag2 <= Consts.EPSILON;
        }

        /// <summary>
        /// determine if a line contains a point
        /// </summary>        
        public static bool Contains(Line l, Vector2 p)
        {
            double dx = l.End.X - l.Start.X;
            double dy = l.End.Y - l.Start.Y;

            // Special cases for vertical and horizontal line segments
            if (dx == 0 && p.X == l.Start.X)
                return p.Y >= Math.Min(l.Start.Y, l.End.Y) && p.Y <= Math.Max(l.Start.Y, l.End.Y);
            if (dy == 0 && p.Y == l.Start.Y)
                return p.X >= Math.Min(l.Start.X, l.End.X) && p.X <= Math.Max(l.Start.X, l.End.X);

            // Calculate the slope and intercept
            double m = dy / dx;
            double b = l.Start.Y - m * l.Start.X;

            // Check if the point satisfies the line equation
            if (p.Y == m * p.X + b)
            {
                // Check if the point is within the segment's bounds
                return (p.X >= Math.Min(l.Start.X, l.End.X) && p.X <= Math.Max(l.Start.X, l.End.X)) &&
                       (p.Y >= Math.Min(l.Start.Y, l.End.Y) && p.Y <= Math.Max(l.Start.Y, l.End.Y));
            }

            return false;
        }

        /// <summary>
        /// determine if a rectangle contains a point
        /// </summary>        
        public static bool Contains(Rectangle r, Vector2 p)
        {
            return !(
                p.X < r.Position.X || 
                p.X > (r.Position.X + r.Size.Width) ||
                p.Y < r.Position.Y ||
                p.Y > (r.Position.Y + r.Size.Height));
        }

        /// <summary>
        /// determine if a circle contains a point
        /// </summary>        
        public static bool Contains(Circle c, Vector2 p)
        {
            var mag2 = (p - c.Position).Magnitude2();
            return mag2 < (c.Radius * c.Radius);
        }

        /// <summary>
        /// determine if a triangle contains a point
        /// </summary>        
        public static bool Contains(Triangle t, Vector2 p)
        {
            // compute vectors from P to each vertex of triangle
            var v0 = t.Vertices[2] - t.Vertices[0];// new Vector2(t.Vertices[2].X - t.Vertices[0].X, t.Vertices[2].Y - t.Vertices[0].Y);
            var v1 = t.Vertices[1] - t.Vertices[0];// new Vector2(t.Vertices[1].X - t.Vertices[0].X, t.Vertices[1].Y - t.Vertices[0].Y);
            var v2 = p - t.Vertices[0];// new Vector2(p.X - t.Vertices[0].X, p.Y - t.Vertices[0].Y);

            // compute dot products
            var dot00 = v0.Dot(v0);// v0.X * v0.X + v0.Y * v0.Y;
            var dot01 = v0.Dot(v1);// v0.X * v1.X + v0.Y * v1.Y;
            var dot02 = v0.Dot(v2);// v0.X * v2.X + v0.Y * v2.Y;
            var dot11 = v1.Dot(v1);// v1.X * v1.X + v1.Y * v1.Y;
            var dot12 = v1.Dot(v2);// v1.X * v2.X + v1.Y * v2.Y;

            // Compute barycentric coordinates
            var invDenom = 1 / (dot00 * dot11 - dot01 * dot01);
            var u = (dot11 * dot02 - dot01 * dot12) * invDenom;
            var v = (dot00 * dot12 - dot01 * dot02) * invDenom;

            // Check if point is in triangle
            return (u >= 0) && (v >= 0) && (u + v < 1);
        }

        /// <summary>
        /// determine if a polygon contains a point
        /// </summary>        
        public static bool Contains(Polygon poly, Vector2 p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// determine if a ray contains a point
        /// </summary>        
        public static bool Contains(Ray r, Vector2 p)
        {
            var originPoint = p - r.Origin;

            var dot = originPoint.Dot(r.Direction);
            
            // point is behind origin
            if (dot < 0) return false;

            // project originPoint onto ray's direction
            var projection = new Vector2(r.Direction.X * dot, r.Direction.Y * dot);

            // check if projection is same as originPoint
            var x = projection.X - originPoint.X;
            var y = projection.Y - originPoint.Y;            
            var distance = MathF.Sqrt(x * x + y * y);

            return distance < Consts.EPSILON;
        }

        #endregion [Shape] CONTAINS Point
    }
}
