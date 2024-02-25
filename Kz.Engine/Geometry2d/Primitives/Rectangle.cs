using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Primitives
{
    public class Rectangle : IShape
    {
        #region ctor

        public Point Position { get; set; }
        public Vector2f Size { get; set; }

        public Rectangle()
        {
            Position = new Point();
            Size = new Vector2f();
        }

        public Rectangle(Point position, Vector2f size)
        {
            Position = position;
            Size = size;
        }

        public Rectangle(float posX, float posY, float width, float height)
        {
            Position = new Point(posX, posY);
            Size = new Vector2f(width, height);
        }

        public override string ToString()
        {
            return $"Rectangle [{Position}, {Size}]";
        }

        #endregion ctor

        #region Boundaries

        public Point Middle => new Point(Position + (Size * 0.5f));

        public Line Top => new(Position, new Point(Position.X + Size.Width, Position.Y));

        public Line Bottom => new(new Point(Position.X, Position.Y + Size.Height), new Point(Position + Size));

        public Line Left => new(Position, new Point(Position.X, Position.Y + Size.Height));

        public Line Right => new(new Point(Position.X + Size.Width, Position.Y), new Point(Position + Size));

        public List<Line> Sides => new() { Top, Right, Bottom, Left };

        public Point TopLeft => Position;

        public Point TopRight => new(Position.X + Size.Width, Position.Y);

        public Point BottomLeft => new(Position.X, Position.Y + Size.Height);

        public Point BottomRight => new(Position.X + Size.Width, Position.Y + Size.Height);

        public List<Point> Vertices => new List<Point> { TopLeft, TopRight, BottomRight, BottomLeft };

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