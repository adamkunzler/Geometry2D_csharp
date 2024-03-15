using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Primitives
{
    public class Rectangle : IShape
    {
        #region ctor

        public Vector2f Position { get; set; }
        public Vector2f Size { get; set; }

        public Rectangle()
        {
            Position = new Vector2f();
            Size = new Vector2f();
        }

        public Rectangle(Vector2f position, Vector2f size)
        {
            Position = position;
            Size = size;
        }

        public Rectangle(float posX, float posY, float width, float height)
        {
            Position = new Vector2f(posX, posY);
            Size = new Vector2f(width, height);
        }

        public override string ToString()
        {
            return $"Rectangle [{Position}, {Size}]";
        }

        #endregion ctor

        #region Boundaries

        public Vector2f Middle => Position + (Size * 0.5f);

        public Line Top => new(Position, new Vector2f(Position.X + Size.Width, Position.Y));

        public Line Bottom => new(new Vector2f(Position.X, Position.Y + Size.Height), Position + Size);

        public Line Left => new(Position, new Vector2f(Position.X, Position.Y + Size.Height));

        public Line Right => new(new Vector2f(Position.X + Size.Width, Position.Y), Position + Size);

        public List<Line> Sides => new() { Top, Right, Bottom, Left };

        public Vector2f TopLeft => Position;

        public Vector2f TopRight => new(Position.X + Size.Width, Position.Y);

        public Vector2f BottomLeft => new(Position.X, Position.Y + Size.Height);

        public Vector2f BottomRight => new(Position.X + Size.Width, Position.Y + Size.Height);

        public List<Vector2f> Vertices => new List<Vector2f> { TopLeft, TopRight, BottomRight, BottomLeft };

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