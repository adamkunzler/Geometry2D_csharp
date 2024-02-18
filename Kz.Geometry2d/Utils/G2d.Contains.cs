using Kz.Geometry2d.Primitives;
using Kz.DataStructures;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region IShape CONTAINS IShape

        public static bool Contains(IShape lhs, IShape rhs)
        {
            return lhs switch
            {
                Vector2f v => rhs switch
                {
                    Vector2f v2 => Contains(v, v2),
                    //case Line l2: return Contains(v, l2);
                    //case Rectangle r2: return Contains(v, r2);
                    //case Circle c2: return Contains(v, c2);
                    //case Triangle t2: return Contains(v, t2);
                    //case Polygon poly2: return Contains(v, poly2);
                    //case Ray ray2: return Contains(v, ray2);
                    _ => false,
                },
                Line l => rhs switch
                {
                    Vector2f v2 => Contains(l, v2),
                    Line l2 => Contains(l, l2),
                    //case Rectangle r2: return Contains(l, r2);
                    //case Circle c2: return Contains(l, c2);
                    //case Triangle t2: return Contains(l, t2);
                    //case Polygon poly2: return Contains(l, poly2);
                    //case Ray ray2: return Contains(l, ray2);
                    _ => false,
                },
                Rectangle r => rhs switch
                {
                    Vector2f v2 => Contains(r, v2),
                    Line l2 => Contains(r, l2),
                    Rectangle r2 => Contains(r, r2),
                    Circle c2 => Contains(r, c2),
                    Triangle t2 => Contains(r, t2),
                    Polygon poly2 => Contains(r, poly2),
                    //case Ray ray2: return Contains(r, ray2);
                    Ellipse x => Contains(r, x),
                    _ => false,
                },
                Circle c => rhs switch
                {
                    Vector2f v2 => Contains(c, v2),
                    Line l2 => Contains(c, l2),
                    Rectangle r2 => Contains(c, r2),
                    Circle c2 => Contains(c, c2),
                    Triangle t2 => Contains(c, t2),
                    Polygon poly2 => Contains(c, poly2),
                    //case Ray ray2: return Contains(c, ray2);
                    Ellipse x => Contains(c, x),
                    _ => false,
                },
                Triangle t => rhs switch
                {
                    Vector2f v2 => Contains(t, v2),
                    Line l2 => Contains(t, l2),
                    Rectangle r2 => Contains(t, r2),
                    Circle c2 => Contains(t, c2),
                    Triangle t2 => Contains(t, t2),
                    Polygon poly2 => Contains(t, poly2),
                    //case Ray ray2: return Contains(t, ray2);
                    Ellipse x => Contains(t, x),
                    _ => false,
                },
                Polygon poly => rhs switch
                {
                    Vector2f v2 => Contains(poly, v2),
                    Line l2 => Contains(poly, l2),
                    Rectangle r2 => Contains(poly, r2),
                    Circle c2 => Contains(poly, c2),
                    Triangle t2 => Contains(poly, t2),
                    Polygon poly2 => Contains(poly, poly2),
                    //case Ray ray2: return Contains(poly, ray2);
                    Ellipse x => Contains(poly, x),
                    _ => false,
                },
                Ray ray => rhs switch
                {
                    Vector2f v2 => Contains(ray, v2),
                    Line l2 => Contains(ray, l2),
                    //case Rectangle r2: return Contains(ray, r2);
                    //case Circle c2: return Contains(ray, c2);
                    //case Triangle t2: return Contains(ray, t2);
                    //case Polygon poly2: return Contains(ray, poly2);
                    //case Ray ray2: return Contains(ray, ray2);
                    _ => false,
                },
                Ellipse e => rhs switch
                {
                    Vector2f x => Contains(e, x),
                    Line x => Contains(e, x),
                    Rectangle x => Contains(e, x),
                    Circle x => Contains(e, x),
                    Triangle x => Contains(e, x),
                    Polygon x => Contains(e, x),
                    //Ray x => Contains(e, x),
                    Ellipse x => Contains(e, x),
                    _ => false,
                },
                _ => false,
            };
        }

        #endregion IShape CONTAINS IShape

        #region [Shape] CONTAINS Point

        /// <summary>
        /// determine if a point contains a point
        /// </summary>
        public static bool Contains(Vector2f p, Vector2f other)
        {
            // get the magnitude squared of the vector p pointing to other
            var mag2 = (p - other).Magnitude2();
            return mag2 <= Consts.EPSILON;
        }

        /// <summary>
        /// determine if a line contains a point
        /// </summary>
        public static bool Contains(Line l, Vector2f p)
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
        public static bool Contains(Rectangle r, Vector2f p)
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
        public static bool Contains(Circle c, Vector2f p)
        {
            var mag2 = (p - c.Origin).Magnitude2();
            return mag2 < (c.Radius * c.Radius);
        }

        /// <summary>
        /// determine if a triangle contains a point
        /// </summary>
        public static bool Contains(Triangle t, Vector2f p)
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
        public static bool Contains(Polygon poly, Vector2f p)
        {
            int numVertices = poly.Vertices.Count;
            float x = p.X;
            float y = p.Y;
            bool inside = false;

            var p1 = poly.Vertices[0];
            var p2 = new Vector2f();

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
        public static bool Contains(Ray r, Vector2f p)
        {
            var originPoint = p - r.Origin;

            var dot = originPoint.Dot(r.Direction);

            // point is behind origin
            if (dot < 0) return false;

            // project originPoint onto ray's direction
            var projection = new Vector2f(r.Direction.X * dot, r.Direction.Y * dot);

            // check if projection is same as originPoint
            var x = projection.X - originPoint.X;
            var y = projection.Y - originPoint.Y;
            var distance = MathF.Sqrt(x * x + y * y);

            return distance < Consts.EPSILON;
        }

        /// <summary>
        /// determine if an ellipse contains a point
        /// </summary>
        /// <returns></returns>
        public static bool Contains(Ellipse lhs, Vector2f rhs)
        {
            var translated = rhs - lhs.Origin;
            var left = (translated.X * translated.X) / (lhs.A * lhs.A);
            var right = (translated.Y * translated.Y) / (lhs.B * lhs.B);
            return (left + right) <= 1.0 + Consts.EPSILON;
        }

        #endregion [Shape] CONTAINS Point

        #region [Shape] CONTAINS Line

        /// <summary>
        /// determine if a line contains a line
        /// </summary>
        public static bool Contains(Line l, Line other)
        {
            return Contains(l, other.Start) && Contains(l, other.End);
        }

        /// <summary>
        /// determine if a rectangle contains a line
        /// </summary>
        public static bool Contains(Rectangle r, Line other)
        {
            return Contains(r, other.Start) && Contains(r, other.End);
        }

        /// <summary>
        /// determine if a circle contains a line
        /// </summary>
        public static bool Contains(Circle c, Line other)
        {
            return Contains(c, other.Start) && Contains(c, other.End);
        }

        /// <summary>
        /// determine if a triangle contains a line
        /// </summary>
        public static bool Contains(Triangle t, Line other)
        {
            return Contains(t, other.Start) && Contains(t, other.End);
        }

        /// <summary>
        /// determine if a polygon contains a line
        /// </summary>
        public static bool Contains(Polygon p, Line other)
        {
            // contains both points and no intersection points
            var contains = Contains(p, other.Start) && Contains(p, other.End);
            var intersections = Intersects(p, other);

            return contains && intersections.Count == 0;
        }

        /// <summary>
        /// determine if a ray contains a line
        /// </summary>
        public static bool Contains(Ray r, Line other)
        {
            return Contains(r, other.Start) && Contains(r, other.End);
        }

        /// <summary>
        /// determine if an ellipse contains a line
        /// </summary>
        public static bool Contains(Ellipse lhs, Line rhs)
        {
            return Contains(lhs, rhs.Start) && Contains(lhs, rhs.End);
        }

        #endregion [Shape] CONTAINS Line

        #region [Shape] CONTAINS Rectangle

        /// <summary>
        /// determine if a rectangle contains a rectangle
        /// </summary>
        public static bool Contains(Rectangle r, Rectangle other)
        {
            return Contains(r, other.TopLeft) && Contains(r, other.TopRight) &&
                   Contains(r, other.BottomLeft) && Contains(r, other.BottomRight);
        }

        /// <summary>
        /// determine if a circle contains a rectangle
        /// </summary>
        public static bool Contains(Circle c, Rectangle other)
        {
            return Contains(c, other.TopLeft) && Contains(c, other.TopRight) &&
                   Contains(c, other.BottomLeft) && Contains(c, other.BottomRight);
        }

        /// <summary>
        /// determine if a triangle contains a rectangle
        /// </summary>
        public static bool Contains(Triangle t, Rectangle other)
        {
            return Contains(t, other.TopLeft) && Contains(t, other.TopRight) &&
                   Contains(t, other.BottomLeft) && Contains(t, other.BottomRight);
        }

        /// <summary>
        /// determine if a polygon contains a rectangle
        /// </summary>
        public static bool Contains(Polygon p, Rectangle other)
        {
            return Contains(p, other.Top) && Contains(p, other.Bottom) &&
                   Contains(p, other.Left) && Contains(p, other.Right);
        }

        /// <summary>
        /// determine if an ellipse contains a rectangle
        /// </summary>
        public static bool Contains(Ellipse lhs, Rectangle rhs)
        {
            return Contains(lhs, rhs.TopLeft) && Contains(lhs, rhs.TopRight) &&
                   Contains(lhs, rhs.BottomLeft) && Contains(lhs, rhs.BottomRight); ;
        }

        #endregion [Shape] CONTAINS Rectangle

        #region [Shape] CONTAINS Circle

        /// <summary>
        /// determine if a rectangle contains a circle
        /// </summary>
        public static bool Contains(Rectangle r, Circle other)
        {
            bool leftEdgeCheck = r.Position.X <= other.Origin.X - other.Radius;
            bool rightEdgeCheck = r.Position.X + r.Size.Width >= other.Origin.X + other.Radius;
            bool topEdgeCheck = r.Position.Y <= other.Origin.Y - other.Radius;
            bool bottomEdgeCheck = r.Position.Y + r.Size.Height >= other.Origin.Y + other.Radius;

            return leftEdgeCheck && rightEdgeCheck && topEdgeCheck && bottomEdgeCheck;
        }

        /// <summary>
        /// determine if a circle contains a circle
        /// </summary>
        public static bool Contains(Circle c, Circle other)
        {
            var x = other.Origin.X - c.Origin.X;
            var y = other.Origin.Y - c.Origin.Y;
            var centerDistance = MathF.Sqrt(x * x + y * y);
            return centerDistance + other.Radius <= c.Radius && c.Radius > other.Radius;
        }

        /// <summary>
        /// determine if a triangle contains a circle
        /// </summary>
        public static bool Contains(Triangle t, Circle other)
        {
            // check if center is in triangle
            var isCenterContained = Contains(t, other.Origin);
            if (!isCenterContained) return false;

            // check if distance from center to each side of triangle is greater than the radius
            var distance1 = DistanceTo(other.Origin, t.Side(0));
            var distance2 = DistanceTo(other.Origin, t.Side(1));
            var distance3 = DistanceTo(other.Origin, t.Side(2));

            return distance1 >= other.Radius && distance2 >= other.Radius && distance3 >= other.Radius;
        }

        /// <summary>
        /// determine if a polygon contains a circle
        /// </summary>
        public static bool Contains(Polygon p, Circle other)
        {
            // check if center is in polygon
            var isCenterContained = Contains(p, other.Origin);
            if (!isCenterContained) return false;

            // check if distance from center to each side of polygon is greater than the radius
            for (var i = 0; i < p.NumSides(); i++)
            {
                var distance = DistanceTo(other.Origin, p.Side(i));
                if (distance < other.Radius) return false;
            }

            return true;
        }

        /// <summary>
        /// Determine if an ellipse contains a circle
        /// </summary>
        public static bool Contains(Ellipse lhs, Circle rhs)
        {
            var d = rhs.Origin - lhs.Origin;

            var left = (d.X / lhs.A) * (d.X / lhs.A);
            var middle = (d.Y / lhs.B) * (d.Y / lhs.B);
            var right = rhs.Radius / MathF.Min(lhs.A, lhs.B);

            return MathF.Sqrt(left + middle) + right <= 1.0f;
        }

        #endregion [Shape] CONTAINS Circle

        #region [Shape] CONTAINS Triangle

        /// <summary>
        /// determine if a rectangle contains a triangle
        /// </summary>
        public static bool Contains(Rectangle r, Triangle other)
        {
            return Contains(r, other.Vertices[0]) && Contains(r, other.Vertices[1]) && Contains(r, other.Vertices[2]);
        }

        /// <summary>
        /// determine if a circle contains a triangle
        /// </summary>
        public static bool Contains(Circle c, Triangle other)
        {
            return Contains(c, other.Vertices[0]) && Contains(c, other.Vertices[1]) && Contains(c, other.Vertices[2]);
        }

        /// <summary>
        /// determine if a triangle contains a triangle
        /// </summary>
        public static bool Contains(Triangle t, Triangle other)
        {
            return Contains(t, other.Vertices[0]) && Contains(t, other.Vertices[1]) && Contains(t, other.Vertices[2]);
        }

        /// <summary>
        /// determine if a polygon contains a triangle
        /// </summary>
        public static bool Contains(Polygon p, Triangle other)
        {
            return Contains(p, other.Side(0)) && Contains(p, other.Side(1)) && Contains(p, other.Side(2));
        }

        /// <summary>
        /// determine if an ellipse contains a triangle
        /// </summary>
        public static bool Contains(Ellipse lhs, Triangle rhs)
        {
            return Contains(lhs, rhs.Vertices[0]) && Contains(lhs, rhs.Vertices[1]) && Contains(lhs, rhs.Vertices[2]);
        }

        #endregion [Shape] CONTAINS Triangle

        #region [Shape] CONTAINS Polygon

        /// <summary>
        /// determine if a rectangle contains a polygon
        /// </summary>
        public static bool Contains(Rectangle r, Polygon other)
        {
            for (var i = 0; i < other.Vertices.Count; i++)
            {
                if (!Contains(r, other.Vertices[i])) return false;
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
                if (!Contains(c, other.Vertices[i])) return false;
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
                if (!Contains(t, other.Vertices[i])) return false;
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
                if (!Contains(p, other.Side(i))) return false;
            }

            return true;
        }

        /// <summary>
        /// determine if an ellipse contains a polygon
        /// </summary>
        public static bool Contains(Ellipse lhs, Polygon rhs)
        {
            foreach (var vertex in rhs.Vertices)
            {
                if (!Contains(lhs, vertex)) return false;
            }

            return true;
        }

        #endregion [Shape] CONTAINS Polygon

        #region [Shape] CONTAINS Ellipse

        /// <summary>
        /// determine if a rectangle contins an ellipse
        /// </summary>
        public static bool Contains(Rectangle lhs, Ellipse rhs)
        {
            return false;
        }

        /// <summary>
        /// determine if a Circle contins an ellipse
        /// </summary>
        public static bool Contains(Circle lhs, Ellipse rhs)
        {
            return false;
        }

        /// <summary>
        /// determine if a Triangle contins an ellipse
        /// </summary>
        public static bool Contains(Triangle lhs, Ellipse rhs)
        {
            return false;
        }

        /// <summary>
        /// determine if a Polygon contins an ellipse
        /// </summary>
        public static bool Contains(Polygon lhs, Ellipse rhs)
        {
            return false;
        }

        /// <summary>
        /// determine if a Ellipse contins an ellipse
        /// </summary>
        public static bool Contains(Ellipse lhs, Ellipse rhs)
        {
            return false;
        }

        #endregion [Shape] CONTAINS Ellipse
    }
}