using Kz.DataStructures;

namespace Kz.Geometry2d.Primitives
{
    public class Point : Vector2f, IShape
    {
        public Point()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Point(Vector2f v)
        {
            X = v.X;
            Y = v.Y;
        }

        public new static Point Zero = new Point(0.0f, 0.0f);        
    }
}
