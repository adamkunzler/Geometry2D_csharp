using Kz.DataStructures;

namespace Kz.Geometry2d.Primitives
{
    public class PolyRectangle : Polygon
    {
        public PolyRectangle(Point position, Vector2f size) : this(position.X, position.Y, size.X, size.Y)
        {
        }

        public PolyRectangle(float posX, float posY, float width, float height)
        {
            Vertices.Add(new Point(posX, posY)); // top left
            Vertices.Add(new Point(posX + width, posY)); // top right
            Vertices.Add(new Point(posX + width, posY + height)); // bottom right
            Vertices.Add(new Point(posX, posY + height)); // bottom left
        }
    }
}