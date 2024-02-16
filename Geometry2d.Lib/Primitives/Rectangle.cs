namespace Geometry2d.Lib.Primitives
{
    public class Rectangle : IShape
    {
        #region ctor

        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        public Rectangle()
        {
            Position = new Vector2();
            Size = new Vector2();
        }

        public Rectangle(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        public Rectangle(float posX, float posY, float width, float height)
        {
            Position = new Vector2(posX, posY);
            Size = new Vector2(width, height);
        }

        public override string ToString()
        {
            return $"Rectangle [{Position}, {Size}]";
        }

        #endregion ctor

        #region Boundaries

        public Vector2 Middle => Position + (Size * 0.5f);

        public Line Top => new(Position, new Vector2(Position.X + Size.Width, Position.Y));

        public Line Bottom => new(new Vector2(Position.X, Position.Y + Size.Height), Position + Size);

        public Line Left => new(Position, new Vector2(Position.X, Position.Y + Size.Height));

        public Line Right => new(new Vector2(Position.X + Size.Width, Position.Y), Position + Size);

        public List<Line> Sides => new List<Line> { Top, Right, Bottom, Left };

        public Vector2 TopLeft => Position;

        public Vector2 TopRight => new(Position.X + Size.Width, Position.Y);

        public Vector2 BottomLeft => new(Position.X, Position.Y + Size.Height);

        public Vector2 BottomRight => new(Position.X + Size.Width, Position.Y + Size.Height);

        public List<Vector2> Vertices => new List<Vector2> { TopLeft, TopRight, BottomRight, BottomLeft };

        #endregion Boundaries

        #region Rectangle Properties
        
        public static float Perimeter(Rectangle r)
        {
            return 2.0f * (r.Size.Width + r.Size.Height);
        }

        public float Perimeter() => Perimeter(this);
        
        public static float Area(Rectangle r)
        {
            return r.Size.Width * r.Size.Height;
        }

        public float Area() => Area(this);

        public static bool IsSquare(Rectangle r)
        {
            return r.Size.Width == r.Size.Height;
        }

        public bool IsSquare() => IsSquare(this);

        public static int NumSides(Rectangle r) => 4;

        public int NumSides() => NumSides(this);

        #endregion Rectangle Properties
    }
}