namespace Geometry2d.Lib.Primitives
{
    public class Ray : IShape
    {
        #region ctor

        private Vector2 _direction = new Vector2();

        public Vector2 Origin { get; set; }

        public Vector2 Direction 
        { 
            get {  return _direction; }
            set {  _direction = value.Normal(); }
        }

        public Ray()
        {
            Origin = new Vector2();
            Direction = new Vector2();
        }

        public Ray(Vector2 origin, Vector2 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public override string ToString()
        {
            return $"[{Origin}, {Direction}]";
        }

        #endregion ctor
    }
}
