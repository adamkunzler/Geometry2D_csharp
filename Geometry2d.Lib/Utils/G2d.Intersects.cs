using Geometry2d.Lib.Extensions;
using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {

        #region [Shape] INTERSECTS Point

        /// <summary>
        /// return intersection points of a point and a point
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Vector2 other)
        {
            var intersections = new List<Vector2>();

            if (p.Contains(other)) intersections.Add(p);

            return intersections;
        }

        /// <summary>
        /// return intersection points of a line and a point
        /// </summary>
        public static List<Vector2> Intersects(Line l, Vector2 other)
        {
            var intersections = new List<Vector2>();

            if (l.Contains(other)) intersections.Add(other);

            return intersections;
        }

        /// <summary>
        /// return intersection points of a rectangle and a point
        /// </summary>
        public static List<Vector2> Intersects(Rectangle r, Vector2 other)
        {
            var intersections = new List<Vector2>();

            foreach (var side in r.Sides)
            {
                if (side.Contains(other)) intersections.Add(other);
            }
            
            return intersections;
        }

        /// <summary>
        /// return intersection points of a circle and a point
        /// </summary>
        public static List<Vector2> Intersects(Circle c, Vector2 other)
        {
            var intersections = new List<Vector2>();

            var distance = new Line(c.Position, other).Length();
            if((distance >= c.Radius - Consts.EPSILON) && (distance <= c.Radius + Consts.EPSILON))            
                intersections.Add(other);

            return intersections;
        }

        /// <summary>
        /// return intersection points of a triangle and a point
        /// </summary>
        public static List<Vector2> Intersects(Triangle t, Vector2 other)
        {
            var intersections = new List<Vector2>();

            for (var i = 0; i < 3; i++)
            {
                if (t.Side(i).Contains(other)) intersections.Add(other);
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a polygon and a point
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Vector2 other)
        {
            var intersections = new List<Vector2>();

            for(var i = 0; i < p.NumSides(); i++)
            {
                if (p.Side(i).Contains(other)) intersections.Add(other);
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a ray and a point
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Vector2 other)
        {
            var intersections = new List<Vector2>();

            if(r.Contains(other)) intersections.Add(other);

            return intersections;
        }

        #endregion [Shape] INTERSECTS Point

        #region [Shape] INTERSECTS Line

        /// <summary>
        /// return intersection points of a point and a line
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Line other)
        {
            var intersections = new List<Vector2>();

            if (other.Contains(p)) intersections.Add(p);            

            return intersections;
        }

        /// <summary>
        /// return intersection points of a line and a line
        /// </summary>
        public static List<Vector2> Intersects(Line l, Line other)
        {
            var intersections = new List<Vector2>();

            var Ax = l.Start.X;
            var Ay = l.Start.Y;
            var Bx = l.End.X;
            var By = l.End.Y;
            var Cx = other.Start.X;
            var Cy = other.Start.Y;
            var Dx = other.End.X;
            var Dy = other.End.Y;

            var determinant = (Bx - Ax) * (Dy - Cy) - (By - Ay) * (Dx - Cx);
            if (determinant == 0) return intersections; // lines are parallel

            var t = ((Cx - Ax) * (Dy - Cy) - (Cy - Ay) * (Dx - Cx)) / determinant;
            var u = ((Cx - Ax) * (By - Ay) - (Cy - Ay) * (Bx - Ax)) / determinant;

            if(t >= 0 && t <= 1 && u>= 0 && u <= 1)
            {
                var x = Ax + t * (Bx - Ax);
                var y = Ay + t * (By - Ay);
                intersections.Add(new Vector2(x, y));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a rectangle and a line
        /// </summary>
        public static List<Vector2> Intersects(Rectangle r, Line other)
        {
            var intersections = new List<Vector2>();

            foreach(var side in r.Sides)
            {
                intersections.AddRange(side.Intersects(other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a circle and a line
        /// </summary>
        public static List<Vector2> Intersects(Circle circle, Line other)
        {
            var intersections = new List<Vector2>();

            var h = circle.Position.X;
            var k = circle.Position.Y;
            var r = circle.Radius;
            var x1 = other.Start.X;
            var y1 = other.Start.Y;
            var x2 = other.End.X;
            var y2 = other.End.Y;

            var a = MathF.Pow(x2 - x1, 2) + MathF.Pow(y2 - y1, 2);
            var b = 2.0f * ((x2 - x1) * (x1 - h) + (y2 - y1) * (y1 - k));
            var c = MathF.Pow(x1 - h, 2) + MathF.Pow(y1 - k, 2) - MathF.Pow(r, 2);
            var discriminant = b * b - (4.0f * a * c);

            // < 0 = no intersections
            // = 0 = 1 intersection
            // >0 = 2 intersections
            if(discriminant < 0) return intersections; // not intersections

            // solve quadratic equation to find intersection points
            var t1 = (-b + MathF.Sqrt(discriminant)) / (2.0f * a);
            var t2 = (-b - MathF.Sqrt(discriminant)) / (2.0f * a);

            // first intersection
            if(t1 >= 0 && t1 <= 1)
            {
                var ix1 = x1 + t1 * (x2 - x1);
                var iy1 = y1 + t1 * (y2 - y1);
                intersections.Add(new Vector2(ix1, iy1));
            }

            // second intersection
            if(t2 >= 0 && t2 <= 1 && discriminant > 0)
            {
                var ix2 = x1 + t2 * (x2 - x1);
                var iy2 = y1 + t2 * (y2 - y1);
                intersections.Add(new Vector2( ix2, iy2));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a triangle and a line
        /// </summary>
        public static List<Vector2> Intersects(Triangle t, Line other)
        {
            var intersections = new List<Vector2>();

            foreach (var side in t.Sides)
            {
                intersections.AddRange(side.Intersects(other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a polygon and a line
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Line other)
        {
            var intersections = new List<Vector2>();

            for(var i = 0; i < p.NumSides(); i++)
            {
                intersections.AddRange(p.Side(i).Intersects(other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a ray and a line
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Line other)
        {
            var intersections = new List<Vector2>();

            var Ax = other.Start.X;
            var Ay = other.Start.Y;
            var Bx = other.End.X;
            var By = other.End.Y;
            var Sx = r.Origin.X;
            var Sy = r.Origin.Y;
            var Dx = r.Direction.X;
            var Dy = r.Direction.Y;

            var tNumerator = (Sx - Ax) * Dy - (Sy - Ay) * Dx;
            var uNumerator = (Ax - Sx) * (Ay - By) - (Ay - Sy) * (Ax - Bx);
            var denominator = (Bx - Ax) * Dy - (By - Ay) * Dx;

            if (denominator == 0) return intersections; // no intersection

            var t = tNumerator / denominator;
            var u = uNumerator / denominator;

            if(t >= 0 && t <= 1 && u >= 0)
            {
                var x = Ax + t * (Bx - Ax);
                var y = Ay + t * (By - Ay);
                intersections.Add(new Vector2(x, y));
            }

            return intersections;
        }

        #endregion [Shape] INTERSECTS Line
    }
}
