using Kz.Engine.DataStructures;

namespace Kz.Engine.Geometry2d.Primitives
{
    public class PolyRectangle : Polygon
    {
        public PolyRectangle(Vector2f position, Vector2f size) : this(position.X, position.Y, size.X, size.Y)
        {
        }

        public PolyRectangle(float posX, float posY, float width, float height)
        {
            Vertices.Add(new Vector2f(posX, posY)); // top left
            Vertices.Add(new Vector2f(posX + width, posY)); // top right
            Vertices.Add(new Vector2f(posX + width, posY + height)); // bottom right
            Vertices.Add(new Vector2f(posX, posY + height)); // bottom left
        }
    }
}