using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Primitives
{
    public class Ray : IShape
    {
        #region ctor

        private Vector2f _direction = new();

        public Vector2f Origin { get; set; }

        public Vector2f Direction
        {
            get { return _direction; }
            set { _direction = value.Normal(); }
        }

        public Ray()
        {
            Origin = new Vector2f();
            Direction = new();
        }

        public Ray(Vector2f origin, Vector2f direction)
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