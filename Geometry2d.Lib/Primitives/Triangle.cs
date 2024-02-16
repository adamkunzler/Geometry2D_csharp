using Geometry2d.Lib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2d.Lib.Primitives
{
    public class Triangle : IShape
    {
        #region ctor

        public Vector2[] Vertices = new Vector2[3];
        
        public Triangle() 
        {
            Vertices[0] = new Vector2();
            Vertices[1] = new Vector2();
            Vertices[2] = new Vector2();
        }

        public Triangle(Vector2[] vertices)
        {
            if (vertices.Count() != 3) throw new ArgumentException("invalid number of vertices");

            Vertices = vertices;

            if (!IsValid()) throw new ArgumentException("vertices are not in clockwise order");
        }

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            Vertices[0] = p1;
            Vertices[1] = p2;
            Vertices[2] = p3;

            if (!IsValid()) throw new ArgumentException("vertices are not in clockwise order");
        }

        public Triangle(float px1, float py1, float px2, float py2, float px3, float py3)
        {
            Vertices[0] = new Vector2(px1, py1);
            Vertices[1] = new Vector2(px2, py2);
            Vertices[2] = new Vector2(px3, py3);

            if (!IsValid()) throw new ArgumentException("vertices are not in clockwise order");
        }

        public override string ToString()
        {
            return $"Triangle [{Vertices[0]}, {Vertices[1]}, {Vertices[2]}]";
        }

        /// <summary>
        /// returns true if vertices are defined in clockwise order
        /// </summary>        
        public static bool IsValid(Triangle t)
        {
            double area = (t.Vertices[0].X * (t.Vertices[1].Y - t.Vertices[2].Y)) +
                (t.Vertices[1].X * (t.Vertices[2].Y - t.Vertices[0].Y)) +
                (t.Vertices[2].X * (t.Vertices[0].Y - t.Vertices[1].Y));
            
            return area > 0;
        }

        public bool IsValid() => IsValid(this);

        #endregion ctor

        #region Triangle Properties

        public static float Area(Triangle t)
        {
            return 0.5f * MathF.Abs(
                (t.Vertices[0].X * (t.Vertices[1].Y - t.Vertices[2].Y)) +
                (t.Vertices[1].X * (t.Vertices[2].Y - t.Vertices[0].Y)) +
                (t.Vertices[2].X * (t.Vertices[0].Y - t.Vertices[1].Y))
            );
        }

        public float Area() => Area(this);

        public static float Perimeter(Triangle t)
        {
            var side1 = new Line(t.Vertices[0], t.Vertices[1]);
            var side2 = new Line(t.Vertices[1], t.Vertices[2]);
            var side3 = new Line(t.Vertices[2], t.Vertices[0]);

            return side1.Length() + side2.Length() + side3.Length();
        }

        public float Perimeter() => Perimeter(this);

        public static int NumSides(Triangle t) => 3;

        public int NumSides() => NumSides(this);

        /// <summary>
        /// get a line from an indexed side, starting at top and going clockwise
        /// </summary>        
        public static Line Side(Triangle t, int index)
        {
            return new Line(t.Vertices[index % 3], t.Vertices[(index + 1) % 3]);
        }
        
        /// <summary>
        /// get a line from an indexed side, starting at top and going clockwise
        /// </summary>        
        public Line Side(int index) => Side(this, index);

        /// <summary>
        /// Return all the sides of the triangle as a list of lines
        /// </summary>
        public List<Line> Sides => new List<Line> { Side(0), Side(1), Side(2) };

        #endregion Triangle Properties

        #region Triangle Centers

        /// <summary>
        /// Calculates the center of a triangle (the point where the triangle's three medians intersect). Also the center of gravity of the triangle.
        /// </summary>        
        public static Vector2 Centroid(Triangle t)
        {
            var center = (t.Vertices[0] + t.Vertices[1] + t.Vertices[2]) / 3.0f;
            return center;
        }

        /// <summary>
        /// Calculates the center of a triangle (the point where the triangle's three medians intersect). Also the center of gravity of the triangle.
        /// </summary>        
        public Vector2 Centroid() => Centroid(this);

        /// <summary>
        /// Calculates the intersection of the perpendicular bisectors of the sides.
        /// </summary>        
        public static Vector2 Circumcenter(Triangle t)
        {
            var x1 = t.Vertices[0].X;
            var y1 = t.Vertices[0].Y;
            var x2 = t.Vertices[1].X;
            var y2 = t.Vertices[1].Y;
            var x3 = t.Vertices[2].X;
            var y3 = t.Vertices[2].Y;

            var ab = t.Vertices[1] - t.Vertices[0];
            var ac = t.Vertices[2] - t.Vertices[0];

            var ba = t.Vertices[0] - t.Vertices[1];
            var bc = t.Vertices[2] - t.Vertices[1];

            var ca = t.Vertices[0] - t.Vertices[2];
            var cb = t.Vertices[1] - t.Vertices[2];

            var a = Vector2.AngleBetween(ab, ac);
            var b = Vector2.AngleBetween(ba, bc);
            var c = Vector2.AngleBetween(ca, cb);

            var xNumerator = x1 * MathF.Sin(2.0f * a) + x2 * MathF.Sin(2.0f * b) + x3 * MathF.Sin(2.0f * c);
            var xDenominator = MathF.Sin(2.0f * a) + MathF.Sin(2.0f * b) + MathF.Sin(2.0f * c);
            var x = xNumerator / xDenominator;

            var yNumerator = y1 * MathF.Sin(2.0f * a) + y2 * MathF.Sin(2.0f * b) + y3 * MathF.Sin(2.0f * c);
            var yDenominator = MathF.Sin(2.0f * a) + MathF.Sin(2.0f * b) + MathF.Sin(2.0f * c);
            var y = yNumerator / yDenominator;
            
            return new Vector2(x, y);
        }

        /// <summary>
        /// Calculates the intersection of the perpendicular bisectors of the sides.
        /// </summary>        
        public Vector2 Circumcenter() => Circumcenter(this);

        /// <summary>
        /// Calculate the circumcircle of a triangle. A circle that passes through all three vertices of the triangle.
        /// </summary>        
        public static Circle Circumcircle(Triangle t)
        {
            var a = t.Side(0).Length();
            var b = t.Side(1).Length();
            var c = t.Side(2).Length();

            var d1 = a + b + c;
            var d2 = b + c - a;
            var d3 = c + a - b;
            var d4 = a + b - c;

            var numerator = a * b * c;
            var denominator = MathF.Sqrt(d1 * d2 * d3 * d4);

            var radius = numerator / denominator;

            return new Circle(t.Circumcenter(), radius);
        }

        /// <summary>
        /// Calculate the circumcircle of a triangle. A circle that passes through all three vertices of the triangle.
        /// </summary>        
        public Circle Circumcircle() => Circumcircle(this);

        /// <summary>
        /// Calculate the incenter of a triangle. Located at the intersection of the angle bisectors.
        /// </summary>        
        public static Vector2 Incenter(Triangle t)
        {
            var a = t.Vertices[0];
            var b = t.Vertices[1];
            var c = t.Vertices[2];

            var lenA = (c - b).Magnitude();
            var lenB = (c - a).Magnitude();
            var lenC = (b - a).Magnitude();

            var p = t.Perimeter();

            var x = (lenA * a.X + lenB * b.X + lenC * c.X) / p;
            var y = (lenA * a.Y + lenB * b.Y + lenC * c.Y) / p;

            return new Vector2(x, y);
        }

        /// <summary>
        /// Calculate the incenter of a triangle. Located at the intersection of the angle bisectors.
        /// </summary>        
        public Vector2 Incenter() => Incenter(this);

        /// <summary>
        /// Calculate the incircle of a triangle. The largest circle that will fit in a triangle.
        /// </summary>        
        public static Circle Incircle(Triangle t)
        {
            var incenter = t.Incenter();
            var radius = G2d.DistanceTo(incenter, t.Side(0));
            
            return new Circle(incenter, radius);
        }

        /// <summary>
        /// Calculate the incircle of a triangle. The largest circle that will fit in a triangle.
        /// </summary>        
        public Circle Incircle() => Incircle(this);

        /// <summary>
        /// Calculate the orthocenter of a triangle. Located at the intersection of the altitudes.
        /// </summary>        
        public static Vector2 Orthocenter(Triangle t)
        {
            var cc = t.Circumcenter();
            var ct = t.Centroid();

            var ox = 3.0f * ct.X - 2.0f * cc.X;
            var oy = 3.0f * ct.Y - 2.0f * cc.Y;

            return new Vector2(ox, oy);
        }

        /// <summary>
        /// Calculate the orthocenter of a triangle. Located at the intersection of the altitudes.
        /// </summary>        
        public Vector2 Orthocenter() => Orthocenter(this);

        #endregion Triangle Centers
    }
}
