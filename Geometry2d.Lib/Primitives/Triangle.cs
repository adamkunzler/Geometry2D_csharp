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
            return $"[{Vertices[0]}, {Vertices[1]}, {Vertices[2]}]";
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

        public List<Line> Sides => new List<Line> { Side(0), Side(1), Side(2) };

        public static Vector2 Center(Triangle t)
        {
            var center = (t.Vertices[0] + t.Vertices[1] + t.Vertices[2]) / 3.0f;
            return center;
        }

        public Vector2 Center() => Center(this);

        #endregion Triangle Properties
    }
}
