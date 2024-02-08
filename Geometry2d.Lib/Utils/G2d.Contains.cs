using Geometry2d.Lib.Extensions;
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
            var v0 = t.Vertices[2] - t.Vertices[0];
            var v1 = t.Vertices[1] - t.Vertices[0];
            var v2 = p - t.Vertices[0];

            // compute dot products
            var dot00 = v0.Dot(v0);
            var dot01 = v0.Dot(v1);
            var dot02 = v0.Dot(v2);
            var dot11 = v1.Dot(v1);
            var dot12 = v1.Dot(v2);

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
            int numVertices = poly.Vertices.Count;
            float x = p.X;
            float y = p.Y;
            bool inside = false;

            var p1 = poly.Vertices[0];
            var p2 = new Vector2();

            // loop over each polygon edge
            for (var i = 1; i <= numVertices; i++)
            {
                // get the next point in the polygon
                p2 = poly.Vertices[i % numVertices];

                // check if point is above the min y coord of the edge
                if (y > MathF.Min(p1.Y, p2.Y))
                {
                    // check if point is below the max y coord of the edge
                    if (y <= MathF.Max(p1.Y, p2.Y))
                    {
                        // check if the point is to the left of the max x coord of the edge
                        if (x <= MathF.Max(p1.X, p2.X))
                        {
                            // calculate the x-intersection of the line connecting the point to the edge
                            // ???
                            float xIntersection = (y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;

                            // check if the point is on the same line as the edge or to the left of the x-intersection
                            if (p1.X == p2.X || x <= xIntersection)
                            {
                                inside = !inside;
                            }
                        }
                    }
                }

                // store the current point as the first point for the next iteration
                p1 = p2;
            }

            return inside;
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

        #region [Shape] CONTAINS Line

        /// <summary>
        /// determine if a line contains a line
        /// </summary>
        public static bool Contains(Line l, Line other)
        {
            return l.Contains(other.Start) && l.Contains(other.End);
        }

        /// <summary>
        /// determine if a rectangle contains a line
        /// </summary>
        public static bool Contains(Rectangle r, Line other)
        {
            return r.Contains(other.Start) && r.Contains(other.End);
        }

        /// <summary>
        /// determine if a circle contains a line
        /// </summary>
        public static bool Contains(Circle c, Line other)
        {
            return c.Contains(other.Start) && c.Contains(other.End);
        }

        /// <summary>
        /// determine if a triangle contains a line
        /// </summary>
        public static bool Contains(Triangle t, Line other)
        {
            return t.Contains(other.Start) && t.Contains(other.End);
        }

        /// <summary>
        /// determine if a polygon contains a line
        /// </summary>
        [Obsolete("Polygon CONTAINS Line", false)]
        public static bool Contains(Polygon p, Line other)
        {
            // contains both points and no intersection points
            var contains = p.Contains(other.Start) && p.Contains(other.End);
            var intersections = new List<Vector2>(); // TODO p.Intersects(other)

            return contains && intersections.Count == 0;
        }

        /// <summary>
        /// determine if a ray contains a line
        /// </summary>
        public static bool Contains(Ray r, Line other)
        {
            return r.Contains(other.Start) && r.Contains(other.End);
        }

        #endregion [Shape] CONTAINS Line

        #region [Shape] CONTAINS Rectangle

        /// <summary>
        /// determine if a rectangle contains a rectangle
        /// </summary>
        public static bool Contains(Rectangle r, Rectangle other)
        {
            return r.Contains(other.TopLeft) && r.Contains(other.TopRight) &&
                   r.Contains(other.BottomLeft) && r.Contains(other.BottomRight);
        }

        /// <summary>
        /// determine if a circle contains a rectangle
        /// </summary>
        public static bool Contains(Circle c, Rectangle other)
        {
            return c.Contains(other.TopLeft) && c.Contains(other.TopRight) &&
                   c.Contains(other.BottomLeft) && c.Contains(other.BottomRight);
        }

        /// <summary>
        /// determine if a triangle contains a rectangle
        /// </summary>
        public static bool Contains(Triangle t, Rectangle other)
        {
            return t.Contains(other.TopLeft) && t.Contains(other.TopRight) &&
                   t.Contains(other.BottomLeft) && t.Contains(other.BottomRight);
        }

        /// <summary>
        /// determine if a polygon contains a rectangle
        /// </summary>
        public static bool Contains(Polygon p, Rectangle other)
        {
            return p.Contains(other.Top) && p.Contains(other.Bottom) &&
                   p.Contains(other.Left) && p.Contains(other.Right);
                   
        }

        #endregion [Shape] CONTAINS Rectangle

        #region [Shape] CONTAINS Circle

        /// <summary>
        /// determine if a rectangle contains a circle
        /// </summary>
        public static bool Contains(Rectangle r, Circle other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// determine if a circle contains a circle
        /// </summary>
        public static bool Contains(Circle c, Circle other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// determine if a triangle contains a circle
        /// </summary>
        public static bool Contains(Triangle t, Circle other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// determine if a polygon contains a circle
        /// </summary>
        public static bool Contains(Polygon p, Circle other)
        {
            throw new NotImplementedException();
        }

        #endregion [Shape] CONTAINS Circle

        #region [Shape] CONTAINS Triangle

        /// <summary>
        /// determine if a rectangle contains a triangle
        /// </summary>
        public static bool Contains(Rectangle r, Triangle other)
        {
            return r.Contains(other.Vertices[0]) && r.Contains(other.Vertices[1]) && r.Contains(other.Vertices[2]);
        }

        /// <summary>
        /// determine if a circle contains a triangle
        /// </summary>
        public static bool Contains(Circle c, Triangle other)
        {
            return c.Contains(other.Vertices[0]) && c.Contains(other.Vertices[1]) && c.Contains(other.Vertices[2]);
        }

        /// <summary>
        /// determine if a triangle contains a triangle
        /// </summary>
        public static bool Contains(Triangle t, Triangle other)
        {
            return t.Contains(other.Vertices[0]) && t.Contains(other.Vertices[1]) && t.Contains(other.Vertices[2]);
        }

        /// <summary>
        /// determine if a polygon contains a triangle
        /// </summary>
        public static bool Contains(Polygon p, Triangle other)
        {
            return p.Contains(other.Side(0)) && p.Contains(other.Side(1)) && p.Contains(other.Side(2));
        }

        #endregion [Shape] CONTAINS Triangle

        #region [Shape] CONTAINS Polygon

        /// <summary>
        /// determine if a rectangle contains a polygon
        /// </summary>
        public static bool Contains(Rectangle r, Polygon other)
        {
            for(var i = 0; i < other.Vertices.Count; i++)
            {
                if (!r.Contains(other.Vertices[i])) return false;
            }

            return true;
        }

        /// <summary>
        /// determine if a circle contains a polygon
        /// </summary>
        public static bool Contains(Circle c, Polygon other)
        {
            for (var i = 0; i < other.Vertices.Count; i++)
            {
                if (!c.Contains(other.Vertices[i])) return false;
            }

            return true;
        }

        /// <summary>
        /// determine if a triangle contains a polygon
        /// </summary>
        public static bool Contains(Triangle t, Polygon other)
        {
            for (var i = 0; i < other.Vertices.Count; i++)
            {
                if (!t.Contains(other.Vertices[i])) return false;
            }

            return true;
        }

        /// <summary>
        /// determine if a polygon contains a polygon
        /// </summary>
        public static bool Contains(Polygon p, Polygon other)
        {
            for (var i = 0; i < other.Vertices.Count; i++)
            {
                if (!p.Contains(other.Side(i))) return false;
            }

            return true;
        }

        #endregion [Shape] CONTAINS Polygon
    }
}