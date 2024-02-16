namespace Geometry2d.Lib.Primitives
{
    public class Polygon : IShape
    {
        #region ctor

        public List<Vector2> Vertices = new List<Vector2>();

        public Polygon()
        {
            Vertices = new List<Vector2>();
        }

        public Polygon(List<Vector2> vertices)
        {
            Vertices = [.. vertices];

            if (!IsValid()) throw new ArgumentException("vertices are not in clockwise order");
        }

        public Polygon(params Vector2[] vertices)
        {
            Vertices = [.. vertices];

            if (!IsValid()) throw new ArgumentException("vertices are not in clockwise order");
        }
        

        public override string ToString()
        {
            var asStrings = Vertices.Select(x => x.ToString()).ToArray();
            var verts = string.Join(", ", asStrings);
            return $"Polygon [{verts}]";
        }

        public static bool IsValid(Polygon p)
        {
            int n = p.Vertices.Count();
            double area = 0;

            for (int i = 0; i < n; i++)
            {
                int nextIndex = (i + 1) % n; // Ensures the polygon closes by connecting the last vertex to the first
                area += p.Vertices[i].X * p.Vertices[nextIndex].Y - p.Vertices[nextIndex].X * p.Vertices[i].Y;
            }

            return area > 0;
        }

        public bool IsValid() => IsValid(this);

        #endregion ctor

        #region Polygon Properties

        /// <summary>
        /// returns the area of a polygon using the Shoelace forumla (aka Gauss's area formula)
        /// </summary>
        public static float Area(Polygon p)
        {
            var n = p.Vertices.Count;
            var area = 0.0f;

            for (var i = 0; i < n - 1; i++)
            {
                int nextIndex = (i + 1) % n; // Ensures the polygon closes by connecting the last vertex to the first
                area += p.Vertices[i].X * p.Vertices[nextIndex].Y - p.Vertices[nextIndex].X * p.Vertices[i].Y;
            }

            return MathF.Abs(area) / 2.0f;
        }

        public float Area() => Area(this);

        public static float Perimeter(Polygon g)
        {
            var length = 0.0f;

            for (var i = 0; i < g.Vertices.Count(); i++)
            {
                length += g.Side(i).Length();
            }

            return length;
        }

        public float Perimeter() => Perimeter(this);

        public static int NumSides(Polygon p)
        {
            return p.Vertices.Count;
        }

        public int NumSides() => NumSides(this);

        /// <summary>
        /// get a line from an indexed side, starting at top and going clockwise
        /// </summary>
        public static Line Side(Polygon g, int index)
        {
            var numVerts = g.Vertices.Count();
            return new Line(g.Vertices[index % numVerts], g.Vertices[(index + 1) % numVerts]);
        }

        /// <summary>
        /// get a line from an indexed side, starting at top and going clockwise
        /// </summary>
        public Line Side(int index) => Side(this, index);

        public static List<Line> Sides(Polygon p)
        {
            var sides = new List<Line>();

            for (var i = 0; i < p.NumSides(); i++)
            {
                sides.Add(p.Side(i));
            }

            return sides;
        }

        public List<Line> Sides() => Sides(this);

        public static Vector2 Center(Polygon p)
        {
            var center = new Vector2();

            for(var i =0; i < p.NumSides(); i++)
            {
                center += p.Vertices[i];
            }

            center /= p.NumSides();

            return center;
        }

        public Vector2 Center() => Center(this);

        #endregion Polygon Properties        
    }
}