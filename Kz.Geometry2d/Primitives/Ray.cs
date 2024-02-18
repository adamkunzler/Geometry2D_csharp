using Kz.DataStructures;

namespace Kz.Geometry2d.Primitives
{
    public class Ray : IShape
    {
        #region ctor

        private Vector2f _direction = new();

        public Point Origin { get; set; }

        public Vector2f Direction
        {
            get { return _direction; }
            set { _direction = value.Normal(); }
        }

        public Ray()
        {
            Origin = new Point();
            Direction = new();
        }

        public Ray(Point origin, Vector2f direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"Ray [{Origin}, {Direction}]";
        }

        #endregion ctor
    }
}