using Geometry2d.Lib.Primitives;

namespace Geometry2d.Lib.Utils
{
    public static partial class G2d
    {
        #region IShape INTERSECTS IShape

        public static List<Vector2> Intersects(IShape lhs, IShape rhs)
        {
            return lhs switch
            {
                Vector2 v => rhs switch
                {
                    Vector2 v2 => Intersects(v, v2),
                    Line l2 => Intersects(v, l2),
                    Rectangle r2 => Intersects(v, r2),
                    Circle c2 => Intersects(v, c2),
                    Triangle t2 => Intersects(v, t2),
                    Polygon poly2 => Intersects(v, poly2),
                    Ray ray2 => Intersects(v, ray2),
                    _ => new List<Vector2>(),
                },
                Line l => rhs switch
                {
                    Vector2 v2 => Intersects(l, v2),
                    Line l2 => Intersects(l, l2),
                    Rectangle r2 => Intersects(l, r2),
                    Circle c2 => Intersects(l, c2),
                    Triangle t2 => Intersects(l, t2),
                    Polygon poly2 => Intersects(l, poly2),
                    Ray ray2 => Intersects(l, ray2),
                    _ => new List<Vector2>(),
                },
                Rectangle r => rhs switch
                {
                    Vector2 v2 => Intersects(r, v2),
                    Line l2 => Intersects(r, l2),
                    Rectangle r2 => Intersects(r, r2),
                    Circle c2 => Intersects(r, c2),
                    Triangle t2 => Intersects(r, t2),
                    Polygon poly2 => Intersects(r, poly2),
                    Ray ray2 => Intersects(r, ray2),
                    _ => new List<Vector2>(),
                },
                Circle c => rhs switch
                {
                    Vector2 v2 => Intersects(c, v2),
                    Line l2 => Intersects(c, l2),
                    Rectangle r2 => Intersects(c, r2),
                    Circle c2 => Intersects(c, c2),
                    Triangle t2 => Intersects(c, t2),
                    Polygon poly2 => Intersects(c, poly2),
                    Ray ray2 => Intersects(c, ray2),
                    _ => new List<Vector2>(),
                },
                Triangle t => rhs switch
                {
                    Vector2 v2 => Intersects(t, v2),
                    Line l2 => Intersects(t, l2),
                    Rectangle r2 => Intersects(t, r2),
                    Circle c2 => Intersects(t, c2),
                    Triangle t2 => Intersects(t, t2),
                    Polygon poly2 => Intersects(t, poly2),
                    Ray ray2 => Intersects(t, ray2),
                    _ => new List<Vector2>(),
                },
                Polygon poly => rhs switch
                {
                    Vector2 v2 => Intersects(poly, v2),
                    Line l2 => Intersects(poly, l2),
                    Rectangle r2 => Intersects(poly, r2),
                    Circle c2 => Intersects(poly, c2),
                    Triangle t2 => Intersects(poly, t2),
                    Polygon poly2 => Intersects(poly, poly2),
                    Ray ray2 => Intersects(poly, ray2),
                    _ => new List<Vector2>(),
                },
                Ray ray => rhs switch
                {
                    Vector2 v2 => Intersects(ray, v2),
                    Line l2 => Intersects(ray, l2),
                    Rectangle r2 => Intersects(ray, r2),
                    Circle c2 => Intersects(ray, c2),
                    Triangle t2 => Intersects(ray, t2),
                    Polygon poly2 => Intersects(ray, poly2),
                    Ray ray2 => Intersects(ray, ray2),
                    _ => new List<Vector2>(),
                },
                _ => new List<Vector2>(),
            };
        }

        #endregion IShape INTERSECTS IShape

        #region [Shape] INTERSECTS Point

        /// <summary>
        /// return intersection points of a point and a point
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Vector2 other)
        {
            var intersections = new List<Vector2>();

            if (Contains(p, other)) intersections.Add(p);

            return intersections;
        }

        /// <summary>
        /// return intersection points of a line and a point
        /// </summary>
        public static List<Vector2> Intersects(Line l, Vector2 other)
        {
            var intersections = new List<Vector2>();

            if (Contains(l, other)) intersections.Add(other);

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
                if (Contains(side, other)) intersections.Add(other);
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a circle and a point
        /// </summary>
        public static List<Vector2> Intersects(Circle c, Vector2 other)
        {
            var intersections = new List<Vector2>();

            var distance = new Line(c.Origin, other).Length();
            if ((distance >= c.Radius - Consts.EPSILON) && (distance <= c.Radius + Consts.EPSILON))
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
                if (Contains(t.Side(i), other)) intersections.Add(other);
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a polygon and a point
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Vector2 other)
        {
            var intersections = new List<Vector2>();

            for (var i = 0; i < p.NumSides(); i++)
            {
                if (Contains(p.Side(i), other)) intersections.Add(other);
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a ray and a point
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Vector2 other)
        {
            var intersections = new List<Vector2>();

            if (Contains(r, other)) intersections.Add(other);

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

            if (Contains(other, p)) intersections.Add(p);

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

            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
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

            foreach (var side in r.Sides)
            {
                intersections.AddRange(Intersects(side, other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a circle and a line
        /// </summary>
        public static List<Vector2> Intersects(Circle circle, Line other)
        {
            var intersections = new List<Vector2>();

            var h = circle.Origin.X;
            var k = circle.Origin.Y;
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
            if (discriminant < 0) return intersections; // not intersections

            // solve quadratic equation to find intersection points
            var t1 = (-b + MathF.Sqrt(discriminant)) / (2.0f * a);
            var t2 = (-b - MathF.Sqrt(discriminant)) / (2.0f * a);

            // first intersection
            if (t1 >= 0 && t1 <= 1)
            {
                var ix1 = x1 + t1 * (x2 - x1);
                var iy1 = y1 + t1 * (y2 - y1);
                intersections.Add(new Vector2(ix1, iy1));
            }

            // second intersection
            if (t2 >= 0 && t2 <= 1 && discriminant > 0)
            {
                var ix2 = x1 + t2 * (x2 - x1);
                var iy2 = y1 + t2 * (y2 - y1);
                intersections.Add(new Vector2(ix2, iy2));
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
                intersections.AddRange(Intersects(side, other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a polygon and a line
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Line other)
        {
            var intersections = new List<Vector2>();

            for (var i = 0; i < p.NumSides(); i++)
            {
                intersections.AddRange(Intersects(p.Side(i), other));
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

            if (t >= 0 && t <= 1 && u >= 0)
            {
                var x = Ax + t * (Bx - Ax);
                var y = Ay + t * (By - Ay);
                intersections.Add(new Vector2(x, y));
            }

            return intersections;
        }

        #endregion [Shape] INTERSECTS Line

        #region [Shape] INTERSECTS Rectangle

        /// <summary>
        /// return intersection points of a point and a rectangle
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Rectangle other)
        {            
            return Intersects(other, p);
        }

        /// <summary>
        /// return intersection points of a line and a rectangle
        /// </summary>
        public static List<Vector2> Intersects(Line l, Rectangle other)
        {
            return Intersects(other, l);
        }

        /// <summary>
        /// return intersection points of a rectangle and a rectangle
        /// </summary>
        public static List<Vector2> Intersects(Rectangle r, Rectangle other)
        {
            var intersections = new List<Vector2>();

            foreach(var side in r.Sides)
            {
                intersections.AddRange(Intersects(side, other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a circle and a rectangle
        /// </summary>
        public static List<Vector2> Intersects(Circle c, Rectangle other)
        {
            var intersections = new List<Vector2>();

            foreach (var side in other.Sides)
            {
                intersections.AddRange(Intersects(c, side));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a triangle and a rectangle
        /// </summary>
        public static List<Vector2> Intersects(Triangle t, Rectangle other)
        {
            var intersections = new List<Vector2>();

            foreach (var rectSide in other.Sides)
            {
                foreach (var triSide in t.Sides)
                {
                    intersections.AddRange(Intersects(rectSide, triSide));
                }
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a polygon and a rectangle
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Rectangle other)
        {
            var intersections = new List<Vector2>();

            foreach (var rectSide in other.Sides)
            {
                for(var i = 0; i < p.NumSides(); i++)
                {
                    intersections.AddRange(Intersects(rectSide, p.Side(i)));
                }
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a ray and a rectangle
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Rectangle other)
        {
            var intersections = new List<Vector2>();

            foreach (var side in other.Sides)
            {
                intersections.AddRange(Intersects(r, side));
            }

            return intersections;
        }

        #endregion [Shape] INTERSECTS Rectangle

        #region [Shape] INTERSECTS Circle

        /// <summary>
        /// return intersection points of a point and a circle
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Circle other)
        {
            return Intersects(other, p);
        }

        /// <summary>
        /// return intersection points of a line and a circle
        /// </summary>
        public static List<Vector2> Intersects(Line l, Circle other)
        {
            return Intersects(other, l);
        }

        /// <summary>
        /// return intersection points of a rectangle and a circle
        /// </summary>
        public static List<Vector2> Intersects(Rectangle r, Circle other)
        {
            var intersections = new List<Vector2>();

            foreach (var side in r.Sides)
            {
                intersections.AddRange(Intersects(other, side));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a circle and a circle
        /// </summary>
        public static List<Vector2> Intersects(Circle c, Circle other)
        {
            var intersections = new List<Vector2>();

            var x1 = c.Origin.X;
            var y1 = c.Origin.Y;
            var r1 = c.Radius;
            var x2 = other.Origin.X;
            var y2 = other.Origin.Y;
            var r2 = other.Radius;

            var d = MathF.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            if (d > r1 + r2 || d < Math.Abs(r1 - r2) || (d == 0 && r1 == r2))
            {
                // No intersection or circles are coincident
                return intersections;
            }

            var a = (r1 * r1 - r2 * r2 + d * d) / (2 * d);
            var h = MathF.Sqrt(r1 * r1 - a * a);
            var x3 = x1 + a * (x2 - x1) / d;
            var y3 = y1 + a * (y2 - y1) / d;

            var ix1 = x3 + h * (y2 - y1) / d;
            var iy1 = y3 - h * (x2 - x1) / d;
            var ix2 = x3 - h * (y2 - y1) / d;
            var iy2 = y3 + h * (x2 - x1) / d;

            intersections.Add(new Vector2(ix1, iy1));
            
            if (h > 0) // Checks if there are two distinct intersection points
            {
                intersections.Add(new Vector2(ix2, iy2));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a triangle and a circle
        /// </summary>
        public static List<Vector2> Intersects(Triangle t, Circle other)
        {
            var intersections = new List<Vector2>();
            
            foreach (var triSide in t.Sides)
            {
                intersections.AddRange(Intersects(other, triSide));
            }            

            return intersections;
        }

        /// <summary>
        /// return intersection points of a polygon and a circle
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Circle other)
        {
            var intersections = new List<Vector2>();

            for(var i = 0; i < p.NumSides(); i++)
            {
                intersections.AddRange(Intersects(other, p.Side(i)));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a ray and a circle
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Circle other)
        {
            var intersections = new List<Vector2>();

            var x0 = r.Origin.X;
            var y0 = r.Origin.Y;
            var dx = r.Direction.X;
            var dy = r.Direction.Y;
            var h = other.Origin.X;
            var k = other.Origin.Y;
            var radius = other.Radius;

            var a = dx * dx + dy * dy;
            var b = 2.0f * (dx * (x0 - h) + dy * (y0 - k));
            var c = (x0 - h) * (x0 - h) + (y0 - k) * (y0 - k) - (radius * radius);
            var discriminant = b * b - (4.0f * a * c);

            if (discriminant < 0) return intersections;

            var t1 = (-b + MathF.Sqrt(discriminant)) / (2.0f * a);
            var t2 = (-b - MathF.Sqrt(discriminant)) / (2.0f * a);

            if(t1 >= 0)
            {
                var ix1 = x0 + t1 * dx;
                var iy1 = y0 + t1 * dy;
                intersections.Add(new Vector2(ix1, iy1));
            }

            if(t2 >= 0 && discriminant > 0)
            {
                var ix2 = x0 + t2 * dx;
                var iy2 = y0 + t2 * dy;
                intersections.Add(new Vector2(ix2, iy2));
            }

            // if discriminant == 0 then ray is tangent to circle

            return intersections;
        }

        #endregion [Shape] INTERSECTS Circle

        #region [Shape] INTERSECTS Triangle

        /// <summary>
        /// return intersection points of a point and a triangle
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Triangle other)
        {
            return Intersects(other, p);
        }

        /// <summary>
        /// return intersection points of a line and a triangle
        /// </summary>
        public static List<Vector2> Intersects(Line l, Triangle other)
        {
            return Intersects(other, l);
        }

        /// <summary>
        /// return intersection points of a rectangle and a triangle
        /// </summary>
        public static List<Vector2> Intersects(Rectangle r, Triangle other)
        {
            return Intersects(other, r);
        }

        /// <summary>
        /// return intersection points of a circle and a triangle
        /// </summary>
        public static List<Vector2> Intersects(Circle c, Triangle other)
        {
            return Intersects(other, c);
        }

        /// <summary>
        /// return intersection points of a triangle and a triangle
        /// </summary>
        public static List<Vector2> Intersects(Triangle t, Triangle other)
        {
            var intersections = new List<Vector2>();

            foreach(var side in t.Sides)
            {
                intersections.AddRange(Intersects(side, other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a polygon and a triangle
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Triangle other)
        {
            var intersections = new List<Vector2>();

            for(var i = 0; i < p.NumSides(); i++)
            {
                intersections.AddRange(Intersects(p.Side(i), other));
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a ray and a triangle
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Triangle other)
        {
            var intersections = new List<Vector2>();

            foreach(var side in other.Sides)
            {
                intersections.AddRange(Intersects(r, side));
            }

            return intersections;
        }

        #endregion [Shape] INTERSECTS Circle

        #region [Shape] INTERSECTS Polygon

        /// <summary>
        /// return intersection points of a point and a polygon
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Polygon other)
        {
            return Intersects(other, p);
        }

        /// <summary>
        /// return intersection points of a line and a polygon
        /// </summary>
        public static List<Vector2> Intersects(Line l, Polygon other)
        {
            return Intersects(other, l);
        }

        /// <summary>
        /// return intersection points of a rectangle and a polygon
        /// </summary>
        public static List<Vector2> Intersects(Rectangle r, Polygon other)
        {
            return Intersects(other, r);
        }

        /// <summary>
        /// return intersection points of a circle and a polygon
        /// </summary>
        public static List<Vector2> Intersects(Circle c, Polygon other)
        {
            return Intersects(other, c);
        }

        /// <summary>
        /// return intersection points of a triangle and a polygon
        /// </summary>
        public static List<Vector2> Intersects(Triangle t, Polygon other)
        {
            return Intersects(other, t);
        }

        /// <summary>
        /// return intersection points of a polygon and a polygon
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Polygon other)
        {
            var intersections = new List<Vector2>();

            for(int i = 0; i < p.NumSides(); i++)
            {
                for(int j = 0; j < other.NumSides(); j++)
                {
                    intersections.AddRange(Intersects(p.Side(i), other.Side(j)));
                }
            }

            return intersections;
        }

        /// <summary>
        /// return intersection points of a ray and a polygon
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Polygon other)
        {
            var intersections = new List<Vector2>();

            for (int i = 0; i < other.NumSides(); i++)
            {
                intersections.AddRange(Intersects(r, other.Side(i)));
            }
            
            return intersections;
        }

        #endregion [Shape] INTERSECTS Polygon

        #region [Shape] INTERSECTS Ray

        /// <summary>
        /// return intersection points of a point and a ray
        /// </summary>
        public static List<Vector2> Intersects(Vector2 p, Ray other)
        {
            return Intersects(other, p);
        }

        /// <summary>
        /// return intersection points of a line and a ray
        /// </summary>
        public static List<Vector2> Intersects(Line l, Ray other)
        {
            return Intersects(other, l);
        }

        /// <summary>
        /// return intersection points of a rectangle and a ray
        /// </summary>
        public static List<Vector2> Intersects(Rectangle r, Ray other)
        {
            return Intersects(other, r);
        }

        /// <summary>
        /// return intersection points of a circle and a ray
        /// </summary>
        public static List<Vector2> Intersects(Circle c, Ray other)
        {
            return Intersects(other, c);
        }

        /// <summary>
        /// return intersection points of a triangle and a ray
        /// </summary>
        public static List<Vector2> Intersects(Triangle t, Ray other)
        {
            return Intersects(other, t);
        }

        /// <summary>
        /// return intersection points of a polygon and a ray
        /// </summary>
        public static List<Vector2> Intersects(Polygon p, Ray other)
        {
            return Intersects(other, p);            
        }

        /// <summary>
        /// return intersection points of a ray and a ray
        /// </summary>
        public static List<Vector2> Intersects(Ray r, Ray other)
        {
            var intersections = new List<Vector2>();

            var x1 = r.Origin.X;
            var y1 = r.Origin.Y;
            var dx1 = r.Direction.X;
            var dy1 = r.Direction.Y;
            var x2 = other.Direction.X;
            var y2 = other.Direction.Y;
            var dx2 = other.Direction.X;
            var dy2 = other.Direction.Y;

            var denominator = dx1 * dy2 - dy1 * dx2;
            if (denominator == 0) return intersections; // rays are parallel or coincident

            var t = ((x2 - x1) * dy2 - (y2 - y1) * dx2) / denominator;
            var s = ((x2 - x1) * dy1 - (y2 - y1) * dx1) / denominator;

            if(t >= 0 && s >= 0)
            {
                var ix = x1 + t * dx1;
                var iy = y1 + t * dy1;
                intersections.Add(new Vector2(ix, iy));
            }

            return intersections;
        }

        #endregion [Shape] INTERSECTS Ray
    }
}
